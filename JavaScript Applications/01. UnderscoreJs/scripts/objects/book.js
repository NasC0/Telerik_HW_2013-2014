define(function() {
    var Book;

    Book = (function() {
        function Book(title, author) {
            this.title(title);
            this.author(author);
        }

        Book.prototype.title = function(bookTitle) {
            if (bookTitle === undefined) {
                return this._title;
            } else {
                if (typeof(bookTitle) === 'string') {
                    this._title = bookTitle;
                }
            }
        };

        Book.prototype.author = function(authorName) {
            if (authorName === undefined) {
                return this._author;
            } else {
                if (typeof(authorName) === 'string') {
                    this._author = authorName;
                }
            }
        };

        return Book;
    }());

    return Book;
});