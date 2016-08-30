// JavaScript Document
function check(input)
{
	//gan thong bao cho thuoc tinh
	input.setCustomValidity('');
	//console.log(input.validity);//for debug
	if(input.validity.valid)//Neu khong co loi
	{
		return;		
	}
	if(input.getAttribute("error")!=null)//neu co thuoc tinh error
	{
		input.setCustomValidity(input.getAttribute("error"));
	}
	//thuoc tinh chua thong tin ve loi: input.validity
	//input.validity.valueMissing la loi nguoi dung k nhap du lieu
	else if(input.validity.valueMissing)
	{
		input.setCustomValidity(input.getAttribute("required-error"));
	}
	else if(input.validity.patternMismatch)//k dung dinh dang
	{
		input.setCustomValidity(input.getAttribute("pattern-error"));
	}
	else if(input.validity.customError)
	{
		input.setCustomValidity(input.getAttribute("pattern-error"));
	}
	else if(input.validity.rangeOverflow)//vuot gia tri cho phep
	{
		input.setCustomValidity(input.getAttribute("max-error"));
	}
	else if(input.validity.rangeUnderflow)//be hon gia tri cho phep
	{
		input.setCustomValidity(input.getAttribute("min-error"));
	}
	else if(input.validity.typeMismatch)//sai kieu
	{
		input.setCustomValidity(input.getAttribute("type-error"));
	}
	else if(input.validity.badInput)
	{
		input.setCustomValidity(input.getAttribute("input-error"));
	}
}

/*
function setCookie(name, value)
{
	document.cookie=name + "=" + escape(value) + "; expires=Tue, 30 May 2015 10:00:00 UTC";
	//alert(name+"="+value);
}
*/

//tao cookie
function fCreateCookie(){
	//lay ra checkbox ghi nho tai khoan mat khau
	var ckRemember= document.getElementById("ckRemember");
	//neu nguoi dung co danh dau checkbox
	if(ckRemember.checked){
		//lay ra tai khoan va mat khau do nguoi dung nhap vao
		var idValue=document.getElementById("txtId").value;
		var passValue=document.getElementById("txtPassword").value;		
		//ma hoa cac ki tu dac biet co trong tai khoan va mat khau
		idValue=escape(idValue);
		passValue=escape(passValue);
		//ghi cookies chua tai khoan va mat khau de dang nhap tu dong
		/*
		document.cookie="Id="+idValue+"; expires=Tue, 30-05-May-2015 10:00:00 GMT";
		document.cookie="Pass="+passValue+"; expires=Tue, 30-05-May-2015 10:00:00 GMT";
		*/
		document.cookie="Id="+idValue+"; expires=Tue, 30 June 2015 10:54:07 GMT";
		document.cookie="Pass="+passValue+"; expires=Tue, 30 June 2015 10:54:07 GMT";
		
		return;
	}
	//neu nguoi dung k chon Remember Me
	document.cookie="Id=";
	document.cookie="Pass=";
}

//doc cookie
function fReadCookie(){
	var aCookie=document.cookie.split("; ");
	var uId=aCookie[0];//lay ra value cua Id
	
	/*Neu gia tri cookie id khac rong*/
	if(uId.split('=')[1]!=null&&uId.split('=')[1]!=''){
		document.getElementById("ckRemember").checked=true;//tick checkBox
		for(i=0;i<=aCookie.length;i++)
		{
			//alert(aCookie[i]);
			var aCrumb=aCookie[i].split("="); 
			if("Id"==aCrumb[0]){
				document.getElementById("txtId").value=unescape(aCrumb[1]);//lay ra email tai khoan
			}
			else if("Pass"==aCrumb[0]){
				document.getElementById("txtPassword").value=unescape(aCrumb[1]);//lay ra mat khau					
			}
		}
		return;
	}
	//Neu khong tim duoc cookie yeu cau
	document.getElementById("ckRemember").checked=false;//bo tick checkBox
}
	
	//Su kien noi dung da nap DOMContentLoaded (trang web da hinh thanh)
	document.addEventListener("DOMContentLoaded",function(){
	//chon tat ca cac the input co trong trang
	var inputs= document.querySelectorAll("input");
	for(i=0;i<=inputs.length;i++)
	{
		inputs[i].addEventListener("invalid",function(){
			check(this);//this chinh la input[i]
			});
		
		inputs[i].addEventListener("input",function(){
			check(this);//this chinh la input[i]
			});
	}
});

