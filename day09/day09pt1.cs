var l = In.ReadToEnd().Split("\n").Select(x => x.Select(y => y - 48).ToArray()).ToArray();
int sum = 0;
for(int i = 0; i < l.Length; i++) {
	for(int j = 0; j < l[0].Length; j++) {
		bool s = true;
		var v = l[i][j];
		try {
			if(v >= l[i-1][j])s=false;
		} catch{}
		try {
			if(v >= l[i][j-1])s=false;
		} catch{}
		try {
			if(v >= l[i+1][j])s=false;
		} catch{}
		try {
			if(v >= l[i][j+1])s=false;
		} catch{}
		if(s)sum+=v+1;
	}
}
Print(sum);