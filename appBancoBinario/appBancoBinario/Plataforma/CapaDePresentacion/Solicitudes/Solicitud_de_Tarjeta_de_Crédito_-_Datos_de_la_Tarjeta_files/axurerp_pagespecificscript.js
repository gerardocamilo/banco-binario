
var PageName = 'Solicitud de Tarjeta de Crédito - Datos del Producto';
var PageId = 'p4dcf4e6999374f1092402de546b9edc6'
var PageUrl = 'Solicitud_de_Tarjeta_de_Crédito_-_Datos_de_la_Tarjeta.html'
document.title = 'Solicitud de Tarjeta de Crédito - Datos del Producto';

if (top.location != self.location)
{
	if (parent.HandleMainFrameChanged) {
		parent.HandleMainFrameChanged();
	}
}

var $OnLoadVariable = '';

var $CSUM;

var hasQuery = false;
var query = window.location.hash.substring(1);
if (query.length > 0) hasQuery = true;
var vars = query.split("&");
for (var i = 0; i < vars.length; i++) {
    var pair = vars[i].split("=");
    if (pair[0].length > 0) eval("$" + pair[0] + " = decodeURIComponent(pair[1]);");
} 

if (hasQuery && $CSUM != 1) {
alert('Prototype Warning: The variable values were too long to pass to this page.\nIf you are using IE, using Firefox will support more data.');
}

function GetQuerystring() {
    return '#OnLoadVariable=' + encodeURIComponent($OnLoadVariable) + '&CSUM=1';
}

function PopulateVariables(value) {
  value = value.replace(/\[\[OnLoadVariable\]\]/g, $OnLoadVariable);
  value = value.replace(/\[\[PageName\]\]/g, PageName);
  return value;
}

function OnLoad(e) {

}

var u86 = document.getElementById('u86');

u86.style.cursor = 'pointer';
if (bIE) u86.attachEvent("onclick", Clicku86);
else u86.addEventListener("click", Clicku86, true);
function Clicku86(e)
{

if (true) {

	self.location.href="Solicitudes/Solicitudes.aspx" + GetQuerystring();

}

}
gv_vAlignTable['u86'] = 'top';
var u54 = document.getElementById('u54');
gv_vAlignTable['u54'] = 'center';
var u60 = document.getElementById('u60');
gv_vAlignTable['u60'] = 'top';
var u29 = document.getElementById('u29');
gv_vAlignTable['u29'] = 'top';
var u45 = document.getElementById('u45');
gv_vAlignTable['u45'] = 'center';
var u83 = document.getElementById('u83');
gv_vAlignTable['u83'] = 'center';
var u51 = document.getElementById('u51');

var u79 = document.getElementById('u79');
gv_vAlignTable['u79'] = 'center';
var u42 = document.getElementById('u42');

var u80 = document.getElementById('u80');

var u26 = document.getElementById('u26');

var u5 = document.getElementById('u5');
gv_vAlignTable['u5'] = 'center';
var u23 = document.getElementById('u23');
gv_vAlignTable['u23'] = 'top';
var u76 = document.getElementById('u76');

u76.style.cursor = 'pointer';
if (bIE) u76.attachEvent("onclick", Clicku76);
else u76.addEventListener("click", Clicku76, true);
function Clicku76(e)
{

if (true) {

	self.location.href="../Plataforma.aspx" + GetQuerystring();

}

}
gv_vAlignTable['u76'] = 'top';
var u14 = document.getElementById('u14');
gv_vAlignTable['u14'] = 'top';
var u67 = document.getElementById('u67');
gv_vAlignTable['u67'] = 'top';
var u20 = document.getElementById('u20');
gv_vAlignTable['u20'] = 'center';
var u73 = document.getElementById('u73');
gv_vAlignTable['u73'] = 'top';
var u48 = document.getElementById('u48');
gv_vAlignTable['u48'] = 'top';
var u4 = document.getElementById('u4');

var u11 = document.getElementById('u11');
gv_vAlignTable['u11'] = 'center';
var u64 = document.getElementById('u64');

var u70 = document.getElementById('u70');

u70.style.cursor = 'pointer';
if (bIE) u70.attachEvent("onclick", Clicku70);
else u70.addEventListener("click", Clicku70, true);
function Clicku70(e)
{

if (true) {

	self.location.href="Clientes.aspx" + GetQuerystring();

}

}

var u39 = document.getElementById('u39');
gv_vAlignTable['u39'] = 'center';
//var u87 = document.getElementById('u87');

//u87.style.cursor = 'pointer';
//if (bIE) u87.attachEvent("onclick", Clicku87);
//else u87.addEventListener("click", Clicku87, true);
//function Clicku87(e)
//{

//if (true) {

//	self.location.href="PIN_de_Tarjetas.html" + GetQuerystring();

//}

//}
gv_vAlignTable['u87'] = 'top';
var u55 = document.getElementById('u55');

var u93 = document.getElementById('u93');

u93.style.cursor = 'pointer';
if (bIE) u93.attachEvent("onclick", Clicku93);
else u93.addEventListener("click", Clicku93, true);
function Clicku93(e)
{

if (true) {

	self.location.href="Productos/Productos.aspx" + GetQuerystring();

}

}
gv_vAlignTable['u93'] = 'top';
var u61 = document.getElementById('u61');
gv_vAlignTable['u61'] = 'top';
var u84 = document.getElementById('u84');

var u52 = document.getElementById('u52');
gv_vAlignTable['u52'] = 'center';
var u90 = document.getElementById('u90');
gv_vAlignTable['u90'] = 'top';
//var u36 = document.getElementById('u36');

//u36.style.cursor = 'pointer';
//if (bIE) u36.attachEvent("onclick", Clicku36);
//else u36.addEventListener("click", Clicku36, true);
//function Clicku36(e)
//{

//if (true) {

//	self.location.href="Solicitud_de_Tarjeta_de_Crédito_-_Datos_Laborales.html" + GetQuerystring();

//}

//}

var u89 = document.getElementById('u89');
gv_vAlignTable['u89'] = 'top';
var u81 = document.getElementById('u81');
gv_vAlignTable['u81'] = 'center';
var u27 = document.getElementById('u27');
gv_vAlignTable['u27'] = 'center';
var u33 = document.getElementById('u33');
gv_vAlignTable['u33'] = 'center';
var u0 = document.getElementById('u0');

var u24 = document.getElementById('u24');
gv_vAlignTable['u24'] = 'top';
var u77 = document.getElementById('u77');

u77.style.cursor = 'pointer';
if (bIE) u77.attachEvent("onclick", Clicku77);
else u77.addEventListener("click", Clicku77, true);
function Clicku77(e)
{

if (true) {

	self.location.href="../Solicitudes/Solicitudes.aspx" + GetQuerystring();

}

}
gv_vAlignTable['u77'] = 'top';
//var u30 = document.getElementById('u30');

//u30.style.cursor = 'pointer';
//if (bIE) u30.attachEvent("onclick", Clicku30);
//else u30.addEventListener("click", Clicku30, true);
//function Clicku30(e)
//{

//if (true) {

//	self.location.href="Plataforma.aspx" + GetQuerystring();

//}

//}

var u58 = document.getElementById('u58');

var u15 = document.getElementById('u15');

var u21 = document.getElementById('u21');
gv_vAlignTable['u21'] = 'top';
var u74 = document.getElementById('u74');

u74.style.cursor = 'pointer';
if (bIE) u74.attachEvent("onclick", Clicku74);
else u74.addEventListener("click", Clicku74, true);
function Clicku74(e)
{

if (true) {

	self.location.href="Caja.aspx" + GetQuerystring();

}

}

var u49 = document.getElementById('u49');
gv_vAlignTable['u49'] = 'top';
var u12 = document.getElementById('u12');

var u65 = document.getElementById('u65');

var u71 = document.getElementById('u71');
gv_vAlignTable['u71'] = 'top';
var u94 = document.getElementById('u94');
gv_vAlignTable['u94'] = 'top';
var u62 = document.getElementById('u62');
gv_vAlignTable['u62'] = 'top';
var u46 = document.getElementById('u46');

var u85 = document.getElementById('u85');
gv_vAlignTable['u85'] = 'center';
var u91 = document.getElementById('u91');

u91.style.cursor = 'pointer';
if (bIE) u91.attachEvent("onclick", Clicku91);
else u91.addEventListener("click", Clicku91, true);
function Clicku91(e)
{

if (true) {

	self.location.href="Calculadora_de_Préstamos.html" + GetQuerystring();

}

}
gv_vAlignTable['u91'] = 'top';
var u37 = document.getElementById('u37');
gv_vAlignTable['u37'] = 'center';
var u43 = document.getElementById('u43');
gv_vAlignTable['u43'] = 'center';
var u17 = document.getElementById('u17');
gv_vAlignTable['u17'] = 'top';
var u18 = document.getElementById('u18');
gv_vAlignTable['u18'] = 'top';
var u82 = document.getElementById('u82');

var u1 = document.getElementById('u1');
gv_vAlignTable['u1'] = 'center';
var u34 = document.getElementById('u34');

//var u40 = document.getElementById('u40');

//u40.style.cursor = 'pointer';
//if (bIE) u40.attachEvent("onclick", Clicku40);
//else u40.addEventListener("click", Clicku40, true);
//function Clicku40(e)
//{

//if (true) {

//	self.location.href="Solicitud_de_Tarjeta_de_Crédito_-_Confirmación.html" + GetQuerystring();

//}

//}

var u68 = document.getElementById('u68');

u68.style.cursor = 'pointer';
if (bIE) u68.attachEvent("onclick", Clicku68);
else u68.addEventListener("click", Clicku68, true);
function Clicku68(e)
{

if (true) {

	self.location.href="Conf.___Param.aspx" + GetQuerystring();

}

}

var u25 = document.getElementById('u25');

var u31 = document.getElementById('u31');
gv_vAlignTable['u31'] = 'center';
var u59 = document.getElementById('u59');

var u22 = document.getElementById('u22');
gv_vAlignTable['u22'] = 'top';
var u75 = document.getElementById('u75');
gv_vAlignTable['u75'] = 'top';
var u88 = document.getElementById('u88');

u88.style.cursor = 'pointer';
if (bIE) u88.attachEvent("onclick", Clicku88);
else u88.addEventListener("click", Clicku88, true);
function Clicku88(e)
{

if (true) {

	self.location.href="Repoetes.aspx" + GetQuerystring();

}

}
gv_vAlignTable['u88'] = 'top';
var u8 = document.getElementById('u8');

var u72 = document.getElementById('u72');

u72.style.cursor = 'pointer';
if (bIE) u72.attachEvent("onclick", Clicku72);
else u72.addEventListener("click", Clicku72, true);
function Clicku72(e)
{

if (true) {

	self.location.href="Plataforma.aspx" + GetQuerystring();

}

}

var u56 = document.getElementById('u56');
gv_vAlignTable['u56'] = 'center';
var u47 = document.getElementById('u47');
gv_vAlignTable['u47'] = 'top';
var u53 = document.getElementById('u53');

var u28 = document.getElementById('u28');
gv_vAlignTable['u28'] = 'top';
var u92 = document.getElementById('u92');
gv_vAlignTable['u92'] = 'top';
var u2 = document.getElementById('u2');

var u44 = document.getElementById('u44');

var u50 = document.getElementById('u50');
gv_vAlignTable['u50'] = 'top';
var u19 = document.getElementById('u19');

var u78 = document.getElementById('u78');

var u7 = document.getElementById('u7');
gv_vAlignTable['u7'] = 'center';
var u41 = document.getElementById('u41');
gv_vAlignTable['u41'] = 'center';
var u69 = document.getElementById('u69');
gv_vAlignTable['u69'] = 'top';
var u32 = document.getElementById('u32');

var u16 = document.getElementById('u16');
gv_vAlignTable['u16'] = 'center';
var u9 = document.getElementById('u9');
gv_vAlignTable['u9'] = 'top';
var u13 = document.getElementById('u13');
gv_vAlignTable['u13'] = 'center';
var u66 = document.getElementById('u66');

u66.style.cursor = 'pointer';
if (bIE) u66.attachEvent("onclick", Clicku66);
else u66.addEventListener("click", Clicku66, true);
function Clicku66(e)
{

if (true) {

	self.location.href="../../../Inicio.aspx" + GetQuerystring();

}

}

var u6 = document.getElementById('u6');

var u35 = document.getElementById('u35');
gv_vAlignTable['u35'] = 'center';
var u57 = document.getElementById('u57');

var u10 = document.getElementById('u10');

var u63 = document.getElementById('u63');
gv_vAlignTable['u63'] = 'top';
var u38 = document.getElementById('u38');

var u3 = document.getElementById('u3');
gv_vAlignTable['u3'] = 'center';
if (window.OnLoad) OnLoad();
