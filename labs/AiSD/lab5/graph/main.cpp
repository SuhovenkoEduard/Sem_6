#include <iostream>
#include <vector>
#include <cmath>

using namespace std;

const int MXN = 1e4;
const int inf = 1e9;

int n, m;
bool used[MXN];
vector<vector<int>> minDist(MXN, vector<int>());
vector<int> g[MXN];

int dfs(int v, int start, int dist) {
    used[v] = true;
    minDist[start][v] = min(minDist[start][v], dist);
    for (int x : g[v]) {
        if (!used[x]) {
            dfs(x, start, dist + 1);
        }
    }
    used[v] = false;
}

int main()
{
    freopen("input.txt", "r", stdin);
    freopen("output.txt", "w", stdout);

    cin >> n >> m;
    for (int i = 0; i < m; ++i) {
        int x, y;
        cin >> x >> y;
        g[x].push_back(y);
        g[y].push_back(x);
    }

    for (int i = 1; i <= n; ++i) {
        minDist[i].push_back(0);
        for (int j = 1; j <= n; ++j) {
            minDist[i].push_back(inf);
        }
    }

    for (int i = 1; i <= n; ++i) {
        dfs(i, i, 0);
    }

    /*
    for (int i = 1; i <= n; ++i) {
        cout << i << ": ";
        for (int j = 1; j <= n; ++j) {
            cout << minDist[i][j] << " ";
        }
        cout << endl;
    }
    cout << endl;
    */
    int ans = 0;
    for (int i = 1; i <= n; ++i) {
        for (int j = 1; j <= n; ++j) {
            ans = max(minDist[i][j], ans);
        }
    }

    cout << ans << endl;

    return 0;
}
