var l = string.Concat(In.ReadToEnd().Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
int i = 0;
long P(){
	var v = Convert.ToInt64(l[i..(i+=3)],2);
	var t = Convert.ToInt64(l[i..(i+=3)],2);

	if(t==4){
		long r = 0;
		for(; i < l.Length; i+=5){
			r <<= 4;
			r += Convert.ToInt32(l[(i+1)..(i+5)],2);
			if(l[i]=='0'){i+=5;break;}
		}
		return r;
	}
	var d = l[i++];
	List<long> s = default;
	if(d == '0') {
		var e = Convert.ToInt32(l[i..(i+=15)],2);
		s = T0(i+e);
	}
	if(d == '1') {
		var e = Convert.ToInt32(l[i..(i+=11)],2);
		s = T1(e);
	}
	if(t == 0)return s.Sum();
	if(t == 1)return s.Aggregate(1l, (a,b) => a*b);
	if(t == 2)return s.Min();
	if(t == 3)return s.Max();
	if(t == 5)return s[0]>s[1]?1:0;
	if(t == 6)return s[0]<s[1]?1:0;
	if(t == 7)return s[0]==s[1]?1:0;
	return 0;
}
List<long> T0(int e){
	List<long> s = new List<long>();
	while(i < e) {
		s.Add(P());
	}
	return s;
}
List<long> T1(int e){
	int i = 0;
	List<long> s = new List<long>();
	for(; i < e; i++) {
		s.Add(P());
	}
	return s;
}

Print(P());