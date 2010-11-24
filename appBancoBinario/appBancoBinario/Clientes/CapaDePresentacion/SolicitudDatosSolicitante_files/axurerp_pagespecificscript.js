
var PageName = 'Solicitud de Préstamo Personal - Datos del Solicitante';
var PageId = 'p1a75c977ee264bf09a2977ffeae402fe'
var PageUrl = 'SolicitudDatosSolicitante.aspx'


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

var u109 = document.getElementById('u109');

u109.style.cursor = 'pointer';
if (bIE) u109.attachEvent("onclick", Clicku109);
else u109.addEventListener("click", Clicku109, true);
function Clicku109(e)
{

if (true) {

	self.location.href="PIN_de_Tarjetas.aspx" + GetQuerystring();

}

}
gv_vAlignTable['u109'] = 'top';
var u86 = document.getElementById('u86');

var u54 = document.getElementById('u54');
gv_vAlignTable['u54'] = 'top';
var u60 = document.getElementById('u60');
gv_vAlignTable['u60'] = 'top';
var u29 = document.getElementById('u29');

u29.style.cursor = 'pointer';
if (bIE) u29.attachEvent("onclick", Clicku29);
else u29.addEventListener("click", Clicku29, true);
function Clicku29(e)
{

if (true) {

	self.location.href="#" + GetQuerystring();

}

}
gv_vAlignTable['u29'] = 'top';
var u115 = document.getElementById('u115');

u115.style.cursor = 'pointer';
if (bIE) u115.attachEvent("onclick", Clicku115);
else u115.addEventListener("click", Clicku115, true);
function Clicku115(e)
{

if (true) {

	self.location.href="Productos/Productos.aspx" + GetQuerystring();

}

}
gv_vAlignTable['u115'] = 'top';
var u102 = document.getElementById('u102');

u102.style.cursor = 'pointer';
if (bIE) u102.attachEvent("onclick", Clicku102);
else u102.addEventListener("click", Clicku102, true);
function Clicku102(e)
{

if (true) {

	self.location.href="Clientes.aspx" + GetQuerystring();

}

}

var u104 = document.getElementById('u104');

u104.style.cursor = 'pointer';
if (bIE) u104.attachEvent("onclick", Clicku104);
else u104.addEventListener("click", Clicku104, true);
function Clicku104(e)
{

if (true) {

	self.location.href="Plataforma.aspx" + GetQuerystring();

}

}

var u45 = document.getElementById('u45');

var u83 = document.getElementById('u83');
gv_vAlignTable['u83'] = 'center';
var u51 = document.getElementById('u51');
gv_vAlignTable['u51'] = 'top';
var u96 = document.getElementById('u96');

var u79 = document.getElementById('u79');
gv_vAlignTable['u79'] = 'top';
var u42 = document.getElementById('u42');
gv_vAlignTable['u42'] = 'top';
var u80 = document.getElementById('u80');

var u26 = document.getElementById('u26');

var u106 = document.getElementById('u106');

u106.style.cursor = 'pointer';
if (bIE) u106.attachEvent("onclick", Clicku106);
else u106.addEventListener("click", Clicku106, true);
function Clicku106(e)
{

if (true) {

	self.location.href="Caja.aspx" + GetQuerystring();

}

}

var u99 = document.getElementById('u99');
gv_vAlignTable['u99'] = 'top';
var u5 = document.getElementById('u5');
gv_vAlignTable['u5'] = 'center';
var u23 = document.getElementById('u23');
gv_vAlignTable['u23'] = 'top';
var u76 = document.getElementById('u76');
gv_vAlignTable['u76'] = 'top';
var u110 = document.getElementById('u110');

u110.style.cursor = 'pointer';
if (bIE) u110.attachEvent("onclick", Clicku110);
else u110.addEventListener("click", Clicku110, true);
function Clicku110(e)
{

if (true) {

	self.location.href=".aspx" + GetQuerystring();

}

}
gv_vAlignTable['u110'] = 'top';
var u14 = document.getElementById('u14');
gv_vAlignTable['u14'] = 'top';
var u67 = document.getElementById('u67');
gv_vAlignTable['u67'] = 'top';
var u20 = document.getElementById('u20');
gv_vAlignTable['u20'] = 'center';
var u73 = document.getElementById('u73');

var u48 = document.getElementById('u48');
gv_vAlignTable['u48'] = 'top';
var u4 = document.getElementById('u4');

var u11 = document.getElementById('u11');
gv_vAlignTable['u11'] = 'center';
var u64 = document.getElementById('u64');
gv_vAlignTable['u64'] = 'top';
var u70 = document.getElementById('u70');
gv_vAlignTable['u70'] = 'center';
var u39 = document.getElementById('u39');

var u119 = document.getElementById('u119');

var u87 = document.getElementById('u87');
gv_vAlignTable['u87'] = 'center';
var u55 = document.getElementById('u55');

var u93 = document.getElementById('u93');
gv_vAlignTable['u93'] = 'center';
var u61 = document.getElementById('u61');

var u116 = document.getElementById('u116');
gv_vAlignTable['u116'] = 'top';
var u103 = document.getElementById('u103');
gv_vAlignTable['u103'] = 'top';
var u107 = document.getElementById('u107');
gv_vAlignTable['u107'] = 'top';
var u84 = document.getElementById('u84');

var u52 = document.getElementById('u52');

var u90 = document.getElementById('u90');

var u36 = document.getElementById('u36');
gv_vAlignTable['u36'] = 'center';
var u89 = document.getElementById('u89');
gv_vAlignTable['u89'] = 'center';
var u81 = document.getElementById('u81');
gv_vAlignTable['u81'] = 'center';
var u27 = document.getElementById('u27');
gv_vAlignTable['u27'] = 'center';

var u101 = document.getElementById('u101');
gv_vAlignTable['u101'] = 'top';
var u0 = document.getElementById('u0');

var u24 = document.getElementById('u24');
gv_vAlignTable['u24'] = 'top';
var u77 = document.getElementById('u77');
gv_vAlignTable['u77'] = 'top';
var u30 = document.getElementById('u30');
gv_vAlignTable['u30'] = 'top';
var u100 = document.getElementById('u100');

u100.style.cursor = 'pointer';
if (bIE) u100.attachEvent("onclick", Clicku100);
else u100.addEventListener("click", Clicku100, true);
function Clicku100(e)
{

if (true) {

	self.location.href="Conf.___Param.aspx" + GetQuerystring();

}

}

var u58 = document.getElementById('u58');
gv_vAlignTable['u58'] = 'top';
var u15 = document.getElementById('u15');

var u21 = document.getElementById('u21');
gv_vAlignTable['u21'] = 'top';
var u74 = document.getElementById('u74');
gv_vAlignTable['u74'] = 'center';
var u49 = document.getElementById('u49');

var u12 = document.getElementById('u12');

var u65 = document.getElementById('u65');
gv_vAlignTable['u65'] = 'top';
var u71 = document.getElementById('u71');

var u94 = document.getElementById('u94');

var u62 = document.getElementById('u62');

var u46 = document.getElementById('u46');
gv_vAlignTable['u46'] = 'top';

var u85 = document.getElementById('u85');
gv_vAlignTable['u85'] = 'center';
var u91 = document.getElementById('u91');
gv_vAlignTable['u91'] = 'center';
var u37 = document.getElementById('u37');

var u43 = document.getElementById('u43');

var u17 = document.getElementById('u17');
gv_vAlignTable['u17'] = 'top';
var u18 = document.getElementById('u18');
gv_vAlignTable['u18'] = 'top';
var u82 = document.getElementById('u82');

var u1 = document.getElementById('u1');
gv_vAlignTable['u1'] = 'center';
var u34 = document.getElementById('u34');
gv_vAlignTable['u34'] = 'center';
var u40 = document.getElementById('u40');
gv_vAlignTable['u40'] = 'center';
var u68 = document.getElementById('u68');

var u25 = document.getElementById('u25');

var u31 = document.getElementById('u31');
gv_vAlignTable['u31'] = 'top';
var u97 = document.getElementById('u97');

var u59 = document.getElementById('u59');

var u22 = document.getElementById('u22');
gv_vAlignTable['u22'] = 'top';
var u75 = document.getElementById('u75');

var u88 = document.getElementById('u88');

var u8 = document.getElementById('u8');

var u112 = document.getElementById('u112');
gv_vAlignTable['u112'] = 'top';
var u72 = document.getElementById('u72');
gv_vAlignTable['u72'] = 'center';
var u56 = document.getElementById('u56');
gv_vAlignTable['u56'] = 'top';
var u95 = document.getElementById('u95');
gv_vAlignTable['u95'] = 'center';
var u108 = document.getElementById('u108');

u108.style.cursor = 'pointer';
if (bIE) u108.attachEvent("onclick", Clicku108);
else u108.addEventListener("click", Clicku108, true);
function Clicku108(e)
{

if (true) {

	self.location.href="Solicitudes/Solicitudes.aspx" + GetQuerystring();

}

}
gv_vAlignTable['u108'] = 'top';
var u113 = document.getElementById('u113');

u113.style.cursor = 'pointer';
if (bIE) u113.attachEvent("onclick", Clicku113);
else u113.addEventListener("click", Clicku113, true);
function Clicku113(e)
{

if (true) {

	self.location.href="Calculadora_de_Préstamos.aspx" + GetQuerystring();

}

}
gv_vAlignTable['u113'] = 'top';
var u47 = document.getElementById('u47');

var u53 = document.getElementById('u53');
gv_vAlignTable['u53'] = 'top';
var u114 = document.getElementById('u114');
gv_vAlignTable['u114'] = 'top';
var u28 = document.getElementById('u28');

u28.style.cursor = 'pointer';
if (bIE) u28.attachEvent("onclick", Clicku28);
else u28.addEventListener("click", Clicku28, true);
function Clicku28(e)
{

if (true) {

	self.location.href="Plataforma.aspx" + GetQuerystring();

}

}
gv_vAlignTable['u28'] = 'top';
var u92 = document.getElementById('u92');

var u2 = document.getElementById('u2');

var u44 = document.getElementById('u44');
gv_vAlignTable['u44'] = 'top';
var u50 = document.getElementById('u50');
gv_vAlignTable['u50'] = 'top';
var u19 = document.getElementById('u19');

var u78 = document.getElementById('u78');
gv_vAlignTable['u78'] = 'top';
var u7 = document.getElementById('u7');
gv_vAlignTable['u7'] = 'center';
var u41 = document.getElementById('u41');

var u111 = document.getElementById('u111');
gv_vAlignTable['u111'] = 'top';

var u32 = document.getElementById('u32');
gv_vAlignTable['u32'] = 'top';
var u16 = document.getElementById('u16');
gv_vAlignTable['u16'] = 'center';
var u98 = document.getElementById('u98');

u98.style.cursor = 'pointer';
if (bIE) u98.attachEvent("onclick", Clicku98);
else u98.addEventListener("click", Clicku98, true);
function Clicku98(e)
{

if (true) {

	self.location.href="Inicio.aspx" + GetQuerystring();

}

}

var u9 = document.getElementById('u9');
gv_vAlignTable['u9'] = 'top';
var u13 = document.getElementById('u13');
gv_vAlignTable['u13'] = 'center';
var u66 = document.getElementById('u66');

var u105 = document.getElementById('u105');
gv_vAlignTable['u105'] = 'top';
var u6 = document.getElementById('u6');

var u35 = document.getElementById('u35');

var u57 = document.getElementById('u57');

var u10 = document.getElementById('u10');

var u63 = document.getElementById('u63');

var u38 = document.getElementById('u38');
gv_vAlignTable['u38'] = 'center';
var u118 = document.getElementById('u118');
gv_vAlignTable['u118'] = 'center';
var u3 = document.getElementById('u3');
gv_vAlignTable['u3'] = 'center';
if (window.OnLoad) OnLoad();
