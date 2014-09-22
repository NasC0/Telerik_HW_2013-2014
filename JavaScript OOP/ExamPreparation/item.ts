class Item {
	private _content: string;

	constructor (content: string) {
		this.content = content;
	}

	get content() {
		return this._content;
	}

	private set content(content: string) {
		if (content.length <= 0) {
			throw new Error('Content string must be longer than 0 symbols.');
		}

		this._content = content;
	}
}