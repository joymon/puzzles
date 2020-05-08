const test = require('bron');
const assert = require('assert').strict;

electronicShop = require("./electronic-shop")
 
test('Input 0', () => {
    assert.equal(electronicShop.electronicShop ([3,1], [5,2,8],10), 9);
});
 
test('Input 1', () => {
  assert.equal(electronicShop.electronicShop([4], [5],5), -1);
});