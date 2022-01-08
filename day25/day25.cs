var q = In.ReadToEnd().Split();
int h = q.Length, w = q[0].Length;
byte[,] s = new byte[h, w];
for(int i = 0; i < h; i++) {
	for(int j = 0; j < w; j++) {
		if(q[i][j] == '.') s[i,j] = 0;
		if(q[i][j] == '>') s[i,j] = 1;
		if(q[i][j] == 'v') s[i,j] = 2;
	}
}
bool moved = false;
int e = 0;

do {
	moved = false;
	byte[,] k = new byte[h, w], t = new byte[h,w];
	Array.Copy(s,t,h*w);
	e++;
	for(int i = 0; i < h; i++) {
		for(int j = 0; j < w; j++) {
			if(s[i,j] == 1 && s[i,(j+1)%w] == 0) {
				k[i,(j+1)%w]=1;
				moved = true;
			}
			else if(s[i,j] == 1) k[i,j] = 1;
			else if(s[i,j] == 2) k[i,j] = 2;

		}
	}
	Array.Copy(k, s, w*h);

	for(int i = 0; i < h; i++) {
		for(int j = 0; j < w; j++) {
			if(s[i,j] == 2 && s[(i+1)%h,j] == 0) {
				k[i,j] = 0;
				k[(i+1)%h,j]=2;
				moved = true;
			}
			else if(s[i,j] == 2) k[i,j] = 2;
		}
	}
	Array.Copy(k, s, w*h);
} while(moved);
Print(e);