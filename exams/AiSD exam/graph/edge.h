#pragma once

struct Edge {
    int x;
    int y;
    int price;

    bool operator==(Edge& b) {
        return (x == b.y && y == b.x && price == b.price) ||
            (x == b.x && y == b.y && price == b.price);
    }
};
