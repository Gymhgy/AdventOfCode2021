using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

string input = @"#############
#...........#
###D#B#B#A###
  #D#C#B#A#
  #D#B#A#C#
  #C#C#D#A#
  #########";

//A=1,B=2,C=3,D=4

var l = Regex.Matches(input, @"\w").Select(x => x.Value[0] - 64).ToArray();
var R = new int[27];
l.CopyTo(R, 11);
//1-indexing, 0 is for empty cell
var E = new int[] { 0, 1, 10, 100, 1000 };
var N = new int[] { 0, 2, 4, 6, 8 };
var H = new[] { 0, 1, 3, 5, 7, 9, 10 };
var T = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4 };

PriorityQueue<(int, int[]), int> q = new();
q.Enqueue((0, R), 0);
Dictionary<int[], int> s = new(new MyEqualityComparer());
s[R] = 0;
while (q.Count > 0) {
	var (i, c) = q.Dequeue();
	if (Array.Equals(c, T)) break;
	if (i != s[c]) continue;
	foreach (var ((f, t), d) in G(c)) {
		var o = new int[27];
		Array.Copy(c, o, 27);
		(o[f], o[t]) = (o[t], o[f]);
		int score = s[c] + d;

		if (score < s.GetValueOrDefault(o, int.MaxValue)) {
			s[o] = score; q.Enqueue((score, o), score);
		}
	}
}

Console.WriteLine(s[T]);
var j = T;

List<((int, int), int)> G(int[] c) {
	List<((int, int), int)> m = new();
	foreach (var i in H) {
		if (c[i] == 0) continue;
		//Check can enter room
		if (c[c[i] + 10] == 0) {
			int t = c[i] + 10;
			if (!((c[t + 4] == 0 || c[t + 4] == c[i]) && (c[t + 8] == 0 || c[t + 8] == c[i]) && (c[t + 12] == 0 || c[t + 12] == c[i]))) continue;
			if (c[t + 4] == 0) { t += 4; if (c[t + 4] == 0) { t += 4; if (c[t + 4] == 0) { t += 4; } } }
			int e = N[c[i]];
			if (Enumerable.Range(Math.Min(i, e), Math.Abs(i - e) + 1).Any(x => x != i && c[x] != 0)) continue;

			m.Add(((i, t), D(i, t) * E[c[i]]));
		}
	}

	//Go through all rooms
	for (int d = 1; d <= 4; d++) {
		List<int> a = new();
		int i = 10 + d;
		for (; i < c.Length; i += 4) {
			if (c[i] != 0) a.Add(i);
		}
		if (a.Count == 0 || a.All(x => c[x] == d)) continue;
		i = a[0];
		var s = S(i);

		foreach (var j in H) {
			if (Enumerable.Range(Math.Min(s, j), Math.Abs(s - j) + 1).Any(x => c[x] != 0)) continue;
			m.Add(((i, j), D(i, j) * E[c[i]]));
		}

	}

	return m;
}

int S(int x) => N[(x - 11) % 4 + 1];

int D(int a, int b) {
	int r = 0;
	if (a > 10) { r += (a - 11) / 4 + 1; a = S(a); }
	if (b > 10) { r += (b - 11) / 4 + 1; b = S(b); }

	return r + Math.Abs(a - b);
}

public class MyEqualityComparer : IEqualityComparer<int[]> {
	public bool Equals(int[] x, int[] y) {
		if (x.Length != y.Length) {
			return false;
		}
		for (int i = 0; i < x.Length; i++) {
			if (x[i] != y[i]) {
				return false;
			}
		}
		return true;
	}

	public int GetHashCode(int[] obj) {
		int result = 17;
		for (int i = 0; i < obj.Length; i++) {
			unchecked {
				result = result * 23 + obj[i];
			}
		}
		return result;
	}
}