pub fn squareOfSum(number: usize) usize {
    var ret: usize = 0;
    for (1..number + 1) |i| {
        ret += i;
    }

    return ret * ret;
}

pub fn sumOfSquares(number: usize) usize {
    var ret: usize = 0;
    for (1..number + 1) |i| {
        ret += i * i;
    }

    return ret;
}

pub fn differenceOfSquares(number: usize) usize {
    return squareOfSum(number) - sumOfSquares(number);
}
