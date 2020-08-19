/*Begin Web Home*/

/**/
///*liveshow header*/
//var A=[],i=1,n=3;	
//function load(){
//	var j;	
//	for ( j = 1 ; j <= n ; j++){
//		A[j]=new Image();
//		A[j].src="images/liveshow/"+j+".jpg";
//	}
//}	
//function output(l){
//	document.getElementById("img_film").src=A[l].src;
//	document.getElementById("name").innerHTML=S[l];
//	//$(document).ready(function() {
//	//	$(#img_film).slideUp()			
//	//});
	
//}	
//function next(){
//	if(i<n){
//		i++;
//		output(i); 
//	}
//	else{
//		i=1;
//		output(i);
//	}
//}
//function back(){
//	if(i>1){
//		i--;
//		output(i); 
//	}
//	else{
//		i=n;
//		output(i); 
//	}
//}
//setInterval("next()",7000);
/*Danh sach tin tuc content*/
function chon(c){
	$(document).ready(function() {
		$("#tin_tuc li").css("background-color","#717171");
		if (c == 0 ){ 
			$(".hd").css("margin-left","0px");
			$("#tin_tuc li:eq(0)").css("background-color", "#cd2509");
		}
		else if (c == 1 ){ 
			$(".hd").css("margin-left","-430px");
			$("#tin_tuc li:eq(1)").css("background-color", "#cd2509");
		}
		else{ 
			$(".hd").css("margin-left","-860px");
			$("#tin_tuc li:eq(2)").css("background-color", "#cd2509");	
		}
	});
}
/*liveshow 4*/
var b=[],l=1,m=7,h=[];;
function load4(){
	var j;
	for (j=1;j<=m;j++){
		b[j]=new Image();
		b[j].src="Images/liveshow4/"+j+".jpg";
	}
	h[1]="Fast & Furious 7";
	h[2]="Hanamichi";
	h[3]="Thần Điêu Đại Hiệp";
	h[4]="X-MEN WOLVERINE";
	h[5]="Iron Man 7";
	h[6]="Naruto";
	h[7]="Spider Man 7";
}
function out(k){
	document.getElementById("f1").src=b[k].src;
	document.getElementById("h1").innerHTML=h[k];
	document.getElementById("f2").src=b[++k].src;
	document.getElementById("h2").innerHTML=h[k];
	document.getElementById("f3").src=b[++k].src;
	document.getElementById("h3").innerHTML=h[k];
	document.getElementById("f4").src=b[++k].src;
	document.getElementById("h4").innerHTML=h[k];
}
function next_footer(){
	if(l<m-3){	
		out(++l);
	}
}
function back_footer(){
	if(l>1){
		out(--l);
	}
}
/* End Web Home*/

/* Begin Web The_Loai */
	/* eq 0 */
    var ii = 0;
	$(document).ready(function() {
		$("#b1").click(function (){			
			if (ii == 0) {
					ii=-928;					
				}
			$("#t1").animate({
				marginLeft: ii +=232			
			},500)
		});
		$("#n1").click(function (){
			if (ii == -696) {
					ii=232;					
				}
			$("#t1").animate({
				marginLeft: ii -=232
			},700)
		});			
	});  
	/* eq 1 */
    var i1 = 0;
	$(document).ready(function() {
		$("#b2").click(function (){			
			if (i1 == 0) {
					i1=-928;					
				}
			$("#t2").animate({
				marginLeft: i1 +=232			
			},700)
		});
		$("#n2").click(function (){
			if (i1 == -696) {
					i1=232;					
				}
			$("#t2").animate({
				marginLeft: i1 -=232
			},700)
		});			
	});  
	var i2 = 0;
	/* eq 2 */
	$(document).ready(function() {
		$("#b3").click(function (){			
			if (i2 == 0) {
					i2=-928;					
				}
			$("#t3").animate({
				marginLeft: i2 +=232			
			},700)
		});
		$("#n3").click(function (){
			if (i2 == -696) {
					i2=232;					
				}
			$("#t3").animate({
				marginLeft: i2 -=232
			},700)
		});			
	});  
/* End Web The_Loai */

/*BEIGN Web Phim*/
var f=1;

	$(document).ready(function() {
		$(".play").click(function (){	
			if (f == 0) {
				document.pause.src="Images/Phim/pause.png";
				f = 1;
				var p = document.getElementById("film");
				p.pause();				
				var img = document.getElementById("img_pause");
				$("#img_pause").css("display","block");
				img.src="Images/Phim/pause.png";
			}
			else{
				document.pause.src="Images/Phim/play.png";
				f = 0;
				var p = document.getElementById("film");
				var img = document.getElementById("img_pause");
				$("#img_pause").css("display","none");
				p.play();
			}
		});	
	});	
/*END Web Phim*/
