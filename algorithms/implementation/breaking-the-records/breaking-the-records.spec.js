breakingTheRecords = require("./breaking-the-records")

describe("breaking-the-records", function () {
    it("Input 0", function () {
        let output=breakingTheRecords.breakingRecords ([10,5, 20, 20, 4, 5, 2, 25, 1]);
        expect(output).toEqual([2,4]);
    });
    it("Input 1", function () {
        let output=breakingTheRecords.breakingRecords ([3, 4, 21, 36, 10, 28, 35, 5, 24, 42]);
        expect(output).toEqual([4,0]);
    });
});