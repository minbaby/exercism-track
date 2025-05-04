const std = @import("std");

pub fn isArmstrongNumber(num: u128) bool {
    var num_len: u128 = 0;

    var tmp = num;
    while (tmp != 0) {
        tmp = tmp / 10;
        num_len += 1;
    }

    var ret: u128 = 0;

    tmp = num;
    while (tmp != 0) {
        ret += std.math.pow(u128, tmp % 10, num_len);
        tmp = tmp / 10;
    }

    return ret == num;
}

pub fn isArmstrongNumber_1(num: u128) bool {
    var gpa = std.heap.GeneralPurposeAllocator(.{}){};
    const allocator = gpa.allocator();
    defer _ = gpa.deinit();

    var arr = std.ArrayList(u128).init(allocator);
    defer arr.deinit();

    var y: u128 = num;
    var count: u128 = 0;
    while (true) {
        arr.append(y % 10) catch |err| {
            std.debug.print("some error {}", .{err});
        };
        y = y / 10;
        count += 1;

        if (y <= 0) {
            break;
        }
    }

    var ret: u128 = 0;

    for (arr.items) |value| {
        ret += std.math.pow(u128, value, count);
    }

    return ret == num;
}
