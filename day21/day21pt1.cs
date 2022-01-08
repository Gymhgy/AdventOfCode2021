var l = In.ReadToEnd().Split("\n");
var a = l[0][^1] - 48;
var b = l[1][^1] - 48;

int d = 0;
int c = 2;
int sa = 0, sb = 0;
while(sa < 1000 && sb < 1000) {
	d++;
	if(d%2==1){a = (a + c*3 - 1)%10 + 1;sa+=a;}
	if(d%2==0){b = (b + c*3 - 1)%10 + 1;sb+=b;}

	c = (c+2)%100+1;

}

Print(d * 3 * Math.Min(sa,sb));