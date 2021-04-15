#pragma once
#include "Coord.g.h"

namespace winrt::CoordsRTC::implementation
{
    struct Coord : CoordT<Coord>
    {
        Coord() = default;

        Coord(double x, double y);
        double X();
        void X(double value);
        double Y();
        void Y(double value);
        double Distance(winrt::CoordsRTC::Coord const& c);
        hstring ToString();
    };
}
namespace winrt::CoordsRTC::factory_implementation
{
    struct Coord : CoordT<Coord, implementation::Coord>
    {
    };
}
