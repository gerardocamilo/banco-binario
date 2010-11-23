
var PageName = 'Productos';
var PageId = 'pd82483ccefc84f6b8bbb2f19beee3420'
var PageUrl = 'Productos.aspx'
document.title = 'Productos';

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

var u62 = document.getElementById('u62');
gv_vAlignTable['u62'] = 'center';
var u45 = document.getElementById('u45');
gv_vAlignTable['u45'] = 'top';
var u28 = document.getElementById('u28');

u28.style.cursor = 'pointer';
if (bIE) u28.attachEvent("onclick", Clicku28);
else u28.addEventListener("click", Clicku28, true);
function Clicku28(e)
{

if (true) {

	self.location.href="../Plataforma.aspx" + GetQuerystring();

}

}
gv_vAlignTable['u28'] = 'top';
var u142 = document.getElementById('u142');

var u59 = document.getElementById('u59');

var u71 = document.getElementById('u71');
gv_vAlignTable['u71'] = 'top';
var u93 = document.getElementById('u93');
gv_vAlignTable['u93'] = 'top';
var u12 = document.getElementById('u12');

var u73 = document.getElementById('u73');
u73.style.cursor = 'pointer';
if (bIE) u73.attachEvent("onclick", Clicku73);
else u73.addEventListener("click", Clicku73, true);
function Clicku73(e) {

    if (true) {

        self.location.href = "Productos.aspx" + GetQuerystring();

    }

}
gv_vAlignTable['u73'] = 'top';
var u112 = document.getElementById('u112');

var u128 = document.getElementById('u128');

var u56 = document.getElementById('u56');

var u161 = document.getElementById('u161');

var u91 = document.getElementById('u91');
gv_vAlignTable['u91'] = 'top';
var u173 = document.getElementById('u173');
gv_vAlignTable['u173'] = 'top';
var u90 = document.getElementById('u90');

var u40 = document.getElementById('u40');

var u163 = document.getElementById('u163');
gv_vAlignTable['u163'] = 'center';
var u23 = document.getElementById('u23');
gv_vAlignTable['u23'] = 'top';
var u147 = document.getElementById('u147');
gv_vAlignTable['u147'] = 'top';
var u88 = document.getElementById('u88');

var u130 = document.getElementById('u130');

var u108 = document.getElementById('u108');

var u54 = document.getElementById('u54');

var u100 = document.getElementById('u100');

var u37 = document.getElementById('u37');
gv_vAlignTable['u37'] = 'top';
var u3 = document.getElementById('u3');
gv_vAlignTable['u3'] = 'center';
var u105 = document.getElementById('u105');
gv_vAlignTable['u105'] = 'top';
var u68 = document.getElementById('u68');

var u159 = document.getElementById('u159');
gv_vAlignTable['u159'] = 'center';
var u21 = document.getElementById('u21');
gv_vAlignTable['u21'] = 'top';
var u113 = document.getElementById('u113');
gv_vAlignTable['u113'] = 'top';
var u129 = document.getElementById('u129');
gv_vAlignTable['u129'] = 'top';
var u156 = document.getElementById('u156');
gv_vAlignTable['u156'] = 'center';
var u35 = document.getElementById('u35');

var u18 = document.getElementById('u18');
gv_vAlignTable['u18'] = 'top';
var u126 = document.getElementById('u126');

var u170 = document.getElementById('u170');
gv_vAlignTable['u170'] = 'top';
var u49 = document.getElementById('u49');
gv_vAlignTable['u49'] = 'top';
var u131 = document.getElementById('u131');
gv_vAlignTable['u131'] = 'top';
var u109 = document.getElementById('u109');
gv_vAlignTable['u109'] = 'top';
var u97 = document.getElementById('u97');
gv_vAlignTable['u97'] = 'top';
var u63 = document.getElementById('u63');

var u84 = document.getElementById('u84');

var u106 = document.getElementById('u106');

var u9 = document.getElementById('u9');
gv_vAlignTable['u9'] = 'top';
var u46 = document.getElementById('u46');

u46.style.cursor = 'pointer';
if (bIE) u46.attachEvent("onclick", Clicku46);
else u46.addEventListener("click", Clicku46, true);
function Clicku46(e)
{

if (true) {

	self.location.href="Clientes.aspx" + GetQuerystring();

}

}

var u81 = document.getElementById('u81');
gv_vAlignTable['u81'] = 'top';
var u144 = document.getElementById('u144');


var u151 = document.getElementById('u151');
gv_vAlignTable['u151'] = 'top';
var u150 = document.getElementById('u150');

var u30 = document.getElementById('u30');
gv_vAlignTable['u30'] = 'top';
var u77 = document.getElementById('u77');
gv_vAlignTable['u77'] = 'top';
var u152 = document.getElementById('u152');

var u61 = document.getElementById('u61');


var u7 = document.getElementById('u7');
gv_vAlignTable['u7'] = 'center';
var u13 = document.getElementById('u13');
gv_vAlignTable['u13'] = 'center';
var u95 = document.getElementById('u95');
gv_vAlignTable['u95'] = 'top';
var u125 = document.getElementById('u125');
gv_vAlignTable['u125'] = 'top';

var u137 = document.getElementById('u137');
gv_vAlignTable['u137'] = 'top';
var u44 = document.getElementById('u44');

u44.style.cursor = 'pointer';
if (bIE) u44.attachEvent("onclick", Clicku44);
else u44.addEventListener("click", Clicku44, true);
function Clicku44(e)
{

if (true) {

	self.location.href="Conf.___Param.aspx" + GetQuerystring();

}

}

var u165 = document.getElementById('u165');
gv_vAlignTable['u165'] = 'center';
var u27 = document.getElementById('u27');
gv_vAlignTable['u27'] = 'center';
var u4 = document.getElementById('u4');

var u2 = document.getElementById('u2');

var u75 = document.getElementById('u75');
gv_vAlignTable['u75'] = 'top';
var u132 = document.getElementById('u132');

var u148 = document.getElementById('u148');

var u58 = document.getElementById('u58');
gv_vAlignTable['u58'] = 'top';
var u140 = document.getElementById('u140');

var u42 = document.getElementById('u42');

u42.style.cursor = 'pointer';
if (bIE) u42.attachEvent("onclick", Clicku42);
else u42.addEventListener("click", Clicku42, true);
function Clicku42(e)
{

if (true) {

	self.location.href="Inicio.aspx" + GetQuerystring();

}

}

var u145 = document.getElementById('u145');
gv_vAlignTable['u145'] = 'top';
var u103 = document.getElementById('u103');
gv_vAlignTable['u103'] = 'top';
var u25 = document.getElementById('u25');

var u153 = document.getElementById('u153');
gv_vAlignTable['u153'] = 'top';
var u169 = document.getElementById('u169');


var u127 = document.getElementById('u127');
gv_vAlignTable['u127'] = 'top';
var u160 = document.getElementById('u160');
gv_vAlignTable['u160'] = 'top';
var u39 = document.getElementById('u39');
gv_vAlignTable['u39'] = 'top';
var u70 = document.getElementById('u70');

var u120 = document.getElementById('u120');

var u87 = document.getElementById('u87');
gv_vAlignTable['u87'] = 'top';
var u53 = document.getElementById('u53');
gv_vAlignTable['u53'] = 'center';
var u8 = document.getElementById('u8');

var u36 = document.getElementById('u36');
gv_vAlignTable['u36'] = 'top';
var u171 = document.getElementById('u171');
gv_vAlignTable['u171'] = 'top';
var u149 = document.getElementById('u149');
gv_vAlignTable['u149'] = 'top';
var u20 = document.getElementById('u20');
gv_vAlignTable['u20'] = 'center';
var u67 = document.getElementById('u67');
gv_vAlignTable['u67'] = 'top';
var u52 = document.getElementById('u52');

var u141 = document.getElementById('u141');
gv_vAlignTable['u141'] = 'top';
var u6 = document.getElementById('u6');

var u85 = document.getElementById('u85');
gv_vAlignTable['u85'] = 'top';
var u146 = document.getElementById('u146');

var u34 = document.getElementById('u34');
gv_vAlignTable['u34'] = 'center';
var u154 = document.getElementById('u154');
gv_vAlignTable['u154'] = 'top';
var u99 = document.getElementById('u99');
gv_vAlignTable['u99'] = 'top';
var u17 = document.getElementById('u17');
gv_vAlignTable['u17'] = 'top';
var u1 = document.getElementById('u1');
gv_vAlignTable['u1'] = 'center';
var u65 = document.getElementById('u65');
gv_vAlignTable['u65'] = 'top';
var u48 = document.getElementById('u48');

u48.style.cursor = 'pointer';
if (bIE) u48.attachEvent("onclick", Clicku48);
else u48.addEventListener("click", Clicku48, true);
function Clicku48(e)
{

if (true) {

	self.location.href="../Plataforma.aspx" + GetQuerystring();

}

}

var u121 = document.getElementById('u121');
gv_vAlignTable['u121'] = 'top';
var u79 = document.getElementById('u79');
gv_vAlignTable['u79'] = 'top';
var u32 = document.getElementById('u32');
gv_vAlignTable['u32'] = 'center';
var u80 = document.getElementById('u80');

var u134 = document.getElementById('u134');

var u51 = document.getElementById('u51');
gv_vAlignTable['u51'] = 'top';
var u143 = document.getElementById('u143');
gv_vAlignTable['u143'] = 'top';
var u76 = document.getElementById('u76');

var u155 = document.getElementById('u155');

var u158 = document.getElementById('u158');

var u101 = document.getElementById('u101');
gv_vAlignTable['u101'] = 'top';
var u94 = document.getElementById('u94');

var u60 = document.getElementById('u60');
gv_vAlignTable['u60'] = 'center';
var u117 = document.getElementById('u117');
gv_vAlignTable['u117'] = 'top';
var u11 = document.getElementById('u11');
gv_vAlignTable['u11'] = 'center';
var u43 = document.getElementById('u43');
gv_vAlignTable['u43'] = 'top';
var u162 = document.getElementById('u162');

var u114 = document.getElementById('u114');

var u89 = document.getElementById('u89');
gv_vAlignTable['u89'] = 'top';
var u26 = document.getElementById('u26');

var u74 = document.getElementById('u74');

var u122 = document.getElementById('u122');

var u138 = document.getElementById('u138');

var u136 = document.getElementById('u136');

var u10 = document.getElementById('u10');

var u57 = document.getElementById('u57');
gv_vAlignTable['u57'] = 'center';
var u92 = document.getElementById('u92');

var u5 = document.getElementById('u5');
gv_vAlignTable['u5'] = 'center';
var u41 = document.getElementById('u41');

var u135 = document.getElementById('u135');
gv_vAlignTable['u135'] = 'top';
var u24 = document.getElementById('u24');
gv_vAlignTable['u24'] = 'top';
var u72 = document.getElementById('u72');


var u102 = document.getElementById('u102');

var u118 = document.getElementById('u118');

var u0 = document.getElementById('u0');

var u55 = document.getElementById('u55');
gv_vAlignTable['u55'] = 'center';
var u38 = document.getElementById('u38');
gv_vAlignTable['u38'] = 'top';
var u83 = document.getElementById('u83');
gv_vAlignTable['u83'] = 'top';
var u110 = document.getElementById('u110');

var u86 = document.getElementById('u86');

var u115 = document.getElementById('u115');
gv_vAlignTable['u115'] = 'top';
var u69 = document.getElementById('u69');
gv_vAlignTable['u69'] = 'top';
var u22 = document.getElementById('u22');
gv_vAlignTable['u22'] = 'top';
var u123 = document.getElementById('u123');
gv_vAlignTable['u123'] = 'top';
var u139 = document.getElementById('u139');
gv_vAlignTable['u139'] = 'top';
var u166 = document.getElementById('u166');

var u66 = document.getElementById('u66');

u66.style.cursor = 'pointer';
if (bIE) u66.attachEvent("onclick", Clicku66);
else u66.addEventListener("click", Clicku66, true);
function Clicku66(e) {

    if (true) {

        self.location.href = "../Solicitudes/Solicitudes.aspx" + GetQuerystring();

    }

}

var u133 = document.getElementById('u133');
gv_vAlignTable['u133'] = 'top';
var u19 = document.getElementById('u19');

var u50 = document.getElementById('u50');

u50.style.cursor = 'pointer';
if (bIE) u50.attachEvent("onclick", Clicku50);
else u50.addEventListener("click", Clicku50, true);
function Clicku50(e)
{

if (true) {

	self.location.href="Caja.aspx" + GetQuerystring();

}

}

var u157 = document.getElementById('u157');
gv_vAlignTable['u157'] = 'top';
var u15 = document.getElementById('u15');

var u33 = document.getElementById('u33');

var u107 = document.getElementById('u107');
gv_vAlignTable['u107'] = 'top';
var u98 = document.getElementById('u98');

var u16 = document.getElementById('u16');
gv_vAlignTable['u16'] = 'center';
var u119 = document.getElementById('u119');
gv_vAlignTable['u119'] = 'top';
var u64 = document.getElementById('u64');

var u164 = document.getElementById('u164');

var u111 = document.getElementById('u111');
gv_vAlignTable['u111'] = 'top';
var u47 = document.getElementById('u47');
gv_vAlignTable['u47'] = 'top';
var u175 = document.getElementById('u175');
gv_vAlignTable['u175'] = 'top';
var u82 = document.getElementById('u82');

var u116 = document.getElementById('u116');

var u78 = document.getElementById('u78');

var u31 = document.getElementById('u31');

var u124 = document.getElementById('u124');

var u29 = document.getElementById('u29');
gv_vAlignTable['u29'] = 'top';
var u14 = document.getElementById('u14');
gv_vAlignTable['u14'] = 'top';
if (window.OnLoad) OnLoad();
