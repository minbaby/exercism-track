using System;
using System.Collections.Generic;

// https://juejin.cn/post/6844904142515732494
public class SpiralMatrix
{
    // matrix 当作一个2d平面，那么每一个点都有坐标，
    // 那么当前点可以移动的方向即为
    // ↑ ( 0,  1)
    // ↓ ( 0, -1)
    // ← (-1,  0)
    // → ( 1,  0)
    // 方向转换： 每次循环左转 90°, 其实是有一个方向向量数组，按照固定顺序排序（
    // 这个解体思路是向量坐标的运算
    public static int[,] GetMatrix(int size)
    {
        var ret = new int[size, size];

        var fx = new (int, int)[] { (0, 1) /* 上 */, (1, 0) /* 右 */, (0, -1) /* 下 */, (-1, 0) /* 左 */};

        var condition = new int[] { 0, size - 1, size - 1, 0 };

        var x = 0;
        var y = 0;
        var dt = 0; // 方向 索引
        var x_ = 0;
        var y_ = 0;

        // 先按照某个方向走一步，然后判断是否再有效范围，如果不在， 则换个方向重新试一下(其实是 上--右--下--左 的顺序)
        for (int i = 0; i < size * size; i++)
        {
            ret[x, y] = i + 1;

            (x_, y_) = (x + fx[dt].Item1, y + fx[dt].Item2);

            if (x_ < condition[0] || x_ > condition[2] || y_ < condition[3] || y_ > condition[1])
            {
                if (dt == 1 || dt == 2)
                {
                    condition[dt] -= 1;
                }
                else
                {
                    condition[dt] += 1;
                }

                dt = (dt + 1) % 4;
                (x_, y_) = (x + fx[dt].Item1, y + fx[dt].Item2);
            }
            (x, y) = (x_, y_);
        }

        return ret;
    }
}
