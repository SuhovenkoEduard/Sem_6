#pragma once

#include <iostream>
#include <vector>
#include <cmath>
#include <algorithm>

#define all(x) x.begin(), x.end()

using namespace std;

typedef pair<int, int> pii;

const int MXN = 1e4;
const int inf = 1e9;

int n, m;
vector<vector<int>> c;

int find_total_time(vector<vector<int>>& c, vector<int> curr) {
    int total_time = 0;
    for (int i = 0; i < n; ++i) {
        total_time += c[curr[i]][i];
    }
    return total_time;
}

int main()
{
    freopen("input.txt", "r", stdin);
//    freopen("output.txt", "w", stdout);

    cin >> n;
    c.resize(n, vector<int>(n, 0));

    for (int i = 0; i < n; ++i)
        for (int j = 0; j < n; ++j)
            cin >> c[i][j];

    vector<int> curr;
    for (int i = 0; i < n; ++i)
        curr.push_back(i);

    int ans = inf;
    vector<int> ans_v;
    do {
        const auto total_time = find_total_time(c, curr);
        if (total_time < ans) {
            ans = total_time;
            ans_v = curr;
        }
    } while (next_permutation(all(curr)));

    for (int i = 0; i < n; ++i)
        cout << "Place: " << i + 1 << ", worker: " << ans_v[i] + 1 << endl;

    return 0;
}
