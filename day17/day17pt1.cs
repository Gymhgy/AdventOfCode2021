var l = In.ReadToEnd().Replace("target area: x=","").Replace(", y=", "..").Split("..").Select(x=>int.Parse(x)).ToList();
//xmin,xmax,ymin,ymax
int q = l[0],w=l[1],e=l[2],r=l[3];
//at y=0 to reach ymin (lowest point in range) you need velocity of ymin
//if at t=0 we start with velocity v then we come back with velocity -v-1
var v = -e-1;
//Sum of 1..v to get max height
Print(v*(v+1)/2);