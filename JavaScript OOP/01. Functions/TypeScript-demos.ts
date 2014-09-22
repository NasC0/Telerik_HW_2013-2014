class Animal {
	private _isAlive: boolean;
	private _name: string;

	constructor (name: string, public age: number) {
		this.name = name;
		this._isAlive = true;
		
	}

	get name() {
		return this._name;
	}

	set name(name: string) {
		if (!name) {
			throw new Error('Name value cannot be undefined.');
		}

		if (name.length <= 0) {
			throw new Error('Name value must be at least 1 symbol long.');
		}

		this._name = name;
	}

	kill(): void {
		this._isAlive = false;
	}
}