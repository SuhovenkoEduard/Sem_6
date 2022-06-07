#include <vector>
#include <set>
#include <map>

#include "dsu.h"
#include "edge.h"

#define all(x) x.begin(), x.end()

using namespace std;

typedef pair<int, int> pii;

class Boruvka {
public:
    int n, m;
    vector<Edge> edges;
    vector<set<pii>> g;
    map<pii, bool> current_graph;

    DSU* dsu = nullptr;

    Boruvka(int _n, int _m, vector<Edge> _edges, vector<set<pii>> _g) {
        n = _n;
        m = _m;
        g = _g;
        edges = _edges;
        dsu = new DSU(n, m);
    }

    Edge find_min_edge(int vertex, int p) {
        Edge min_edge = { 0, 0, (int) 1e9 };
        for (auto& pr : g[vertex]) {
            const int to = pr.first;
            const int price = pr.second;
            if (!dsu->is_common_set(vertex, to) && min_edge.price > price) {
                min_edge = { vertex, to, price };
            } else if (p != to && current_graph[{ vertex, to }]) {
                auto min_edge_dfs = find_min_edge(to, vertex);
                if (min_edge_dfs.price < min_edge.price) {
                    min_edge = min_edge_dfs;
                }
            }
        }
        return min_edge;
    }

    vector<Edge> build_tree() {
        set<int> current_sets;
        for (int i = 1; i <= n; ++i)
            current_sets.insert(i);

        vector<Edge> result_tree;
        vector<Edge> new_edges;
        while(result_tree.size() != n - 1) {
            for (auto& vertex : current_sets)
                new_edges.push_back(find_min_edge(vertex, vertex));

            auto it = unique(all(new_edges));
            new_edges.resize(distance(new_edges.begin(), it));

            current_sets.clear();
            for (auto& edge : new_edges) {
                if (!edge.x || !edge.y) continue;
                if (dsu->is_common_set(edge.x, edge.y)) continue;
                current_graph[{edge.x, edge.y}] = true;
                current_graph[{edge.y, edge.x}] = true;
                result_tree.push_back(edge);
                dsu->unite_sets(edge.x, edge.y);
                current_sets.insert(dsu->find_set(edge.x));
                current_sets.insert(dsu->find_set(edge.y));
            }
        }

        return result_tree;
    }
};
