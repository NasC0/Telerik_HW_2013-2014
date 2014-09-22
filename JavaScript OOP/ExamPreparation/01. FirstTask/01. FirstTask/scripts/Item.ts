class Item implements IItem {
    private _content: string;

    constructor(content: string) {
        this.content = content;
    }

    private set content(content: string) {
        if (content.length < 0) {
            throw new Error("Item content must be at 1 symbol long.");
        }

        this._content = content;
    }

    getData(): string {
        return this._content;
    }
} 