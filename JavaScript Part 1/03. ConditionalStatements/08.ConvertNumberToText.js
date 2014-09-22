//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 8. Write a script that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples: //
// 0  'Zero'                                                                                                                           //
// 273  'Two hundred seventy three'                                                                                                    //
// 400  'Four hundred'                                                                                                                 //
// 501  'Five hundred and one'                                                                                                         //
// 711  'Seven hundred and eleven'                                                                                                     //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function printOnes(number) {
    switch (number) {
        case 1:
            return "One";
        case 2:
            return "Two";
        case 3:
            return "Three";
        case 4:
            return "Four";
        case 5:
            return "Five";
        case 6:
            return "Six";
        case 7:
            return "Seven";
        case 8:
            return "Eight";
        case 9:
            return "Nine";
        case 0:
            return "Zero";
    }
}

function printSpecials(number) {
    switch (number) {
        case 11:
            return "Eleven";
        case 12:
            return "Twelve";
        case 13:
            return "Thirteen";
        case 14:
            return "Fourteen";
        case 15:
            return "Fifteen";
        case 16:
            return "Sixteen";
        case 17:
            return "Seventeen";
        case 18:
            return "Eighteen";
        case 19:
            return "Nineteen";
        default:
            return "Ten";
    }
}

function printTens(number) {
    switch (number) {
        case 2:
            return "Twenty";
        case 3:
            return "Thirty";
        case 4:
            return "Forty";
        case 5:
            return "Fifty";
        case 6:
            return "Sixty";
        case 7:
            return "Seventy";
        case 8:
            return "Eighty";
        case 9:
            return "Ninety";
        default:
            return "";
    }
}

function printHundreds(number) {
    switch (number) {
        case 1:
            return "One hundred";
        case 2:
            return "Two hundred";
        case 3:
            return "Three hundred";
        case 4:
            return "Four hundred";
        case 5:
            return "Five hundred";
        case 6:
            return "Six hundred";
        case 7:
            return "Seven hundred";
        case 8:
            return "Eight hundred";
        case 9:
            return "Nine hundred";
        default:
            return "";
    }
}

var number = 670;

if (number < 10 && number >= 0) {
    console.log(printOnes(number));

} else if (number >= 10 && number < 20) {
    console.log(printSpecials(number));

} else if (number >= 20 && number < 100) {
    var tens = parseInt(number / 10);
    var digits = number % 10;
    var output = printTens(tens);

    if (digits !== 0) {
        output += " " + printOnes(digits);
    }

    console.log(output);

} else if (number >= 100 && number < 1000) {
    var hundreds = parseInt(number / 100);
    var output = printHundreds(hundreds);
    var remainder = number % 100;

    if (remainder >= 10 && remainder < 20) {
        output += " and " + printSpecials(remainder);
        console.log(output);

    } else {
        var tens = parseInt(remainder / 10);
        var ones = parseInt(remainder % 10);

        if (tens === 0 && ones === 0) {
            console.log(output);

        } else if (tens === 0 && ones > 0) {
            output += " and " + printOnes(ones);
            console.log(output);

        } else if (tens > 0 && ones === 0) {
            output += " and " + printTens(tens);
            console.log(output);

        } else {
            output += " and " + printTens(tens) + " " + printOnes(ones);
            console.log(output);
        }
    }
}