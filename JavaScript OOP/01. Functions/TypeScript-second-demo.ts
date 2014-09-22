class Cat extends Animal {
	public legs: number;

	constructor (name: string, public age: number, legs: number) {
		super(name, age);
		this.legs = legs;
	}
}