var CALENDAR_WIDTH = window.innerWidth - 400;
var SINGLE_DAY_WIDTH = CALENDAR_WIDTH / 7;
var SINGLE_DAY_HEIGHT = 100;
var MONTH = '06';
var MONTH_NAME = 'June';
var YEAR = '2014';
var tdElementTemplate = document.createElement('td');

tdElementTemplate.style.width = SINGLE_DAY_WIDTH + 'px';
tdElementTemplate.style.height = SINGLE_DAY_HEIGHT + 'px';
tdElementTemplate.style.border = '1px solid black';
tdElementTemplate.style.position = 'relative';

var tdDivTemplate = document.createElement('div');
tdDivTemplate.style.position = 'absolute';
tdDivTemplate.style.top = '0';
tdDivTemplate.style.left = '0';
tdDivTemplate.style.width = '100%';
tdDivTemplate.style.height = '100%';

var tdHeaderTemplate = document.createElement('header');
tdHeaderTemplate.style.display = 'block';
tdHeaderTemplate.style.backgroundColor = '#CCCCCC';
tdHeaderTemplate.style.borderBottom = '1px solid black';
tdHeaderTemplate.style.textAlign = 'center';

var tdInsideDivTemplate = document.createElement('div');
tdInsideDivTemplate.style.position = 'absolute';
tdInsideDivTemplate.style.top = '21px';
tdInsideDivTemplate.style.left = '0px';
tdInsideDivTemplate.style.height = '79px';
tdInsideDivTemplate.style.wordBreak = 'break-word';
tdInsideDivTemplate.style.overflow = 'auto'

tdDivTemplate.appendChild(tdHeaderTemplate);
tdElementTemplate.appendChild(tdDivTemplate);



function getDayOfWeek(date) {
    var weekDay = date.getDay();
    var weekDays = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
    return weekDays[weekDay];
}

function prepareDateString(date) {
    var date = new Date(Date.parse(MONTH + '.' + date + '.' + YEAR));
    return date;
}

function calculateHourPlusMinutes(hour, minutes) {
    var fullHourSplit = hour.split(':');
    var currentHour = parseInt(fullHourSplit[0]);
    var currentMinutes = parseInt(fullHourSplit[1]);
    var minutes = parseInt(minutes);

    var leftOverHours = Math.floor(minutes / 60);
    var leftOverMinutes = minutes % 60;

    currentHour += leftOverHours;

    if (currentHour > 24) {
        currentHour = currentHour - 24;
    }

    currentMinutes += leftOverMinutes;

    currentHour = currentHour < 10 ? '0' + currentHour : currentHour;
    currentMinutes = currentMinutes < 10 ? '0' + currentMinutes : currentMinutes;

    return currentHour + ':' + currentMinutes;
}

function getNodeTarget(node) {
    if (node instanceof HTMLDivElement) {
        if (node.parentElement instanceof HTMLDivElement) {
            return node.previousSibling;
        } else {
            return node.firstChild;
        }
    } else if (node.tagName === 'HEADER') {
        return node;
    }
}

function createCalendar(containerSelector, events) {
    var container = document.querySelector(containerSelector);
    container.style.width = CALENDAR_WIDTH;

    var calendarTable = document.createElement('table');
    calendarTable.style.borderCollapse = 'collapse';
    calendarTable.style.margin = 'auto';
    var currentSelectedNode;

    calendarTable.addEventListener('mouseover', function(ev) {
        var target = getNodeTarget(ev.target);
        if (target) {
            var target = target.firstChild.nodeType !== 3 ? target.firstChild : target;
            target.style.backgroundColor = '#999999';
        }
    });

    calendarTable.addEventListener('mouseout', function(ev) {
        var target = getNodeTarget(ev.target);
        if (target) {
            var target = target.firstChild.nodeType !== 3 ? target.firstChild : target;
            if (target === currentSelectedNode) {
                target.style.backgroundColor = '#FFFFFF';
            } else {
                target.style.backgroundColor = '#CCCCCC';
            }
        }
    });

    calendarTable.addEventListener('click', function(ev) {
        var target = getNodeTarget(ev.target);
        if (target) {
            var target = target.firstChild.nodeType !== 3 ? target.firstChild : target;

            if (currentSelectedNode === undefined) {
                currentSelectedNode = target;
            } else {
                currentSelectedNode.style.backgroundColor = '#CCCCCC';
            }

            currentSelectedNode = target;
            currentSelectedNode.style.backgroundColor = '#FFFFFF';
        }
    });

    var tableRowElement = document.createElement('tr');

    for (var i = 0; i < 30; i++) {
        if (i % 7 === 0 && i !== 0) {
            calendarTable.appendChild(tableRowElement);
            tableRowElement = document.createElement('tr');
        }

        var currentDay = tdElementTemplate.cloneNode(true);
        var currentDayHeader = currentDay.firstChild.firstChild;
        var fullDate = prepareDateString(i + 1);
        var dayOfWeek = getDayOfWeek(fullDate);
        var headerString = dayOfWeek + ' ' + (i + 1) + ' June 2014';
        currentDayHeader.innerHTML = headerString;

        for (var j in events) {
            var eventDate = parseInt(events[j].date);
            if (eventDate === i) {
                var currentContent = tdInsideDivTemplate.cloneNode(true);
                var eventEnd = calculateHourPlusMinutes(events[j].hour, events[j].duration);
                currentContent.innerHTML = events[j].hour + ' - ' + eventEnd + ': ' + events[j].title;
                currentDay.firstChild.appendChild(currentContent);
            }
        }

        tableRowElement.appendChild(currentDay);
    }

    calendarTable.appendChild(tableRowElement);

    container.appendChild(calendarTable);
}