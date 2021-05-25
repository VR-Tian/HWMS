//export 
class Student {
    constructor(homework = []) {
        this.homework = homework;
    }

    study() {
        console.log(this.homework);
    }
}