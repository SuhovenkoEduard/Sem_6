#pragma once

#include <vector>
#include <set>

#include "edge.h"

using namespace std;

typedef pair<int, int> pii;

class Prima {
public:
    int n, m;
    vector<set<pii>> g;

    Prima(int _n, int _m, vector<set<pii>> _g) {
        n = _n;
        m = _m;
        g = _g;
    }

    vector<Edge> build_tree() {
        vector<bool> used(n + 1, 0);
        vector<Edge> result_tree(1, { 1, g[1].begin()->first, g[1].begin()->second });
        vector<int> vertexes;
        vertexes.push_back(1);
        vertexes.push_back(g[1].begin()->first);
        used[1] = used[g[1].begin()->first] = true;
        while(result_tree.size() != n - 1) {
            Edge current = { 0, 0, (int)1e9 };
            for (auto& vertex : vertexes) {
                for (auto& pr : g[vertex]) {
                    int to = pr.first;
                    int price = pr.second;
                    if (!used[to] && current.price > price) {
                        current = { vertex, to, price };
                    }
                }
            }
            used[current.y] = true;
            result_tree.push_back(current);
            vertexes.push_back(current.y);
        }

        return result_tree;
    }
};
