#pragma once

#include <vector>

using namespace std;

class DSU {
public:
    int n, m;

    vector<int> p;
    vector<int> h;

    DSU(int _n, int _m) {
        n = _n;
        m = _m;
        p.resize(n + 1);
        h.resize(n + 1);
        for (int i = 1; i <= n; ++i)
            make_set(i);
    }

    void make_set (int x) {
        p[x] = x;
        h[x] = 0;
    }

    bool is_common_set(int a, int b) {
        return find_set(a) == find_set(b);
    }

    int find_set(int x) {
        return p[x] == x ? x : find_set(p[x]);
    }

    void unite_sets(int a, int b) {
        int ta = find_set(a);
        int tb = find_set(b);

        if (ta == tb) return;
        if (h[ta] < h[tb])
            swap(ta, tb);

        p[tb] = ta;
        if (h[ta] == h[tb])
            h[ta] += 1;
    }
};
