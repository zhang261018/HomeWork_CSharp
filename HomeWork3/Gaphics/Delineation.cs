using System;

namespace Graphics
{
    //接口提供获得面积与判断图形是否合法的方法
    public interface Delineation
    {
        double? GetArea { get; }
        bool IsLegal { get; }
    }
}
