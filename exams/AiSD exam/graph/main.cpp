#pragma once

#include <iostream>
#include <vector>
#include <cmath>
#include <algorithm>

#include "edge.h"
#include "dsu.h"
#include "prima.h"
#include "boruvka.h"

#define all(x) x.begin(), x.end()

using namespace std;

typedef pair<int, int> pii;

const int MXN = 1e4;
const int inf = 1e9;

int n, m;
vector<Edge> edges;
vector<set<pii>> g;

vector<Edge> get_tree_by_prima(int n, int m, vector<set<pii>> g) {
    Prima* prima = new Prima(n, m, g);
    return prima->build_tree();
}

vector<Edge> get_tree_by_kraskala(int n, int m, vector<Edge>& edges) {
    sort(all(edges), [](Edge& a, Edge& b) -> bool { return a.price < b.price; });
    vector<Edge> result_tree;
    DSU* dsu = new DSU(n, m);
    for (auto& edge : edges) {
        if (!dsu->is_common_set(edge.x, edge.y)) {
            dsu->unite_sets(edge.x, edge.y);
            result_tree.push_back(edge);
        }
    }
    return result_tree;
}

vector<Edge> get_tree_by_boruvka(int n, int m, vector<Edge> edges, vector<set<pii>> g) {
    Boruvka* boruvka = new Boruvka(n, m, edges, g);
    return boruvka->build_tree();
}

void output_tree(vector<Edge>& tree, string title) {
    cout << title << ":" << endl;
    int total_price = 0;
    for (auto& edge : tree) {
        cout << edge.x << " " << edge.y << " " << edge.price << endl;
        total_price += edge.price;
    }

    cout << "Total price: " << total_price << endl;
}

int main()
{
    freopen("input.txt", "r", stdin);
//    freopen("output.txt", "w", stdout);

    cin >> n >> m;
    g.resize(n + 1);
    for (int i = 0; i < m; ++i) {
        int x, y, price;
        cin >> x >> y >> price;
        g[x].insert({ y, price });
        g[y].insert({ x, price });
        edges.push_back({ x, y, price });
    }

    vector<Edge> tree_by_kraskala = get_tree_by_kraskala(n, m, edges);
    vector<Edge> tree_by_prima = get_tree_by_prima(n, m, g);
    vector<Edge> tree_by_boruvka = get_tree_by_boruvka(n, m, edges, g);

    output_tree(tree_by_kraskala, "DSU, Kraskala");
    cout << endl;

    output_tree(tree_by_prima, "Prima");
    cout << endl;
    output_tree(tree_by_boruvka, "DSU, Boruvka");
    cout << endl;

    return 0;
}
