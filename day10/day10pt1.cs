var l = In.ReadToEnd().Split("\n");
int p = 0;

int P(string a) {
	int i = 0;
	void J(char t){

		while(i < a.Length) {
			if(a[i] == t) {i++;return;}
			D();
		}
	}
	void D() {
		if("({[<".IndexOf(a[i]) is var d && d > -1) {
			i++;
			J(")}]>"[d]);
		}
		else throw new InvalidOperationException();
		
	}
	try{
		while(i<a.Length)
			D();
	}
	catch(InvalidOperationException){
		return new Dictionary<char, int>{{')', 3}, {']', 57}, {'}', 1197}, {'>',25137}}[a[i]];
	}
	return 0;
}
foreach(var s in l) {
	p+=P(s);

}
Print(p);