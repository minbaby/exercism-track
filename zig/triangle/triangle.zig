pub const TriangleError = error{
    Invalid,
};

pub const Triangle = struct {
    // This struct, as well as its fields and methods, needs to be implemented.

    a: f64,
    b: f64,
    c: f64,

    pub fn init(a: f64, b: f64, c: f64) TriangleError!Triangle {
        const ret = Triangle{
            .a = a,
            .b = b,
            .c = c,
        };

        if (!ret.isValid()) {
            return TriangleError.Invalid;
        }

        return ret;
    }

    fn isValid(self: Triangle) bool {
        return self.a > 0 and self.b > 0 and self.c > 0 and self.a + self.b > self.c and self.a + self.c > self.b and self.c + self.b > self.a;
    }

    ///
    /// 是否是等边
    ///
    pub fn isEquilateral(self: Triangle) bool {
        return self.a == self.b and self.a == self.c and self.b == self.c;
    }

    ///
    /// 是否等腰
    ///
    pub fn isIsosceles(self: Triangle) bool {
        return self.a == self.b or self.a == self.c or self.b == self.c;
    }

    ///
    /// 是否是不等边
    ///
    pub fn isScalene(self: Triangle) bool {
        return self.a != self.b and self.a != self.c and self.b != self.c;
    }
};
