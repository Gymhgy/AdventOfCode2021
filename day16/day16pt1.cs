var l = string.Concat(In.ReadToEnd().Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
int i = 0;
int P(){
	var v = Convert.ToInt32(l[i..(i+=3)],2);
	var t = Convert.ToInt32(l[i..(i+=3)],2);

	if(t==4){
		for(; i < l.Length; i+=5){
			if(l[i]=='0'){i+=5;break;}
		}
		return v;
	}
	var d = l[i++];
	if(d == '0') {
		var e = Convert.ToInt32(l[i..(i+=15)],2);

		return v + T0(i+e);
	}
	if(d == '1') {
		var e = Convert.ToInt32(l[i..(i+=11)],2);
		return v + T1(e);
	}
	return v;
}
int T0(int e){
	int s = 0;
	while(i < e) {
		s += P();
	}
	return s;
}
int T1(int e){
	int i = 0, s = 0;
	for(; i < e; i++) {
		s += P();
	}
	return s;
}

Print(P());