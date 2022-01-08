var l=In.ReadToEnd().Split("\n\n");
var a = l[0].Replace("\n","");
var m = l[1].Split("\n");
var o = new int[m.Length + 51 * 2, m[0].Length + 51 * 2];
for(int i = 51; i < o.GetLength(0) - 51; i++)
	for(int j = 51; j < o.GetLength(1) - 51; j++)
		o[i,j] = m[i-51][j-51] == '#' ? 1 : 0;

int b = 0;
for(int t = 50; t>0; t--) {
	b = 0;
	var k = new int[m.Length + 51 * 2, m[0].Length + 51 * 2];
	for(int i = 0; i < o.GetLength(0); i++)
		for(int j = 0; j < o.GetLength(1); j++) {
			if(i<t||i>=o.GetLength(0)-t||j<t||j>=o.GetLength(1)-t){k[i,j]=a[Convert.ToInt32(new string((char)(o[i,j]+48), 9),2)]=='#'?1:0;continue;}
			var r = "";
			for(int x = -1; x <= 1; x++)
				for(int y = -1; y <= 1; y++) {
					r += o[i+x,j+y];
				}

			k[i,j] = a[Convert.ToInt32(r,2)] == '#' ? 1 : 0;
			b += k[i,j];
		}
	o = k;
}
b=0;
for(int i = 0; i < o.GetLength(0); i++)
	for(int j = 0; j < o.GetLength(1); j++)
		b+=o[i,j];
Print(b);