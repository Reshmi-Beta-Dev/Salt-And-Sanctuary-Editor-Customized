using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MapEdit.Properties;
using ProjectTower.map;

namespace MapEdit;

public class LayerTintEdit : Form
{
	private string fullPath;

	public int selLayer;

	private ContextMenuStrip layerMenu;

	private IContainer components;

	private Label label1;

	private TrackBar trkROBack5;

	private TextBox txtROBack5;

	private Panel panel1;

	private TrackBar trkBOBack5;

	private TextBox txtBOBack5;

	private Label label3;

	private TrackBar trkGOBack5;

	private TextBox txtGOBack5;

	private Label label2;

	private Label label6;

	private TrackBar trkTintOBack5;

	private TextBox txtTintOBack5;

	private Label label5;

	private TrackBar trkSatOBack5;

	private TextBox txtSatOBack5;

	private Label label4;

	private Panel panel2;

	private Label label7;

	private TrackBar trkTintOBack4;

	private TextBox txtTintOBack4;

	private Label label8;

	private TrackBar trkSatOBack4;

	private TextBox txtSatOBack4;

	private Label label9;

	private TrackBar trkBOBack4;

	private TextBox txtBOBack4;

	private Label label10;

	private TrackBar trkGOBack4;

	private TextBox txtGOBack4;

	private Label label11;

	private TrackBar trkROBack4;

	private TextBox txtROBack4;

	private Label label12;

	private Panel panel3;

	private Label label13;

	private TrackBar trkTintOBack3;

	private TextBox txtTintOBack3;

	private Label label14;

	private TrackBar trkSatOBack3;

	private TextBox txtSatOBack3;

	private Label label15;

	private TrackBar trkBOBack3;

	private TextBox txtBOBack3;

	private Label label16;

	private TrackBar trkGOBack3;

	private TextBox txtGOBack3;

	private Label label17;

	private TrackBar trkROBack3;

	private TextBox txtROBack3;

	private Label label18;

	private Panel panel4;

	private Label label19;

	private TrackBar trkTintOBack2;

	private TextBox txtTintOBack2;

	private Label label20;

	private TrackBar trkSatOBack2;

	private TextBox txtSatOBack2;

	private Label label21;

	private TrackBar trkBOBack2;

	private TextBox txtBOBack2;

	private Label label22;

	private TrackBar trkGOBack2;

	private TextBox txtGOBack2;

	private Label label23;

	private TrackBar trkROBack2;

	private TextBox txtROBack2;

	private Label label24;

	private Panel panel5;

	private Label label25;

	private TrackBar trkTintOBack1;

	private TextBox txtTintOBack1;

	private Label label26;

	private TrackBar trkSatOBack1;

	private TextBox txtSatOBack1;

	private Label label27;

	private TrackBar trkBOBack1;

	private TextBox txtBOBack1;

	private Label label28;

	private TrackBar trkGOBack1;

	private TextBox txtGOBack1;

	private Label label29;

	private TrackBar trkROBack1;

	private TextBox txtROBack1;

	private Label label30;

	private Panel panel6;

	private Label label31;

	private TrackBar trkTintOMid;

	private TextBox txtTintOMid;

	private Label label32;

	private TrackBar trkSatOMid;

	private TextBox txtSatOMid;

	private Label label33;

	private TrackBar trkBOMid;

	private TextBox txtBOMid;

	private Label label34;

	private TrackBar trkGOMid;

	private TextBox txtGOMid;

	private Label label35;

	private TrackBar trkROMid;

	private TextBox txtROMid;

	private Label label36;

	private Panel panel7;

	private Label label37;

	private TrackBar trkTintOFore1;

	private TextBox txtTintOFore1;

	private Label label38;

	private TrackBar trkSatOFore1;

	private TextBox txtSatOFore1;

	private Label label39;

	private TrackBar trkBOFore1;

	private TextBox txtBOFore1;

	private Label label40;

	private TrackBar trkGOFore1;

	private TextBox txtGOFore1;

	private Label label41;

	private TrackBar trkROFore1;

	private TextBox txtROFore1;

	private Label label42;

	private Panel panel8;

	private Label label43;

	private TrackBar trkTintOFore2;

	private TextBox txtTintOFore2;

	private Label label44;

	private TrackBar trkSatOFore2;

	private TextBox txtSatOFore2;

	private Label label45;

	private TrackBar trkBOFore2;

	private TextBox txtBOFore2;

	private Label label46;

	private TrackBar trkGOFore2;

	private TextBox txtGOFore2;

	private Label label47;

	private TrackBar trkROFore2;

	private TextBox txtROFore2;

	private Label label48;

	private Panel panel9;

	private Label label49;

	private TrackBar trkTintOFore3;

	private TextBox txtTintOFore3;

	private Label label50;

	private TrackBar trkSatOFore3;

	private TextBox txtSatOFore3;

	private Label label51;

	private TrackBar trkBOFore3;

	private TextBox txtBOFore3;

	private Label label52;

	private TrackBar trkGOFore3;

	private TextBox txtGOFore3;

	private Label label53;

	private TrackBar trkROFore3;

	private TextBox txtROFore3;

	private Label label54;

	private Panel panel10;

	private Label label55;

	private TrackBar trkTintOFore4;

	private TextBox txtTintOFore4;

	private Label label56;

	private TrackBar trkSatOFore4;

	private TextBox txtSatOFore4;

	private Label label57;

	private TrackBar trkBOFore4;

	private TextBox txtBOFore4;

	private Label label58;

	private TrackBar trkGOFore4;

	private TextBox txtGOFore4;

	private Label label59;

	private TrackBar trkROFore4;

	private TextBox txtROFore4;

	private Label label60;

	private Panel panel11;

	private Label label61;

	private TrackBar trkTintOFore5;

	private TextBox txtTintOFore5;

	private Label label62;

	private TrackBar trkSatOFore5;

	private TextBox txtSatOFore5;

	private Label label63;

	private TrackBar trkBOFore5;

	private TextBox txtBOFore5;

	private Label label64;

	private TrackBar trkGOFore5;

	private TextBox txtGOFore5;

	private Label label65;

	private TrackBar trkROFore5;

	private TextBox txtROFore5;

	private Label label66;

	private Panel panel12;

	private Label label67;

	private TrackBar trkTintIFore3;

	private TextBox txtTintIFore3;

	private Label label68;

	private TrackBar trkSatIFore3;

	private TextBox txtSatIFore3;

	private Label label69;

	private TrackBar trkBIFore3;

	private TextBox txtBIFore3;

	private Label label70;

	private TrackBar trkGIFore3;

	private TextBox txtGIFore3;

	private Label label71;

	private TrackBar trkRIFore3;

	private TextBox txtRIFore3;

	private Label label72;

	private Panel panel13;

	private Label label73;

	private TrackBar trkTintIFore2;

	private TextBox txtTintIFore2;

	private Label label74;

	private TrackBar trkSatIFore2;

	private TextBox txtSatIFore2;

	private Label label75;

	private TrackBar trkBIFore2;

	private TextBox txtBIFore2;

	private Label label76;

	private TrackBar trkGIFore2;

	private TextBox txtGIFore2;

	private Label label77;

	private TrackBar trkRIFore2;

	private TextBox txtRIFore2;

	private Label label78;

	private Panel panel14;

	private Label label79;

	private TrackBar trkTintIFore1;

	private TextBox txtTintIFore1;

	private Label label80;

	private TrackBar trkSatIFore1;

	private TextBox txtSatIFore1;

	private Label label81;

	private TrackBar trkBIFore1;

	private TextBox txtBIFore1;

	private Label label82;

	private TrackBar trkGIFore1;

	private TextBox txtGIFore1;

	private Label label83;

	private TrackBar trkRIFore1;

	private TextBox txtRIFore1;

	private Label label84;

	private Panel panel15;

	private Label label85;

	private TrackBar trkTintIMid;

	private TextBox txtTintIMid;

	private Label label86;

	private TrackBar trkSatIMid;

	private TextBox txtSatIMid;

	private Label label87;

	private TrackBar trkBIMid;

	private TextBox txtBIMid;

	private Label label88;

	private TrackBar trkGIMid;

	private TextBox txtGIMid;

	private Label label89;

	private TrackBar trkRIMid;

	private TextBox txtRIMid;

	private Label label90;

	private Panel panel16;

	private Label label91;

	private TrackBar trkTintIBack1;

	private TextBox txtTintIBack1;

	private Label label92;

	private TrackBar trkSatIBack1;

	private TextBox txtSatIBack1;

	private Label label93;

	private TrackBar trkBIBack1;

	private TextBox txtBIBack1;

	private Label label94;

	private TrackBar trkGIBack1;

	private TextBox txtGIBack1;

	private Label label95;

	private TrackBar trkRIBack1;

	private TextBox txtRIBack1;

	private Label label96;

	private Panel panel17;

	private Label label97;

	private TrackBar trkTintIBack2;

	private TextBox txtTintIBack2;

	private Label label98;

	private TrackBar trkSatIBack2;

	private TextBox txtSatIBack2;

	private Label label99;

	private TrackBar trkBIBack2;

	private TextBox txtBIBack2;

	private Label label100;

	private TrackBar trkGIBack2;

	private TextBox txtGIBack2;

	private Label label101;

	private TrackBar trkRIBack2;

	private TextBox txtRIBack2;

	private Label label102;

	private Panel panel18;

	private Label label103;

	private TrackBar trkTintIBack3;

	private TextBox txtTintIBack3;

	private Label label104;

	private TrackBar trkSatIBack3;

	private TextBox txtSatIBack3;

	private Label label105;

	private TrackBar trkBIBack3;

	private TextBox txtBIBack3;

	private Label label106;

	private TrackBar trkGIBack3;

	private TextBox txtGIBack3;

	private Label label107;

	private TrackBar trkRIBack3;

	private TextBox txtRIBack3;

	private Label label108;

	private Panel panel19;

	private Label label109;

	private TrackBar trkTintIBack4;

	private TextBox txtTintIBack4;

	private Label label110;

	private TrackBar trkSatIBack4;

	private TextBox txtSatIBack4;

	private Label label111;

	private TrackBar trkBIBack4;

	private TextBox txtBIBack4;

	private Label label112;

	private TrackBar trkGIBack4;

	private TextBox txtGIBack4;

	private Label label113;

	private TrackBar trkRIBack4;

	private TextBox txtRIBack4;

	private Label label114;

	private TrackBar trktB;

	private TextBox txttB;

	private Label label115;

	private TrackBar trktG;

	private TextBox txttG;

	private Label label116;

	private TrackBar trktR;

	private TextBox txttR;

	private Label label117;

	private TrackBar trkbB;

	private TextBox txtbB;

	private Label label118;

	private TrackBar trkbG;

	private TextBox txtbG;

	private Label label119;

	private TrackBar trkbR;

	private TextBox txtbR;

	private Label label120;

	private TrackBar trkbgB;

	private TextBox txtbgB;

	private Label label121;

	private TrackBar trkbgG;

	private TextBox txtbgG;

	private Label label122;

	private TrackBar trkbgR;

	private TextBox txtbgR;

	private Label label123;

	private TrackBar trkburnB;

	private TextBox txtburnB;

	private TrackBar trkburnG;

	private TextBox txtburnG;

	private TrackBar trkburnR;

	private TextBox txtburnR;

	private ListView lstLayers;

	private CheckBox chkIndoors;

	private TrackBar trkBrite;

	private TextBox txtBrite;

	private Label label127;

	private TrackBar trkGamma;

	private TextBox txtGamma;

	private Label label128;

	private TrackBar trkBloomBase;

	private TextBox txtBloomBase;

	private Label label129;

	private TrackBar trkBloomThresh;

	private TextBox txtBloomThresh;

	private Label label130;

	private TrackBar trkBloomSat;

	private TextBox txtBloomSat;

	private Label label131;

	private TrackBar trkBloomIntensity;

	private TextBox txtBloomIntensity;

	private Label label132;

	private TrackBar trkBloomFloor;

	private TextBox txtBloomFloor;

	private Label label133;

	private TrackBar trkDarkBlur;

	private TextBox txtDarkBlur;

	private Label label134;

	private TrackBar trkLightDesat;

	private TextBox txtLightDesat;

	private Label label135;

	private TrackBar trkLightRed;

	private TextBox txtLightRed;

	private Label label136;

	private TrackBar trkLightBlue;

	private TextBox txtLightBlue;

	private Label label137;

	private TrackBar trkLightThresh;

	private TextBox txtLightThresh;

	private Label label138;

	private Panel panel20;

	private Label label139;

	private Panel panel21;

	private Label label140;

	private Panel panel22;

	private Label label124;

	private Label label125;

	private Label label126;

	private Label label141;

	private Panel panel23;

	private Label label145;

	private Panel panel24;

	private Label label142;

	private Panel panel25;

	private Label label143;

	private TrackBar trkLightFac;

	private TrackBar trkLightMap;

	private TextBox txtLightFac;

	private Label label144;

	private TextBox txtLightMap;

	private Label label146;

	private TrackBar trkBaseSat;

	private Label label147;

	private TextBox txtBaseSat;

	private Panel panel26;

	private TrackBar trkRainAlpha;

	private TrackBar trkSnowAlpha;

	private Label label148;

	private Label label149;

	private Label label150;

	private Label label151;

	private TextBox txtDotsAlpha;

	private TrackBar trkDotsAlpha;

	private TextBox txtSnowAlpha;

	private TextBox txtRainAlpha;

	private TrackBar trkLeavesAlpha;

	private Label label152;

	private TextBox txtLeavesAlpha;

	private Panel panel27;

	private TrackBar trkBloodSat;

	private Label label153;

	private TextBox txtBloodAlpha;

	private Label label154;

	private TrackBar trkBloodAlpha;

	private Label label155;

	private TextBox txtBloodSat;

	private Panel panel28;

	private TrackBar trkpA;

	private Label label160;

	private TextBox txtpA;

	private TrackBar trkpB;

	private TrackBar trkpG;

	private Label label156;

	private Label label157;

	private Label label158;

	private Label label159;

	private TextBox txtpR;

	private TrackBar trkpR;

	private TextBox txtpG;

	private TextBox txtpB;

	private ColumnHeader columnHeader1;

	private MenuStrip menuStrip1;

	private ToolStripMenuItem fileToolStripMenuItem;

	private ToolStripMenuItem saveToolStripMenuItem;

	private ToolStripMenuItem toolsToolStripMenuItem;

	private ToolStripMenuItem interpolateParallaxToolStripMenuItem;

	private ToolStripMenuItem midInclusiveToolStripMenuItem;

	private ToolStripMenuItem midExclusiveToolStripMenuItem;

	private ToolStripMenuItem openToolStripMenuItem;

	private ToolStripSeparator toolStripSeparator1;

	private ToolStripMenuItem saveAsToolStripMenuItem;

	private TrackBar trkGammaOBack5;

	private TextBox txtGammaOBack5;

	private Label label177;

	private TrackBar trkBriteOBack5;

	private TextBox txtBriteOBack5;

	private Label label178;

	private TrackBar trkGammaOBack4;

	private TextBox txtGammaOBack4;

	private Label label179;

	private TrackBar trkBriteOBack4;

	private TextBox txtBriteOBack4;

	private Label label180;

	private TrackBar trkGammaOBack3;

	private TextBox txtGammaOBack3;

	private Label label181;

	private TrackBar trkBriteOBack3;

	private TextBox txtBriteOBack3;

	private Label label182;

	private TrackBar trkGammaOBack2;

	private TextBox txtGammaOBack2;

	private Label label183;

	private TrackBar trkBriteOBack2;

	private TextBox txtBriteOBack2;

	private Label label184;

	private TrackBar trkGammaOBack1;

	private TextBox txtGammaOBack1;

	private Label label185;

	private TrackBar trkBriteOBack1;

	private TextBox txtBriteOBack1;

	private Label label186;

	private TrackBar trkGammaOMid;

	private TextBox txtGammaOMid;

	private Label label187;

	private TrackBar trkBriteOMid;

	private TextBox txtBriteOMid;

	private Label label188;

	private TrackBar trkGammaOFore1;

	private TextBox txtGammaOFore1;

	private Label label189;

	private TrackBar trkBriteOFore1;

	private TextBox txtBriteOFore1;

	private Label label190;

	private TrackBar trkGammaOFore2;

	private TextBox txtGammaOFore2;

	private Label label191;

	private TrackBar trkBriteOFore2;

	private TextBox txtBriteOFore2;

	private Label label192;

	private TrackBar trkGammaOFore3;

	private TextBox txtGammaOFore3;

	private Label label193;

	private TrackBar trkBriteOFore3;

	private TextBox txtBriteOFore3;

	private Label label194;

	private TrackBar trkGammaOFore4;

	private TextBox txtGammaOFore4;

	private Label label195;

	private TrackBar trkBriteOFore4;

	private TextBox txtBriteOFore4;

	private Label label196;

	private TrackBar trkGammaOFore5;

	private TextBox txtGammaOFore5;

	private Label label197;

	private TrackBar trkBriteOFore5;

	private TextBox txtBriteOFore5;

	private Label label198;

	private TrackBar trkGammaIFore3;

	private TextBox txtGammaIFore3;

	private Label label175;

	private TrackBar trkBriteIFore3;

	private TextBox txtBriteIFore3;

	private Label label176;

	private TrackBar trkGammaIFore2;

	private TextBox txtGammaIFore2;

	private Label label173;

	private TrackBar trkBriteIFore2;

	private TextBox txtBriteIFore2;

	private Label label174;

	private TrackBar trkGammaIFore1;

	private TextBox txtGammaIFore1;

	private Label label171;

	private TrackBar trkBriteIFore1;

	private TextBox txtBriteIFore1;

	private Label label172;

	private TrackBar trkGammaIMid;

	private TextBox txtGammaIMid;

	private Label label169;

	private TrackBar trkBriteIMid;

	private TextBox txtBriteIMid;

	private Label label170;

	private TrackBar trkGammaIBack1;

	private TextBox txtGammaIBack1;

	private Label label167;

	private TrackBar trkBriteIBack1;

	private TextBox txtBriteIBack1;

	private Label label168;

	private TrackBar trkGammaIBack2;

	private TextBox txtGammaIBack2;

	private Label label165;

	private TrackBar trkBriteIBack2;

	private TextBox txtBriteIBack2;

	private Label label166;

	private TrackBar trkGammaIBack3;

	private TextBox txtGammaIBack3;

	private Label label163;

	private TrackBar trkBriteIBack3;

	private TextBox txtBriteIBack3;

	private Label label164;

	private TrackBar trkGammaIBack4;

	private TextBox txtGammaIBack4;

	private Label label162;

	private TrackBar trkBriteIBack4;

	private TextBox txtBriteIBack4;

	private Label label161;

	private Panel panel29;

	private TrackBar trkRainSkewAdjust0;

	private Label label199;

	private TextBox txtRainSkewAdjust0;

	private TrackBar trkRainSkewBase0;

	private TrackBar trkRainAlpha0;

	private Label label200;

	private Label label201;

	private Label label202;

	private Label label203;

	private TextBox txtRainStretch0;

	private TrackBar trkRainStretch0;

	private TextBox txtRainAlpha0;

	private TextBox txtRainSkewBase0;

	private Panel panel30;

	private TrackBar trkRainSkewAdjust1;

	private Label label204;

	private TextBox txtRainSkewAdjust1;

	private TrackBar trkRainSkewBase1;

	private TrackBar trkRainAlpha1;

	private Label label205;

	private Label label206;

	private Label label207;

	private Label label208;

	private TextBox txtRainStretch1;

	private TrackBar trkRainStretch1;

	private TextBox txtRainAlpha1;

	private TextBox txtRainSkewBase1;

	private Panel panel31;

	private TrackBar trkRainB0;

	private TrackBar trkRainG0;

	private Label label210;

	private Label label211;

	private Label label212;

	private Label label213;

	private TextBox txtRainR0;

	private TrackBar trkRainR0;

	private TextBox txtRainG0;

	private TextBox txtRainB0;

	private TabControl tbPanels;

	private TabPage tabPage1;

	private TabPage tabPage2;

	private TabPage tabPage3;

	private Panel panel34;

	private TrackBar trkRainB1;

	private TrackBar trkRainG1;

	private Label label223;

	private Label label224;

	private Label label225;

	private Label label226;

	private TextBox txtRainR1;

	private TrackBar trkRainR1;

	private TextBox txtRainG1;

	private TextBox txtRainB1;

	private Panel panel33;

	private TrackBar trkRainSkewAdjust3;

	private Label label218;

	private TextBox txtRainSkewAdjust3;

	private TrackBar trkRainSkewBase3;

	private TrackBar trkRainAlpha3;

	private Label label219;

	private Label label220;

	private Label label221;

	private Label label222;

	private TextBox txtRainStretch3;

	private TrackBar trkRainStretch3;

	private TextBox txtRainAlpha3;

	private TextBox txtRainSkewBase3;

	private Panel panel32;

	private TrackBar trkRainSkewAdjust2;

	private Label label209;

	private TextBox txtRainSkewAdjust2;

	private TrackBar trkRainSkewBase2;

	private TrackBar trkRainAlpha2;

	private Label label214;

	private Label label215;

	private Label label216;

	private Label label217;

	private TextBox txtRainStretch2;

	private TrackBar trkRainStretch2;

	private TextBox txtRainAlpha2;

	private TextBox txtRainSkewBase2;

	private TabPage tabPage4;

	private Panel panel35;

	private TrackBar trkRainSkewAdjust4;

	private Label label227;

	private TextBox txtRainSkewAdjust4;

	private TrackBar trkRainSkewBase4;

	private TrackBar trkRainAlpha4;

	private Label label228;

	private Label label229;

	private Label label230;

	private Label label231;

	private TextBox txtRainStretch4;

	private TrackBar trkRainStretch4;

	private TextBox txtRainAlpha4;

	private TextBox txtRainSkewBase4;

	private Panel panel36;

	private TrackBar trkRainSkewAdjust5;

	private Label label232;

	private TextBox txtRainSkewAdjust5;

	private TrackBar trkRainSkewBase5;

	private TrackBar trkRainAlpha5;

	private Label label233;

	private Label label234;

	private Label label235;

	private Label label236;

	private TextBox txtRainStretch5;

	private TrackBar trkRainStretch5;

	private TextBox txtRainAlpha5;

	private TextBox txtRainSkewBase5;

	private CheckBox chkSndBugs;

	private CheckBox chkStarry;

	private CheckBox chkLightning;

	private CheckBox chkSndLightRain;

	private CheckBox chkSndStorm;

	private CheckBox chkSndRain;

	private CheckBox chkSndRainIn;

	private CheckBox chkSndDungeon;

	private CheckBox chkSndDrips;

	private CheckBox chkSndCreak;

	private CheckBox chkSndChains;

	private CheckBox chkSndCaveDrips;

	private CheckBox chkSndCave;

	private CheckBox chkNoMusic;

	private CheckBox chkNoGravestones;

	private CheckBox chkSanctuary;

	private Panel panel37;

	private TrackBar trkRefractRainB;

	private TrackBar trkRefractRainG;

	private Label label242;

	private Label label243;

	private Label label244;

	private TextBox txtRefractRainR;

	private TrackBar trkRefractRainR;

	private TextBox txtRefractRainG;

	private TextBox txtRefractRainB;

	private Label label241;

	private TextBox txtRefractRainGlow;

	private TrackBar trkRefractRainGlow;

	private Label label240;

	private TextBox txtRefractRainGlimmer;

	private TrackBar trkRefractRainGlimmer;

	private Label label239;

	private TextBox txtRefractRainDark;

	private TrackBar trkRefractRainDark;

	private Label label237;

	private Label label238;

	private TextBox txtRefractRainBrite;

	private TrackBar trkRefractRainBrite;

	private TrackBar trkBloomDesatBase;

	private Label label245;

	private TextBox txtBloomDesatBase;

	private Panel panel38;

	private Label label249;

	private TextBox txtRainGamma3;

	private TrackBar trkRainGamma3;

	private Label label248;

	private TextBox txtRainGamma2;

	private TrackBar trkRainGamma2;

	private Label label247;

	private TextBox txtRainGamma1;

	private TrackBar trkRainGamma1;

	private Label label246;

	private Panel panel39;

	private TrackBar trkGammaBG;

	private TextBox txtGammaBG;

	private Label label250;

	private TrackBar trkBriteBG;

	private TextBox txtBriteBG;

	private Label label251;

	private Label label252;

	private TrackBar trkTintBG;

	private TextBox txtTintBG;

	private Label label253;

	private TrackBar trkSatBG;

	private TextBox txtSatBG;

	private Label label254;

	private TrackBar trkBBG;

	private TextBox txtBBG;

	private Label label255;

	private TrackBar trkGBG;

	private TextBox txtGBG;

	private Label label256;

	private TrackBar trkRBG;

	private TextBox txtRBG;

	private Label label257;

	private TextBox txtBBOBack5;

	private TextBox txtBGOBack5;

	private TextBox txtBROBack5;

	private TextBox txtBBOBack4;

	private TextBox txtBGOBack4;

	private TextBox txtBROBack4;

	private TextBox txtBBOBack3;

	private TextBox txtBGOBack3;

	private TextBox txtBROBack3;

	private TextBox txtBBOBack2;

	private TextBox txtBGOBack2;

	private TextBox txtBROBack2;

	private TextBox txtBBOBack1;

	private TextBox txtBGOBack1;

	private TextBox txtBROBack1;

	private TextBox txtBBOMid;

	private TextBox txtBGOMid;

	private TextBox txtBROMid;

	private TextBox txtBBOFore1;

	private TextBox txtBGOFore1;

	private TextBox txtBROFore1;

	private TextBox txtBBOFore2;

	private TextBox txtBGOFore2;

	private TextBox txtBROFore2;

	private TextBox txtBBOFore3;

	private TextBox txtBGOFore3;

	private TextBox txtBROFore3;

	private TextBox txtBBOFore4;

	private TextBox txtBGOFore4;

	private TextBox txtBROFore4;

	private TextBox txtBBOFore5;

	private TextBox txtBGOFore5;

	private TextBox txtBROFore5;

	private TextBox txtBBIFore3;

	private TextBox txtBGIFore3;

	private TextBox txtBRIFore3;

	private TextBox txtBBIFore2;

	private TextBox txtBGIFore2;

	private TextBox txtBRIFore2;

	private TextBox txtBBIFore1;

	private TextBox txtBGIFore1;

	private TextBox txtBRIFore1;

	private TextBox txtBBIMid;

	private TextBox txtBGIMid;

	private TextBox txtBRIMid;

	private TextBox txtBBIBack1;

	private TextBox txtBGIBack1;

	private TextBox txtBRIBack1;

	private TextBox txtBBIBack2;

	private TextBox txtBGIBack2;

	private TextBox txtBRIBack2;

	private TextBox txtBBIBack3;

	private TextBox txtBGIBack3;

	private TextBox txtBRIBack3;

	private TextBox txtBBIBack4;

	private TextBox txtBGIBack4;

	private TextBox txtBRIBack4;

	private TextBox txtBBBG;

	private TextBox txtBGBG;

	private TextBox txtBRBG;

	private void LayerTintEdit_Load(object sender, EventArgs e)
	{
	}

	public LayerTintEdit()
	{
		layerMenu = new ContextMenuStrip();
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("New Layer", Resources._new);
		ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("Duplicate Layer", Resources.copy);
		toolStripMenuItem.Click += addLayer_Click;
		toolStripMenuItem2.Click += duplicateLayer_Click;
		layerMenu.Items.Add(toolStripMenuItem);
		layerMenu.Items.Add("-");
		layerMenu.Items.Add(toolStripMenuItem2);
		InitializeComponent();
	}

	private void duplicateLayer_Click(object sender, EventArgs e)
	{
	}

	private void addLayer_Click(object sender, EventArgs e)
	{
		LayerTintCatalog.layerTintData.Add(new LayerTintCatalog.LayerTintData
		{
			layerTintLayer = new LayerTintCatalog.LayerTintLayer[19],
			name = "New Layer " + LayerTintCatalog.layerTintData.Count
		});
		RefreshLayerList();
	}

	private void RefreshLayerList()
	{
		lstLayers.BeginUpdate();
		lstLayers.Items.Clear();
		foreach (LayerTintCatalog.LayerTintData layerTintDatum in LayerTintCatalog.layerTintData)
		{
			lstLayers.Items.Add(new ListViewItem(layerTintDatum.name));
		}
		lstLayers.EndUpdate();
	}

	private void RefreshControls()
	{
		if (IsValidLayerSelected())
		{
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 11);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 12);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 13);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 14);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 15);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 16);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 17);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 18);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 0);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 1);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 2);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 3);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 4);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 5);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 6);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 7);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 8);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 9);
			RefreshLayerControls(LayerTintCatalog.layerTintData[selLayer], 10);
			txtLightThresh.Text = LayerTintCatalog.layerTintData[selLayer].lightThresh.ToString();
			txtLightRed.Text = LayerTintCatalog.layerTintData[selLayer].lightRed.ToString();
			txtLightBlue.Text = LayerTintCatalog.layerTintData[selLayer].lightBlue.ToString();
			txtLightDesat.Text = LayerTintCatalog.layerTintData[selLayer].lightDesat.ToString();
			txtDarkBlur.Text = LayerTintCatalog.layerTintData[selLayer].darkBlur.ToString();
			txtLightMap.Text = LayerTintCatalog.layerTintData[selLayer].lightMap.ToString();
			txtLightFac.Text = LayerTintCatalog.layerTintData[selLayer].lightFac.ToString();
			txtBloomBase.Text = LayerTintCatalog.layerTintData[selLayer].bloomBase.ToString();
			txtBloomFloor.Text = LayerTintCatalog.layerTintData[selLayer].floorVal.ToString();
			txtBloomIntensity.Text = LayerTintCatalog.layerTintData[selLayer].bloomIntensity.ToString();
			txtBloomSat.Text = LayerTintCatalog.layerTintData[selLayer].bloomSat.ToString();
			txtBloomThresh.Text = LayerTintCatalog.layerTintData[selLayer].bloomThreshhold.ToString();
			txtbgR.Text = LayerTintCatalog.layerTintData[selLayer].bgR.ToString();
			txtbgG.Text = LayerTintCatalog.layerTintData[selLayer].bgG.ToString();
			txtbgB.Text = LayerTintCatalog.layerTintData[selLayer].bgB.ToString();
			txtbR.Text = LayerTintCatalog.layerTintData[selLayer].bR.ToString();
			txtbG.Text = LayerTintCatalog.layerTintData[selLayer].bG.ToString();
			txtbB.Text = LayerTintCatalog.layerTintData[selLayer].bB.ToString();
			txttR.Text = LayerTintCatalog.layerTintData[selLayer].tR.ToString();
			txttG.Text = LayerTintCatalog.layerTintData[selLayer].tG.ToString();
			txttB.Text = LayerTintCatalog.layerTintData[selLayer].tB.ToString();
			txtBloodAlpha.Text = LayerTintCatalog.layerTintData[selLayer].bloodAlpha.ToString();
			txtBloodSat.Text = LayerTintCatalog.layerTintData[selLayer].bloodSat.ToString();
			txtburnR.Text = LayerTintCatalog.layerTintData[selLayer].burnR.ToString();
			txtburnG.Text = LayerTintCatalog.layerTintData[selLayer].burnG.ToString();
			txtburnB.Text = LayerTintCatalog.layerTintData[selLayer].burnB.ToString();
			txtDotsAlpha.Text = LayerTintCatalog.layerTintData[selLayer].dotsAlpha.ToString();
			txtSnowAlpha.Text = LayerTintCatalog.layerTintData[selLayer].snowAlpha.ToString();
			txtRainAlpha.Text = LayerTintCatalog.layerTintData[selLayer].rainAlpha.ToString();
			txtLeavesAlpha.Text = LayerTintCatalog.layerTintData[selLayer].leavesAlpha.ToString();
			txtGamma.Text = LayerTintCatalog.layerTintData[selLayer].gamma.ToString();
			txtBaseSat.Text = LayerTintCatalog.layerTintData[selLayer].sat.ToString();
			txtBrite.Text = LayerTintCatalog.layerTintData[selLayer].brite.ToString();
			chkIndoors.Checked = LayerTintCatalog.layerTintData[selLayer].indoors;
			txtpR.Text = LayerTintCatalog.layerTintData[selLayer].pR.ToString();
			txtpG.Text = LayerTintCatalog.layerTintData[selLayer].pG.ToString();
			txtpB.Text = LayerTintCatalog.layerTintData[selLayer].pB.ToString();
			txtpA.Text = LayerTintCatalog.layerTintData[selLayer].pA.ToString();
		}
	}

	private void RefreshLayerControls(LayerTintCatalog.LayerTintData layerTintData, int layer)
	{
		GetRedTrackbar(layer).Value = (int)((double)layerTintData.layerTintLayer[layer].r * 1000.0);
		GetGreenTrackbar(layer).Value = (int)((double)layerTintData.layerTintLayer[layer].g * 1000.0);
		GetBlueTrackbar(layer).Value = (int)((double)layerTintData.layerTintLayer[layer].b * 1000.0);
		GetSatTrackbar(layer).Value = (int)((double)layerTintData.layerTintLayer[layer].sat * 1000.0);
		GetTintTrackbar(layer).Value = (int)((double)layerTintData.layerTintLayer[layer].tint * 1000.0);
		GetRedTextbox(layer).Text = layerTintData.layerTintLayer[layer].r.ToString();
		GetGreenTextbox(layer).Text = layerTintData.layerTintLayer[layer].g.ToString();
		GetBlueTextbox(layer).Text = layerTintData.layerTintLayer[layer].b.ToString();
		GetSatTextbox(layer).Text = layerTintData.layerTintLayer[layer].sat.ToString();
		GetTintTextbox(layer).Text = layerTintData.layerTintLayer[layer].tint.ToString();
	}

	private float GetVal(TrackBar val, TextBox strVal)
	{
		float result = 0f;
		if (strVal != null)
		{
			try
			{
				result = Convert.ToSingle(strVal.Text);
			}
			catch
			{
			}
		}
		if (val != null)
		{
			result = (float)val.Value / 1000f;
		}
		return result;
	}

	private bool IsValidLayerSelected()
	{
		_ = selLayer;
		if (LayerTintCatalog.layerTintData != null && selLayer >= 0)
		{
			return selLayer < LayerTintCatalog.layerTintData.Count;
		}
		return false;
	}

	private void SetLayerBottomRed(int layer, TextBox sRed)
	{
		if (IsValidLayerSelected())
		{
			GetVal(null, sRed);
		}
	}

	private void SetLayerBottomGreen(int layer, TextBox sGreen)
	{
		if (IsValidLayerSelected())
		{
			GetVal(null, sGreen);
		}
	}

	private void SetLayerBottomBlue(int layer, TextBox sBlue)
	{
		if (IsValidLayerSelected())
		{
			GetVal(null, sBlue);
		}
	}

	private void SetLayerRed(int layer, TrackBar red, TextBox sRed)
	{
		if (IsValidLayerSelected())
		{
			float val = GetVal(red, sRed);
			LayerTintCatalog.layerTintData[selLayer].layerTintLayer[layer].r = val;
			if (sRed == null)
			{
				GetRedTextbox(layer).Text = val.ToString();
			}
			else
			{
				GetRedTrackbar(layer).Value = (int)((double)val * 1000.0);
			}
		}
	}

	private void SetLayerGreen(int layer, TrackBar green, TextBox sGreen)
	{
		if (IsValidLayerSelected())
		{
			float val = GetVal(green, sGreen);
			LayerTintCatalog.layerTintData[selLayer].layerTintLayer[layer].g = val;
			if (sGreen == null)
			{
				GetGreenTextbox(layer).Text = val.ToString();
			}
			else
			{
				GetGreenTrackbar(layer).Value = (int)((double)val * 1000.0);
			}
		}
	}

	private void SetLayerBlue(int layer, TrackBar blue, TextBox sBlue)
	{
		if (IsValidLayerSelected())
		{
			float val = GetVal(blue, sBlue);
			LayerTintCatalog.layerTintData[selLayer].layerTintLayer[layer].b = val;
			if (sBlue == null)
			{
				GetBlueTextbox(layer).Text = val.ToString();
			}
			else
			{
				GetBlueTrackbar(layer).Value = (int)((double)val * 1000.0);
			}
		}
	}

	private void SetLayerSat(int layer, TrackBar sat, TextBox sSat)
	{
		if (IsValidLayerSelected())
		{
			float val = GetVal(sat, sSat);
			LayerTintCatalog.layerTintData[selLayer].layerTintLayer[layer].sat = val;
			if (sSat == null)
			{
				GetSatTextbox(layer).Text = val.ToString();
			}
			else
			{
				GetSatTrackbar(layer).Value = (int)((double)val * 1000.0);
			}
		}
	}

	private void SetLayerTint(int layer, TrackBar tint, TextBox sTint)
	{
		if (IsValidLayerSelected())
		{
			float val = GetVal(tint, sTint);
			LayerTintCatalog.layerTintData[selLayer].layerTintLayer[layer].tint = val;
			if (sTint == null)
			{
				GetTintTextbox(layer).Text = val.ToString();
			}
			else
			{
				GetTintTrackbar(layer).Value = (int)((double)val * 1000.0);
			}
		}
	}

	private void SetLayerBrite(int layer, TrackBar brite, TextBox sBrite)
	{
	}

	private void SetLayerGamma(int layer, TrackBar gamma, TextBox sGamma)
	{
	}

	private float SetTrackValue(TrackBar trkVal, TextBox txtVal)
	{
		float result = 0f;
		if (IsValidLayerSelected())
		{
			result = GetVal(trkVal, null);
			txtVal.Text = result.ToString();
		}
		return result;
	}

	private float SetTextValue(TrackBar trkVal, TextBox txtVal)
	{
		float num = 0f;
		if (IsValidLayerSelected())
		{
			num = GetVal(null, txtVal);
			try
			{
				trkVal.Value = (int)((double)num * 1000.0);
			}
			catch
			{
			}
		}
		return num;
	}

	private TrackBar GetRedTrackbar(int layer)
	{
		return layer switch
		{
			0 => trkROBack5, 
			1 => trkROBack4, 
			2 => trkROBack3, 
			3 => trkROBack2, 
			4 => trkROBack1, 
			5 => trkROMid, 
			6 => trkROFore1, 
			7 => trkROFore2, 
			8 => trkROFore3, 
			9 => trkROFore4, 
			10 => trkROFore5, 
			11 => trkRIBack4, 
			12 => trkRIBack3, 
			13 => trkRIBack2, 
			14 => trkRIBack1, 
			15 => trkRIMid, 
			16 => trkRIFore1, 
			17 => trkRIFore2, 
			18 => trkRIFore3, 
			_ => null, 
		};
	}

	private TrackBar GetGreenTrackbar(int layer)
	{
		return layer switch
		{
			0 => trkGOBack5, 
			1 => trkGOBack4, 
			2 => trkGOBack3, 
			3 => trkGOBack2, 
			4 => trkGOBack1, 
			5 => trkGOMid, 
			6 => trkGOFore1, 
			7 => trkGOFore2, 
			8 => trkGOFore3, 
			9 => trkGOFore4, 
			10 => trkGOFore5, 
			11 => trkGIBack4, 
			12 => trkGIBack3, 
			13 => trkGIBack2, 
			14 => trkGIBack1, 
			15 => trkGIMid, 
			16 => trkGIFore1, 
			17 => trkGIFore2, 
			18 => trkGIFore3, 
			_ => null, 
		};
	}

	private TrackBar GetBlueTrackbar(int layer)
	{
		return layer switch
		{
			0 => trkBOBack5, 
			1 => trkBOBack4, 
			2 => trkBOBack3, 
			3 => trkBOBack2, 
			4 => trkBOBack1, 
			5 => trkBOMid, 
			6 => trkBOFore1, 
			7 => trkBOFore2, 
			8 => trkBOFore3, 
			9 => trkBOFore4, 
			10 => trkBOFore5, 
			11 => trkBIBack4, 
			12 => trkBIBack3, 
			13 => trkBIBack2, 
			14 => trkBIBack1, 
			15 => trkBIMid, 
			16 => trkBIFore1, 
			17 => trkBIFore2, 
			18 => trkBIFore3, 
			_ => null, 
		};
	}

	private TrackBar GetSatTrackbar(int layer)
	{
		return layer switch
		{
			0 => trkSatOBack5, 
			1 => trkSatOBack4, 
			2 => trkSatOBack3, 
			3 => trkSatOBack2, 
			4 => trkSatOBack1, 
			5 => trkSatOMid, 
			6 => trkSatOFore1, 
			7 => trkSatOFore2, 
			8 => trkSatOFore3, 
			9 => trkSatOFore4, 
			10 => trkSatOFore5, 
			11 => trkSatIBack4, 
			12 => trkSatIBack3, 
			13 => trkSatIBack2, 
			14 => trkSatIBack1, 
			15 => trkSatIMid, 
			16 => trkSatIFore1, 
			17 => trkSatIFore2, 
			18 => trkSatIFore3, 
			_ => null, 
		};
	}

	private TrackBar GetTintTrackbar(int layer)
	{
		return layer switch
		{
			0 => trkTintOBack5, 
			1 => trkTintOBack4, 
			2 => trkTintOBack3, 
			3 => trkTintOBack2, 
			4 => trkTintOBack1, 
			5 => trkTintOMid, 
			6 => trkTintOFore1, 
			7 => trkTintOFore2, 
			8 => trkTintOFore3, 
			9 => trkTintOFore4, 
			10 => trkTintOFore5, 
			11 => trkTintIBack4, 
			12 => trkTintIBack3, 
			13 => trkTintIBack2, 
			14 => trkTintIBack1, 
			15 => trkTintIMid, 
			16 => trkTintIFore1, 
			17 => trkTintIFore2, 
			18 => trkTintIFore3, 
			_ => null, 
		};
	}

	private TextBox GetBottomRedTextbox(int layer)
	{
		return layer switch
		{
			0 => txtBROBack5, 
			1 => txtBROBack4, 
			2 => txtBROBack3, 
			3 => txtBROBack2, 
			4 => txtBROBack1, 
			5 => txtBROMid, 
			6 => txtBROFore1, 
			7 => txtBROFore2, 
			8 => txtBROFore3, 
			9 => txtBROFore4, 
			10 => txtBROFore5, 
			11 => txtBRIBack4, 
			12 => txtBRIBack3, 
			13 => txtBRIBack2, 
			14 => txtBRIBack1, 
			15 => txtBRIMid, 
			16 => txtBRIFore1, 
			17 => txtBRIFore2, 
			18 => txtBRIFore3, 
			_ => null, 
		};
	}

	private TextBox GetBottomGreenTextbox(int layer)
	{
		return layer switch
		{
			0 => txtBGOBack5, 
			1 => txtBGOBack4, 
			2 => txtBGOBack3, 
			3 => txtBGOBack2, 
			4 => txtBGOBack1, 
			5 => txtBGOMid, 
			6 => txtBGOFore1, 
			7 => txtBGOFore2, 
			8 => txtBGOFore3, 
			9 => txtBGOFore4, 
			10 => txtBGOFore5, 
			11 => txtBGIBack4, 
			12 => txtBGIBack3, 
			13 => txtBGIBack2, 
			14 => txtBGIBack1, 
			15 => txtBGIMid, 
			16 => txtBGIFore1, 
			17 => txtBGIFore2, 
			18 => txtBGIFore3, 
			_ => null, 
		};
	}

	private TextBox GetBottomBlueTextbox(int layer)
	{
		return layer switch
		{
			0 => txtBBOBack5, 
			1 => txtBBOBack4, 
			2 => txtBBOBack3, 
			3 => txtBBOBack2, 
			4 => txtBBOBack1, 
			5 => txtBBOMid, 
			6 => txtBBOFore1, 
			7 => txtBBOFore2, 
			8 => txtBBOFore3, 
			9 => txtBBOFore4, 
			10 => txtBBOFore5, 
			11 => txtBBIBack4, 
			12 => txtBBIBack3, 
			13 => txtBBIBack2, 
			14 => txtBBIBack1, 
			15 => txtBBIMid, 
			16 => txtBBIFore1, 
			17 => txtBBIFore2, 
			18 => txtBBIFore3, 
			_ => null, 
		};
	}

	private TextBox GetRedTextbox(int layer)
	{
		return layer switch
		{
			0 => txtROBack5, 
			1 => txtROBack4, 
			2 => txtROBack3, 
			3 => txtROBack2, 
			4 => txtROBack1, 
			5 => txtROMid, 
			6 => txtROFore1, 
			7 => txtROFore2, 
			8 => txtROFore3, 
			9 => txtROFore4, 
			10 => txtROFore5, 
			11 => txtRIBack4, 
			12 => txtRIBack3, 
			13 => txtRIBack2, 
			14 => txtRIBack1, 
			15 => txtRIMid, 
			16 => txtRIFore1, 
			17 => txtRIFore2, 
			18 => txtRIFore3, 
			_ => null, 
		};
	}

	private TextBox GetGreenTextbox(int layer)
	{
		return layer switch
		{
			0 => txtGOBack5, 
			1 => txtGOBack4, 
			2 => txtGOBack3, 
			3 => txtGOBack2, 
			4 => txtGOBack1, 
			5 => txtGOMid, 
			6 => txtGOFore1, 
			7 => txtGOFore2, 
			8 => txtGOFore3, 
			9 => txtGOFore4, 
			10 => txtGOFore5, 
			11 => txtGIBack4, 
			12 => txtGIBack3, 
			13 => txtGIBack2, 
			14 => txtGIBack1, 
			15 => txtGIMid, 
			16 => txtGIFore1, 
			17 => txtGIFore2, 
			18 => txtGIFore3, 
			_ => null, 
		};
	}

	private TextBox GetBlueTextbox(int layer)
	{
		return layer switch
		{
			0 => txtBOBack5, 
			1 => txtBOBack4, 
			2 => txtBOBack3, 
			3 => txtBOBack2, 
			4 => txtBOBack1, 
			5 => txtBOMid, 
			6 => txtBOFore1, 
			7 => txtBOFore2, 
			8 => txtBOFore3, 
			9 => txtBOFore4, 
			10 => txtBOFore5, 
			11 => txtBIBack4, 
			12 => txtBIBack3, 
			13 => txtBIBack2, 
			14 => txtBIBack1, 
			15 => txtBIMid, 
			16 => txtBIFore1, 
			17 => txtBIFore2, 
			18 => txtBIFore3, 
			_ => null, 
		};
	}

	private TextBox GetSatTextbox(int layer)
	{
		return layer switch
		{
			0 => txtSatOBack5, 
			1 => txtSatOBack4, 
			2 => txtSatOBack3, 
			3 => txtSatOBack2, 
			4 => txtSatOBack1, 
			5 => txtSatOMid, 
			6 => txtSatOFore1, 
			7 => txtSatOFore2, 
			8 => txtSatOFore3, 
			9 => txtSatOFore4, 
			10 => txtSatOFore5, 
			11 => txtSatIBack4, 
			12 => txtSatIBack3, 
			13 => txtSatIBack2, 
			14 => txtSatIBack1, 
			15 => txtSatIMid, 
			16 => txtSatIFore1, 
			17 => txtSatIFore2, 
			18 => txtSatIFore3, 
			_ => null, 
		};
	}

	private TextBox GetTintTextbox(int layer)
	{
		return layer switch
		{
			0 => txtTintOBack5, 
			1 => txtTintOBack4, 
			2 => txtTintOBack3, 
			3 => txtTintOBack2, 
			4 => txtTintOBack1, 
			5 => txtTintOMid, 
			6 => txtTintOFore1, 
			7 => txtTintOFore2, 
			8 => txtTintOFore3, 
			9 => txtTintOFore4, 
			10 => txtTintOFore5, 
			11 => txtTintIBack4, 
			12 => txtTintIBack3, 
			13 => txtTintIBack2, 
			14 => txtTintIBack1, 
			15 => txtTintIMid, 
			16 => txtTintIFore1, 
			17 => txtTintIFore2, 
			18 => txtTintIFore3, 
			_ => null, 
		};
	}

	private TextBox GetBriteTextbox(int layer)
	{
		return layer switch
		{
			0 => txtBriteOBack5, 
			1 => txtBriteOBack4, 
			2 => txtBriteOBack3, 
			3 => txtBriteOBack2, 
			4 => txtBriteOBack1, 
			5 => txtBriteOMid, 
			6 => txtBriteOFore1, 
			7 => txtBriteOFore2, 
			8 => txtBriteOFore3, 
			9 => txtBriteOFore4, 
			10 => txtBriteOFore5, 
			11 => txtBriteIBack4, 
			12 => txtBriteIBack3, 
			13 => txtBriteIBack2, 
			14 => txtBriteIBack1, 
			15 => txtBriteIMid, 
			16 => txtBriteIFore1, 
			17 => txtBriteIFore2, 
			18 => txtBriteIFore3, 
			_ => null, 
		};
	}

	private TrackBar GetBriteTrackbar(int layer)
	{
		return layer switch
		{
			0 => trkBriteOBack5, 
			1 => trkBriteOBack4, 
			2 => trkBriteOBack3, 
			3 => trkBriteOBack2, 
			4 => trkBriteOBack1, 
			5 => trkBriteOMid, 
			6 => trkBriteOFore1, 
			7 => trkBriteOFore2, 
			8 => trkBriteOFore3, 
			9 => trkBriteOFore4, 
			10 => trkBriteOFore5, 
			11 => trkBriteIBack4, 
			12 => trkBriteIBack3, 
			13 => trkBriteIBack2, 
			14 => trkBriteIBack1, 
			15 => trkBriteIMid, 
			16 => trkBriteIFore1, 
			17 => trkBriteIFore2, 
			18 => trkBriteIFore3, 
			_ => null, 
		};
	}

	private TextBox GetGammaTextbox(int layer)
	{
		return layer switch
		{
			0 => txtGammaOBack5, 
			1 => txtGammaOBack4, 
			2 => txtGammaOBack3, 
			3 => txtGammaOBack2, 
			4 => txtGammaOBack1, 
			5 => txtGammaOMid, 
			6 => txtGammaOFore1, 
			7 => txtGammaOFore2, 
			8 => txtGammaOFore3, 
			9 => txtGammaOFore4, 
			10 => txtGammaOFore5, 
			11 => txtGammaIBack4, 
			12 => txtGammaIBack3, 
			13 => txtGammaIBack2, 
			14 => txtGammaIBack1, 
			15 => txtGammaIMid, 
			16 => txtGammaIFore1, 
			17 => txtGammaIFore2, 
			18 => txtGammaIFore3, 
			_ => null, 
		};
	}

	private TrackBar GetGammaTrackbar(int layer)
	{
		return layer switch
		{
			0 => trkGammaOBack5, 
			1 => trkGammaOBack4, 
			2 => trkGammaOBack3, 
			3 => trkGammaOBack2, 
			4 => trkGammaOBack1, 
			5 => trkGammaOMid, 
			6 => trkGammaOFore1, 
			7 => trkGammaOFore2, 
			8 => trkGammaOFore3, 
			9 => trkGammaOFore4, 
			10 => trkGammaOFore5, 
			11 => trkGammaIBack4, 
			12 => trkGammaIBack3, 
			13 => trkGammaIBack2, 
			14 => trkGammaIBack1, 
			15 => trkGammaIMid, 
			16 => trkGammaIFore1, 
			17 => trkGammaIFore2, 
			18 => trkGammaIFore3, 
			_ => null, 
		};
	}

	private void trkRIBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(11, trkRIBack4, null);
	}

	private void trkGIBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(11, trkGIBack4, null);
	}

	private void trkBIBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(11, trkBIBack4, null);
	}

	private void trkSatIBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(11, trkSatIBack4, null);
	}

	private void trkTintIBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(11, trkTintIBack4, null);
	}

	private void txtRIBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(11, null, txtRIBack4);
	}

	private void txtGIBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(11, null, txtGIBack4);
	}

	private void txtBIBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(11, null, txtBIBack4);
	}

	private void txtSatIBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(11, null, txtSatIBack4);
	}

	private void txtTintIBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(11, null, txtTintIBack4);
	}

	private void trkRIBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(12, trkRIBack3, null);
	}

	private void trkGIBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(12, trkGIBack3, null);
	}

	private void trkBIBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(12, trkBIBack3, null);
	}

	private void trkSatIBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(12, trkSatIBack3, null);
	}

	private void trkTintIBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(12, trkTintIBack3, null);
	}

	private void txtRIBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(12, null, txtRIBack3);
	}

	private void txtGIBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(12, null, txtGIBack3);
	}

	private void txtBIBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(12, null, txtBIBack3);
	}

	private void txtSatIBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(12, null, txtSatIBack3);
	}

	private void txtTintIBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(12, null, txtTintIBack3);
	}

	private void trkRIBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(13, trkRIBack2, null);
	}

	private void trkGIBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(13, trkGIBack2, null);
	}

	private void trkBIBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(13, trkBIBack2, null);
	}

	private void trkSatIBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(13, trkSatIBack2, null);
	}

	private void trkTintIBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(13, trkTintIBack2, null);
	}

	private void txtRIBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(13, null, txtRIBack2);
	}

	private void txtGIBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(13, null, txtGIBack2);
	}

	private void txtBIBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(13, null, txtBIBack2);
	}

	private void txtSatIBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(13, null, txtSatIBack2);
	}

	private void txtTintIBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(13, null, txtTintIBack2);
	}

	private void trkRIBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(14, trkRIBack1, null);
	}

	private void trkGIBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(14, trkGIBack1, null);
	}

	private void trkBIBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(14, trkBIBack1, null);
	}

	private void trkSatIBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(14, trkSatIBack1, null);
	}

	private void trkTintIBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(14, trkTintIBack1, null);
	}

	private void txtRIBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(14, null, txtRIBack1);
	}

	private void txtGIBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(14, null, txtGIBack1);
	}

	private void txtBIBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(14, null, txtBIBack1);
	}

	private void txtSatIBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(14, null, txtSatIBack1);
	}

	private void txtTintIBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(14, null, txtTintIBack1);
	}

	private void trkRIMid_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(15, trkRIMid, null);
	}

	private void trkGIMid_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(15, trkGIMid, null);
	}

	private void trkBIMid_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(15, trkBIMid, null);
	}

	private void trkSatIMid_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(15, trkSatIMid, null);
	}

	private void trkTintIMid_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(15, trkTintIMid, null);
	}

	private void txtRIMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(15, null, txtRIMid);
	}

	private void txtGIMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(15, null, txtGIMid);
	}

	private void txtBIMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(15, null, txtBIMid);
	}

	private void txtSatIMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(15, null, txtSatIMid);
	}

	private void txtTintIMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(15, null, txtTintIMid);
	}

	private void trkRIFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(16, trkRIFore1, null);
	}

	private void trkGIFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(16, trkGIFore1, null);
	}

	private void trkBIFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(16, trkBIFore1, null);
	}

	private void trkSatIFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(16, trkSatIFore1, null);
	}

	private void trkTintIFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(16, trkTintIFore1, null);
	}

	private void txtRIFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(16, null, txtRIFore1);
	}

	private void txtGIFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(16, null, txtGIFore1);
	}

	private void txtBIFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(16, null, txtBIFore1);
	}

	private void txtSatIFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(16, null, txtSatIFore1);
	}

	private void txtTintIFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(16, null, txtTintIFore1);
	}

	private void trkRIFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(17, trkRIFore2, null);
	}

	private void trkGIFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(17, trkGIFore2, null);
	}

	private void trkBIFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(17, trkBIFore2, null);
	}

	private void trkSatIFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(17, trkSatIFore2, null);
	}

	private void trkTintIFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(17, trkTintIFore2, null);
	}

	private void txtRIFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(17, null, txtRIFore2);
	}

	private void txtGIFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(17, null, txtGIFore2);
	}

	private void txtBIFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(17, null, txtBIFore2);
	}

	private void txtSatIFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(17, null, txtSatIFore2);
	}

	private void txtTintIFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(17, null, txtTintIFore2);
	}

	private void trkRIFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(18, trkRIFore3, null);
	}

	private void trkGIFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(18, trkGIFore3, null);
	}

	private void trkBIFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(18, trkBIFore3, null);
	}

	private void trkSatIFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(18, trkSatIFore3, null);
	}

	private void trkTintIFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(18, trkTintIFore3, null);
	}

	private void txtRIFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(18, null, txtRIFore3);
	}

	private void txtGIFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(18, null, txtGIFore3);
	}

	private void txtBIFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(18, null, txtBIFore3);
	}

	private void txtSatIFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(18, null, txtSatIFore3);
	}

	private void txtTintIFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(18, null, txtTintIFore3);
	}

	private void trkROBack5_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(0, trkROBack5, null);
	}

	private void trkGOBack5_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(0, trkGOBack5, null);
	}

	private void trkBOBack5_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(0, trkBOBack5, null);
	}

	private void trkSatOBack5_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(0, trkSatOBack5, null);
	}

	private void trkTintOBack5_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(0, trkTintOBack5, null);
	}

	private void txtROBack5_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(0, null, txtROBack5);
	}

	private void txtGOBack5_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(0, null, txtGOBack5);
	}

	private void txtBOBack5_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(0, null, txtBOBack5);
	}

	private void txtSatOBack5_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(0, null, txtSatOBack5);
	}

	private void txtTintOBack5_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(0, null, txtTintOBack5);
	}

	private void trkROBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(1, trkROBack4, null);
	}

	private void trkGOBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(1, trkGOBack4, null);
	}

	private void trkBOBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(1, trkBOBack4, null);
	}

	private void trkSatOBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(1, trkSatOBack4, null);
	}

	private void trkTintOBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(1, trkTintOBack4, null);
	}

	private void txtROBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(1, null, txtROBack4);
	}

	private void txtGOBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(1, null, txtGOBack4);
	}

	private void txtBOBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(1, null, txtBOBack4);
	}

	private void txtSatOBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(1, null, txtSatOBack4);
	}

	private void txtTintOBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(1, null, txtTintOBack4);
	}

	private void trkROBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(2, trkROBack3, null);
	}

	private void trkGOBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(2, trkGOBack3, null);
	}

	private void trkBOBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(2, trkBOBack3, null);
	}

	private void trkSatOBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(2, trkSatOBack3, null);
	}

	private void trkTintOBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(2, trkTintOBack3, null);
	}

	private void txtROBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(2, null, txtROBack3);
	}

	private void txtGOBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(2, null, txtGOBack3);
	}

	private void txtBOBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(2, null, txtBOBack3);
	}

	private void txtSatOBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(2, null, txtSatOBack3);
	}

	private void txtTintOBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(2, null, txtTintOBack3);
	}

	private void trkROBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(3, trkROBack2, null);
	}

	private void trkGOBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(3, trkGOBack2, null);
	}

	private void trkBOBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(3, trkBOBack2, null);
	}

	private void trkSatOBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(3, trkSatOBack2, null);
	}

	private void trkTintOBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(3, trkTintOBack2, null);
	}

	private void txtROBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(3, null, txtROBack2);
	}

	private void txtGOBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(3, null, txtGOBack2);
	}

	private void txtBOBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(3, null, txtBOBack2);
	}

	private void txtSatOBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(3, null, txtSatOBack2);
	}

	private void txtTintOBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(3, null, txtTintOBack2);
	}

	private void trkROBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(4, trkROBack1, null);
	}

	private void trkGOBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(4, trkGOBack1, null);
	}

	private void trkBOBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(4, trkBOBack1, null);
	}

	private void trkSatOBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(4, trkSatOBack1, null);
	}

	private void trkTintOBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(4, trkTintOBack1, null);
	}

	private void txtROBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(4, null, txtROBack1);
	}

	private void txtGOBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(4, null, txtGOBack1);
	}

	private void txtBOBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(4, null, txtBOBack1);
	}

	private void txtSatOBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(4, null, txtSatOBack1);
	}

	private void txtTintOBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(4, null, txtTintOBack1);
	}

	private void trkROMid_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(5, trkROMid, null);
	}

	private void trkGOMid_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(5, trkGOMid, null);
	}

	private void trkBOMid_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(5, trkBOMid, null);
	}

	private void trkSatOMid_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(5, trkSatOMid, null);
	}

	private void trkTintOMid_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(5, trkTintOMid, null);
	}

	private void txtROMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(5, null, txtROMid);
	}

	private void txtGOMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(5, null, txtGOMid);
	}

	private void txtBOMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(5, null, txtBOMid);
	}

	private void txtSatOMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(5, null, txtSatOMid);
	}

	private void txtTintOMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(5, null, txtTintOMid);
	}

	private void trkROFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(6, trkROFore1, null);
	}

	private void trkGOFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(6, trkGOFore1, null);
	}

	private void trkBOFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(6, trkBOFore1, null);
	}

	private void trkSatOFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(6, trkSatOFore1, null);
	}

	private void trkTintOFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(6, trkTintOFore1, null);
	}

	private void txtROFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(6, null, txtROFore1);
	}

	private void txtGOFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(6, null, txtGOFore1);
	}

	private void txtBOFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(6, null, txtBOFore1);
	}

	private void txtSatOFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(6, null, txtSatOFore1);
	}

	private void txtTintOFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(6, null, txtTintOFore1);
	}

	private void trkROFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(7, trkROFore2, null);
	}

	private void trkGOFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(7, trkGOFore2, null);
	}

	private void trkBOFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(7, trkBOFore2, null);
	}

	private void trkSatOFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(7, trkSatOFore2, null);
	}

	private void trkTintOFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(7, trkTintOFore2, null);
	}

	private void txtROFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(7, null, txtROFore2);
	}

	private void txtGOFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(7, null, txtGOFore2);
	}

	private void txtBOFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(7, null, txtBOFore2);
	}

	private void txtSatOFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(7, null, txtSatOFore2);
	}

	private void txtTintOFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(7, null, txtTintOFore2);
	}

	private void trkROFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(8, trkROFore3, null);
	}

	private void trkGOFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(8, trkGOFore3, null);
	}

	private void trkBOFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(8, trkBOFore3, null);
	}

	private void trkSatOFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(8, trkSatOFore3, null);
	}

	private void trkTintOFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(8, trkTintOFore3, null);
	}

	private void txtROFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(8, null, txtROFore3);
	}

	private void txtGOFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(8, null, txtGOFore3);
	}

	private void txtBOFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(8, null, txtBOFore3);
	}

	private void txtSatOFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(8, null, txtSatOFore3);
	}

	private void txtTintOFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(8, null, txtTintOFore3);
	}

	private void trkROFore4_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(9, trkROFore4, null);
	}

	private void trkGOFore4_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(9, trkGOFore4, null);
	}

	private void trkBOFore4_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(9, trkBOFore4, null);
	}

	private void trkSatOFore4_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(9, trkSatOFore4, null);
	}

	private void trkTintOFore4_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(9, trkTintOFore4, null);
	}

	private void txtROFore4_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(9, null, txtROFore4);
	}

	private void txtGOFore4_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(9, null, txtGOFore4);
	}

	private void txtBOFore4_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(9, null, txtBOFore4);
	}

	private void txtSatOFore4_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(9, null, txtSatOFore4);
	}

	private void txtTintOFore4_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(9, null, txtTintOFore4);
	}

	private void trkROFore5_Scroll(object sender, EventArgs e)
	{
		SetLayerRed(10, trkROFore5, null);
	}

	private void trkGOFore5_Scroll(object sender, EventArgs e)
	{
		SetLayerGreen(10, trkGOFore5, null);
	}

	private void trkBOFore5_Scroll(object sender, EventArgs e)
	{
		SetLayerBlue(10, trkBOFore5, null);
	}

	private void trkSatOFore5_Scroll(object sender, EventArgs e)
	{
		SetLayerSat(10, trkSatOFore5, null);
	}

	private void trkTintOFore5_Scroll(object sender, EventArgs e)
	{
		SetLayerTint(10, trkTintOFore5, null);
	}

	private void txtROFore5_TextChanged(object sender, EventArgs e)
	{
		SetLayerRed(10, null, txtROFore5);
	}

	private void txtGOFore5_TextChanged(object sender, EventArgs e)
	{
		SetLayerGreen(10, null, txtGOFore5);
	}

	private void txtBOFore5_TextChanged(object sender, EventArgs e)
	{
		SetLayerBlue(10, null, txtBOFore5);
	}

	private void txtSatOFore5_TextChanged(object sender, EventArgs e)
	{
		SetLayerSat(10, null, txtSatOFore5);
	}

	private void txtTintOFore5_TextChanged(object sender, EventArgs e)
	{
		SetLayerTint(10, null, txtTintOFore5);
	}

	private void trkpR_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.pR = SetTrackValue(trkpR, txtpR);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkpG_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.pG = SetTrackValue(trkpG, txtpG);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkpB_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.pB = SetTrackValue(trkpB, txtpB);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkpA_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.pA = SetTrackValue(trkpA, txtpA);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtpR_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.pR = SetTextValue(trkpR, txtpR);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtpG_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.pG = SetTextValue(trkpG, txtpG);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtpB_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.pB = SetTextValue(trkpB, txtpB);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtpA_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.pA = SetTextValue(trkpA, txtpA);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trktR_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.tR = SetTrackValue(trktR, txttR);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trktG_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.tG = SetTrackValue(trktG, txttG);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trktB_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.tB = SetTrackValue(trktB, txttB);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkbR_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bR = SetTrackValue(trkbR, txtbR);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkbG_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bG = SetTrackValue(trkbG, txtbG);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkbB_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bB = SetTrackValue(trkbB, txtbB);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txttR_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.tR = SetTextValue(trktR, txttR);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txttG_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.tG = SetTextValue(trktG, txttG);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txttB_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.tB = SetTextValue(trktB, txttB);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtbR_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bR = SetTextValue(trkbR, txtbR);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtbG_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bG = SetTextValue(trkbG, txtbG);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtbB_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bB = SetTextValue(trkbB, txtbB);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkBloodAlpha_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bloodAlpha = SetTrackValue(trkBloodAlpha, txtBloodAlpha);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkBloodSat_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bloodSat = SetTrackValue(trkBloodSat, txtBloodSat);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtBloodAlpha_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bloodAlpha = SetTextValue(trkBloodAlpha, txtBloodAlpha);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtBloodSat_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bloodSat = SetTextValue(trkBloodSat, txtBloodSat);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkBloomThresh_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bloomThreshhold = SetTrackValue(trkBloomThresh, txtBloomThresh);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkBloomBase_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bloomBase = SetTrackValue(trkBloomBase, txtBloomBase);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkBloomIntensity_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bloomIntensity = SetTrackValue(trkBloomIntensity, txtBloomIntensity);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkBloomSat_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bloomSat = SetTrackValue(trkBloomSat, txtBloomSat);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkBloomFloor_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.floorVal = SetTrackValue(trkBloomFloor, txtBloomFloor);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtBloomThresh_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bloomThreshhold = SetTextValue(trkBloomThresh, txtBloomThresh);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtBloomBase_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bloomBase = SetTextValue(trkBloomBase, txtBloomBase);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtBloomIntensity_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bloomIntensity = SetTextValue(trkBloomIntensity, txtBloomIntensity);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtBloomSat_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bloomSat = SetTextValue(trkBloomSat, txtBloomSat);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtBloomFloor_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.floorVal = SetTextValue(trkBloomFloor, txtBloomFloor);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkLightThresh_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.lightThresh = SetTrackValue(trkLightThresh, txtLightThresh);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkLightBlue_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.lightBlue = SetTrackValue(trkLightBlue, txtLightBlue);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkLightRed_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.lightRed = SetTrackValue(trkLightRed, txtLightRed);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkLightDesat_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.lightDesat = SetTrackValue(trkLightDesat, txtLightDesat);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkDarkBlur_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.darkBlur = SetTrackValue(trkDarkBlur, txtDarkBlur);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkLightMap_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.lightMap = SetTrackValue(trkLightMap, txtLightMap);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkLightFac_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.lightFac = SetTrackValue(trkLightFac, txtLightFac);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtLightThresh_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.lightThresh = SetTextValue(trkLightThresh, txtLightThresh);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtLightBlue_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.lightBlue = SetTextValue(trkLightBlue, txtLightBlue);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtLightRed_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.lightRed = SetTextValue(trkLightRed, txtLightRed);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtLightDesat_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.lightDesat = SetTextValue(trkLightDesat, txtLightDesat);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtDarkBlur_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.darkBlur = SetTextValue(trkDarkBlur, txtDarkBlur);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtLightMap_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.lightMap = SetTextValue(trkLightMap, txtLightMap);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtLightFac_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.lightFac = SetTextValue(trkLightFac, txtLightFac);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkburnR_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.burnR = SetTrackValue(trkburnR, txtburnR);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkburnG_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.burnG = SetTrackValue(trkburnG, txtburnG);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkburnB_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.burnB = SetTrackValue(trkburnB, txtburnB);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtburnR_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.burnR = SetTextValue(trkburnR, txtburnR);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtburnG_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.burnG = SetTextValue(trkburnG, txtburnG);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtburnB_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.burnB = SetTextValue(trkburnB, txtburnB);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkbgR_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bgR = SetTrackValue(trkbgR, txtbgR);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkbgG_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bgG = SetTrackValue(trkbgG, txtbgG);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkbgB_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bgB = SetTrackValue(trkbgB, txtbgB);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtbgR_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bgR = SetTextValue(trkbgR, txtbgR);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtbgG_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bgG = SetTextValue(trkbgG, txtbgG);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtbgB_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.bgB = SetTextValue(trkbgB, txtbgB);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkDotsAlpha_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.dotsAlpha = SetTrackValue(trkDotsAlpha, txtDotsAlpha);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkSnowAlpha_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.snowAlpha = SetTrackValue(trkSnowAlpha, txtSnowAlpha);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkRainAlpha_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.rainAlpha = SetTrackValue(trkRainAlpha, txtRainAlpha);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkLeavesAlpha_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.leavesAlpha = SetTrackValue(trkLeavesAlpha, txtLeavesAlpha);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtDotsAlpha_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.dotsAlpha = SetTextValue(trkDotsAlpha, txtDotsAlpha);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtSnowAlpha_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.snowAlpha = SetTextValue(trkSnowAlpha, txtSnowAlpha);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtRainAlpha_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.rainAlpha = SetTextValue(trkRainAlpha, txtRainAlpha);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtLeavesAlpha_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.leavesAlpha = SetTextValue(trkLeavesAlpha, txtLeavesAlpha);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkGamma_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.gamma = SetTrackValue(trkGamma, txtGamma);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkBaseSat_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.sat = SetTrackValue(trkBaseSat, txtBaseSat);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void trkBrite_Scroll(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.brite = SetTrackValue(trkBrite, txtBrite);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtGamma_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.gamma = SetTextValue(trkGamma, txtGamma);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtBaseSat_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.sat = SetTextValue(trkBaseSat, txtBaseSat);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void txtBrite_TextChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.brite = SetTextValue(trkBrite, txtBrite);
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void chkIndoors_CheckedChanged(object sender, EventArgs e)
	{
		if (IsValidLayerSelected())
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.indoors = chkIndoors.Checked;
			LayerTintCatalog.layerTintData[selLayer] = value;
		}
	}

	private void lstLayers_MouseClick(object sender, MouseEventArgs e)
	{
	}

	private void lstLayers_MouseUp(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			layerMenu.Show(lstLayers, new Point(e.X, e.Y));
		}
	}

	private void lstLayers_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstLayers.SelectedItems.Count == 1)
		{
			selLayer = lstLayers.SelectedIndices[0];
			RefreshControls();
		}
	}

	private void lstLayers_AfterLabelEdit(object sender, LabelEditEventArgs e)
	{
		if (e.Label != null)
		{
			LayerTintCatalog.LayerTintData value = LayerTintCatalog.layerTintData[selLayer];
			value.name = e.Label;
			LayerTintCatalog.layerTintData[selLayer] = value;
			RefreshLayerList();
		}
	}

	internal void Init()
	{
		RefreshLayerList();
		RefreshControls();
	}

	private void InterpolateLayer(LayerTintCatalog.LayerTintLayer[] layerTintLayer, int lowLayer, int midLayer, int highLayer, float prog)
	{
		layerTintLayer[midLayer].r = layerTintLayer[lowLayer].r + (layerTintLayer[highLayer].r - layerTintLayer[lowLayer].r) * prog;
		layerTintLayer[midLayer].g = layerTintLayer[lowLayer].g + (layerTintLayer[highLayer].g - layerTintLayer[lowLayer].g) * prog;
		layerTintLayer[midLayer].b = layerTintLayer[lowLayer].b + (layerTintLayer[highLayer].b - layerTintLayer[lowLayer].b) * prog;
		layerTintLayer[midLayer].sat = layerTintLayer[lowLayer].sat + (layerTintLayer[highLayer].sat - layerTintLayer[lowLayer].sat) * prog;
		layerTintLayer[midLayer].tint = layerTintLayer[lowLayer].tint + (layerTintLayer[highLayer].tint - layerTintLayer[lowLayer].tint) * prog;
	}

	private void midInclusiveToolStripMenuItem_Click(object sender, EventArgs e)
	{
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 11, 12, 15, 0.25f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 11, 13, 15, 0.5f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 11, 14, 15, 0.75f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 15, 16, 18, 0.33f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 15, 17, 18, 0.67f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 0, 1, 5, 0.2f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 0, 2, 5, 0.4f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 0, 3, 5, 0.6f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 0, 4, 5, 0.8f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 5, 6, 10, 0.2f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 5, 7, 10, 0.4f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 5, 8, 10, 0.6f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 5, 9, 10, 0.8f);
		RefreshControls();
	}

	private void midExclusiveToolStripMenuItem_Click(object sender, EventArgs e)
	{
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 11, 12, 14, 0.33f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 11, 13, 14, 0.67f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 0, 1, 4, 0.25f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 0, 2, 4, 0.5f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 0, 3, 4, 0.75f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 7, 8, 10, 0.33f);
		InterpolateLayer(LayerTintCatalog.layerTintData[selLayer].layerTintLayer, 7, 9, 10, 0.67f);
		RefreshControls();
	}

	private void openToolStripMenuItem_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Zka Layer Tint Extension|*.zlt";
		string path = Program.gui.GetPath();
		if (Directory.Exists(path))
		{
			openFileDialog.InitialDirectory = path;
		}
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			fullPath = openFileDialog.FileName;
			BinaryReader binaryReader = new BinaryReader(File.Open(fullPath, FileMode.Open, FileAccess.Read));
			LayerTintCatalog.Read(binaryReader);
			binaryReader.Close();
			Program.gui.ConsoleWriteLine("Layer Tint Data read.");
			saveToolStripMenuItem.Enabled = true;
			selLayer = 0;
			RefreshControls();
		}
	}

	private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "Zka Layer Tint Extension|*.zlt";
		string path = Program.gui.GetPath();
		if (Directory.Exists(path))
		{
			saveFileDialog.InitialDirectory = path;
		}
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			fullPath = saveFileDialog.FileName;
			BinaryWriter binaryWriter = new BinaryWriter(File.Open(fullPath, FileMode.OpenOrCreate, FileAccess.Write));
			LayerTintCatalog.Write(binaryWriter);
			binaryWriter.Close();
			saveToolStripMenuItem.Enabled = true;
			Program.gui.ConsoleWriteLine("Layer Tint Data written.");
		}
	}

	private void saveToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (fullPath != null && File.Exists(fullPath))
		{
			BinaryWriter binaryWriter = new BinaryWriter(File.Open(fullPath, FileMode.OpenOrCreate, FileAccess.Write));
			LayerTintCatalog.Write(binaryWriter);
			binaryWriter.Close();
			Program.gui.ConsoleWriteLine("Layer Tint Data written.");
		}
	}

	internal void LayerTintDataLoaded(string path)
	{
		fullPath = path;
		saveToolStripMenuItem.Enabled = true;
	}

	private void trkBriteIBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(11, trkBriteIBack4, null);
	}

	private void txtBriteIBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(11, null, txtBriteIBack4);
	}

	private void trkGammaIBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(11, trkGammaIBack4, null);
	}

	private void txtGammaIBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(11, null, txtGammaIBack4);
	}

	private void trkBriteIBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(12, trkBriteIBack3, null);
	}

	private void txtBriteIBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(12, null, txtBriteIBack3);
	}

	private void trkGammaIBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(12, trkGammaIBack3, null);
	}

	private void txtGammaIBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(12, null, txtGammaIBack3);
	}

	private void trkBriteIBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(13, trkBriteIBack2, null);
	}

	private void txtBriteIBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(13, null, txtBriteIBack2);
	}

	private void trkGammaIBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(13, trkGammaIBack2, null);
	}

	private void txtGammaIBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(13, null, txtGammaIBack2);
	}

	private void trkBriteIBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(14, trkBriteIBack1, null);
	}

	private void txtBriteIBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(14, null, txtBriteIBack1);
	}

	private void trkGammaIBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(14, trkGammaIBack1, null);
	}

	private void txtGammaIBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(14, null, txtGammaIBack1);
	}

	private void trkBriteIMid_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(15, trkBriteIMid, null);
	}

	private void txtBriteIMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(15, null, txtBriteIMid);
	}

	private void trkGammaIMid_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(15, trkGammaIMid, null);
	}

	private void txtGammaIMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(15, null, txtGammaIMid);
	}

	private void trkBriteIFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(16, trkBriteIFore1, null);
	}

	private void txtBriteIFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(16, null, txtBriteIFore1);
	}

	private void trkGammaIFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(16, trkGammaIFore1, null);
	}

	private void txtGammaIFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(16, null, txtGammaIFore1);
	}

	private void trkBriteIFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(17, trkBriteIFore2, null);
	}

	private void txtBriteIFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(17, null, txtBriteIFore2);
	}

	private void trkGammaIFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(17, trkGammaIFore2, null);
	}

	private void txtGammaIFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(17, null, txtGammaIFore2);
	}

	private void trkBriteIFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(18, trkBriteIFore3, null);
	}

	private void txtBriteIFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(18, null, txtBriteIFore3);
	}

	private void trkGammaIFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(18, trkGammaIFore3, null);
	}

	private void txtGammaIFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(18, null, txtGammaIFore3);
	}

	private void trkBriteOBack5_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(0, trkBriteOBack5, null);
	}

	private void txtBriteOBack5_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(0, null, txtBriteOBack5);
	}

	private void trkGammaOBack5_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(0, trkGammaOBack5, null);
	}

	private void txtGammaOBack5_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(0, null, txtGammaOBack5);
	}

	private void trkBriteOBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(1, trkBriteOBack4, null);
	}

	private void txtBriteOBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(1, null, txtBriteOBack4);
	}

	private void trkGammaOBack4_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(1, trkGammaOBack4, null);
	}

	private void txtGammaOBack4_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(1, null, txtGammaOBack4);
	}

	private void trkBriteOBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(2, trkBriteOBack3, null);
	}

	private void txtBriteOBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(2, null, txtBriteOBack3);
	}

	private void trkGammaOBack3_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(2, trkGammaOBack3, null);
	}

	private void txtGammaOBack3_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(2, null, txtGammaOBack3);
	}

	private void trkBriteOBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(3, trkBriteOBack2, null);
	}

	private void txtBriteOBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(3, null, txtBriteOBack2);
	}

	private void trkGammaOBack2_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(3, trkGammaOBack2, null);
	}

	private void txtGammaOBack2_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(3, null, txtGammaOBack2);
	}

	private void txtRBG_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtGBG_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBG_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtSatBG_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtTintBG_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBriteBG_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtGammaBG_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRBG_Scroll(object sender, EventArgs e)
	{
	}

	private void trkGBG_Scroll(object sender, EventArgs e)
	{
	}

	private void trkBBG_Scroll(object sender, EventArgs e)
	{
	}

	private void trkSatBG_Scroll(object sender, EventArgs e)
	{
	}

	private void trkTintBG_Scroll(object sender, EventArgs e)
	{
	}

	private void trkBriteBG_Scroll(object sender, EventArgs e)
	{
	}

	private void trkGammaBG_Scroll(object sender, EventArgs e)
	{
	}

	private void trkBriteOBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(4, trkBriteOBack1, null);
	}

	private void txtBriteOBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(4, null, txtBriteOBack1);
	}

	private void trkGammaOBack1_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(4, trkGammaOBack1, null);
	}

	private void txtGammaOBack1_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(4, null, txtGammaOBack1);
	}

	private void trkBriteOMid_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(5, trkBriteOMid, null);
	}

	private void txtBriteOMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(5, null, txtBriteOMid);
	}

	private void trkGammaOMid_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(5, trkGammaOMid, null);
	}

	private void txtGammaOMid_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(5, null, txtGammaOMid);
	}

	private void trkBriteOFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(6, trkBriteOFore1, null);
	}

	private void txtBriteOFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(6, null, txtBriteOFore1);
	}

	private void trkGammaOFore1_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(6, trkGammaOFore1, null);
	}

	private void txtGammaOFore1_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(6, null, txtGammaOFore1);
	}

	private void trkBriteOFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(7, trkBriteOFore2, null);
	}

	private void txtBriteOFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(7, null, txtBriteOFore2);
	}

	private void trkGammaOFore2_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(7, trkGammaOFore2, null);
	}

	private void txtGammaOFore2_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(7, null, txtGammaOFore2);
	}

	private void trkBriteOFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(8, trkBriteOFore3, null);
	}

	private void txtBriteOFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(8, null, txtBriteOFore3);
	}

	private void trkGammaOFore3_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(8, trkGammaOFore3, null);
	}

	private void txtGammaOFore3_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(8, null, txtGammaOFore3);
	}

	private void trkBriteOFore4_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(9, trkBriteOFore4, null);
	}

	private void txtBriteOFore4_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(9, null, txtBriteOFore4);
	}

	private void trkGammaOFore4_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(9, trkGammaOFore4, null);
	}

	private void txtGammaOFore4_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(9, null, txtGammaOFore4);
	}

	private void trkBriteOFore5_Scroll(object sender, EventArgs e)
	{
		SetLayerBrite(10, trkBriteOFore5, null);
	}

	private void txtBriteOFore5_TextChanged(object sender, EventArgs e)
	{
		SetLayerBrite(10, null, txtBriteOFore5);
	}

	private void trkGammaOFore5_Scroll(object sender, EventArgs e)
	{
		SetLayerGamma(10, trkGammaOFore5, null);
	}

	private void txtGammaOFore5_TextChanged(object sender, EventArgs e)
	{
		SetLayerGamma(10, null, txtGammaOFore5);
	}

	private void txtBRIBack4_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGIBack4_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBIBack4_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBRIBack3_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGIBack3_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBIBack3_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBRIBack2_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGIBack2_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBIBack2_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBRIBack1_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGIBack1_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBIBack1_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBRIMid_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGIMid_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBIMid_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBRIFore1_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGIFore1_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBIFore1_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBRIFore2_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGIFore2_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBIFore2_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBRIFore3_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGIFore3_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBIFore3_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBRBG_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGBG_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBBG_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBROBack5_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGOBack5_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBOBack5_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBROBack4_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGOBack4_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBOBack4_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBROBack3_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGOBack3_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBOBack3_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBROBack2_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGOBack2_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBOBack2_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBROBack1_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGOBack1_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBOBack1_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBROMid_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGOMid_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBOMid_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBROFore1_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGOFore1_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBOFore1_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBROFore2_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGOFore2_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBOFore2_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBROFore3_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGOFore3_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBOFore3_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBROFore4_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGOFore4_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBOFore4_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBROFore5_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBGOFore5_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtBBOFore5_TextChanged(object sender, EventArgs e)
	{
	}

	private void label252_Click(object sender, EventArgs e)
	{
	}

	private void lstLayers_MouseDoubleClick(object sender, MouseEventArgs e)
	{
	}

	private void trkRainStretch0_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainStretch0_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainStretch2_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainStretch2_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainStretch1_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainStretch1_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainStretch3_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainStretch3_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainAlpha0_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainAlpha0_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainAlpha2_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainAlpha2_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainAlpha1_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainAlpha1_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainAlpha3_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainAlpha3_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainSkewBase0_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainSkewBase0_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainSkewBase2_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainSkewBase2_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainSkewBase1_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainSkewBase1_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainSkewBase3_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainSkewBase3_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainSkewAdjust0_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainSkewAdjust0_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainSkewAdjust2_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainSkewAdjust2_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainSkewAdjust1_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainSkewAdjust1_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainSkewAdjust3_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainSkewAdjust3_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainStretch4_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainStretch4_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainAlpha4_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainAlpha4_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainSkewBase4_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainSkewBase4_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainSkewAdjust4_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainSkewAdjust4_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainR0_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainR0_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainG0_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainG0_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainB0_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainB0_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainR1_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainR1_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainG1_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainG1_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainB1_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainB1_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainStretch5_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainStretch5_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainAlpha5_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainAlpha5_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainSkewBase5_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainSkewBase5_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainSkewAdjust5_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainSkewAdjust5_TextChanged(object sender, EventArgs e)
	{
	}

	private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
	}

	private void chkStarry_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkSndBugs_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkSndCave_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkSndCaveDrips_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkSndChains_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkSndCreak_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkSndDrips_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkSndDungeon_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkSndRainIn_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkSndRain_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkSndStorm_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkSndLightRain_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkLightning_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkSanctuary_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkNoGravestones_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkNoMusic_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void trkRefractRainB_Scroll(object sender, EventArgs e)
	{
	}

	private void trkRefractRainG_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRefractRainR_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRefractRainR_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRefractRainG_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtRefractRainB_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtRefractRainGlow_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRefractRainGlow_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRefractRainGlimmer_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRefractRainGlimmer_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRefractRainDark_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRefractRainDark_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRefractRainBrite_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRefractRainBrite_Scroll(object sender, EventArgs e)
	{
	}

	private void trkRainGamma3_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainGamma1_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainGamma1_Scroll(object sender, EventArgs e)
	{
	}

	private void txtRainGamma2_TextChanged(object sender, EventArgs e)
	{
	}

	private void textBox2_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkRainGamma2_Scroll(object sender, EventArgs e)
	{
	}

	private void txtBloomDesatBase_TextChanged(object sender, EventArgs e)
	{
	}

	private void trkBloomDesatBase_Scroll(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.label1 = new System.Windows.Forms.Label();
		this.trkROBack5 = new System.Windows.Forms.TrackBar();
		this.txtROBack5 = new System.Windows.Forms.TextBox();
		this.panel1 = new System.Windows.Forms.Panel();
		this.trkGammaOBack5 = new System.Windows.Forms.TrackBar();
		this.txtGammaOBack5 = new System.Windows.Forms.TextBox();
		this.label177 = new System.Windows.Forms.Label();
		this.trkBriteOBack5 = new System.Windows.Forms.TrackBar();
		this.txtBriteOBack5 = new System.Windows.Forms.TextBox();
		this.label178 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.trkTintOBack5 = new System.Windows.Forms.TrackBar();
		this.txtTintOBack5 = new System.Windows.Forms.TextBox();
		this.label5 = new System.Windows.Forms.Label();
		this.trkSatOBack5 = new System.Windows.Forms.TrackBar();
		this.txtSatOBack5 = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.trkBOBack5 = new System.Windows.Forms.TrackBar();
		this.txtBOBack5 = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.trkGOBack5 = new System.Windows.Forms.TrackBar();
		this.txtGOBack5 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.panel2 = new System.Windows.Forms.Panel();
		this.trkGammaOBack4 = new System.Windows.Forms.TrackBar();
		this.txtGammaOBack4 = new System.Windows.Forms.TextBox();
		this.label179 = new System.Windows.Forms.Label();
		this.trkBriteOBack4 = new System.Windows.Forms.TrackBar();
		this.txtBriteOBack4 = new System.Windows.Forms.TextBox();
		this.label180 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.trkTintOBack4 = new System.Windows.Forms.TrackBar();
		this.txtTintOBack4 = new System.Windows.Forms.TextBox();
		this.label8 = new System.Windows.Forms.Label();
		this.trkSatOBack4 = new System.Windows.Forms.TrackBar();
		this.txtSatOBack4 = new System.Windows.Forms.TextBox();
		this.label9 = new System.Windows.Forms.Label();
		this.trkBOBack4 = new System.Windows.Forms.TrackBar();
		this.txtBOBack4 = new System.Windows.Forms.TextBox();
		this.label10 = new System.Windows.Forms.Label();
		this.trkGOBack4 = new System.Windows.Forms.TrackBar();
		this.txtGOBack4 = new System.Windows.Forms.TextBox();
		this.label11 = new System.Windows.Forms.Label();
		this.trkROBack4 = new System.Windows.Forms.TrackBar();
		this.txtROBack4 = new System.Windows.Forms.TextBox();
		this.label12 = new System.Windows.Forms.Label();
		this.panel3 = new System.Windows.Forms.Panel();
		this.trkGammaOBack3 = new System.Windows.Forms.TrackBar();
		this.txtGammaOBack3 = new System.Windows.Forms.TextBox();
		this.label181 = new System.Windows.Forms.Label();
		this.trkBriteOBack3 = new System.Windows.Forms.TrackBar();
		this.txtBriteOBack3 = new System.Windows.Forms.TextBox();
		this.label182 = new System.Windows.Forms.Label();
		this.label13 = new System.Windows.Forms.Label();
		this.trkTintOBack3 = new System.Windows.Forms.TrackBar();
		this.txtTintOBack3 = new System.Windows.Forms.TextBox();
		this.label14 = new System.Windows.Forms.Label();
		this.trkSatOBack3 = new System.Windows.Forms.TrackBar();
		this.txtSatOBack3 = new System.Windows.Forms.TextBox();
		this.label15 = new System.Windows.Forms.Label();
		this.trkBOBack3 = new System.Windows.Forms.TrackBar();
		this.txtBOBack3 = new System.Windows.Forms.TextBox();
		this.label16 = new System.Windows.Forms.Label();
		this.trkGOBack3 = new System.Windows.Forms.TrackBar();
		this.txtGOBack3 = new System.Windows.Forms.TextBox();
		this.label17 = new System.Windows.Forms.Label();
		this.trkROBack3 = new System.Windows.Forms.TrackBar();
		this.txtROBack3 = new System.Windows.Forms.TextBox();
		this.label18 = new System.Windows.Forms.Label();
		this.panel4 = new System.Windows.Forms.Panel();
		this.trkGammaOBack2 = new System.Windows.Forms.TrackBar();
		this.txtGammaOBack2 = new System.Windows.Forms.TextBox();
		this.label183 = new System.Windows.Forms.Label();
		this.trkBriteOBack2 = new System.Windows.Forms.TrackBar();
		this.txtBriteOBack2 = new System.Windows.Forms.TextBox();
		this.label184 = new System.Windows.Forms.Label();
		this.label19 = new System.Windows.Forms.Label();
		this.trkTintOBack2 = new System.Windows.Forms.TrackBar();
		this.txtTintOBack2 = new System.Windows.Forms.TextBox();
		this.label20 = new System.Windows.Forms.Label();
		this.trkSatOBack2 = new System.Windows.Forms.TrackBar();
		this.txtSatOBack2 = new System.Windows.Forms.TextBox();
		this.label21 = new System.Windows.Forms.Label();
		this.trkBOBack2 = new System.Windows.Forms.TrackBar();
		this.txtBOBack2 = new System.Windows.Forms.TextBox();
		this.label22 = new System.Windows.Forms.Label();
		this.trkGOBack2 = new System.Windows.Forms.TrackBar();
		this.txtGOBack2 = new System.Windows.Forms.TextBox();
		this.label23 = new System.Windows.Forms.Label();
		this.trkROBack2 = new System.Windows.Forms.TrackBar();
		this.txtROBack2 = new System.Windows.Forms.TextBox();
		this.label24 = new System.Windows.Forms.Label();
		this.panel5 = new System.Windows.Forms.Panel();
		this.trkGammaOBack1 = new System.Windows.Forms.TrackBar();
		this.txtGammaOBack1 = new System.Windows.Forms.TextBox();
		this.label185 = new System.Windows.Forms.Label();
		this.trkBriteOBack1 = new System.Windows.Forms.TrackBar();
		this.txtBriteOBack1 = new System.Windows.Forms.TextBox();
		this.label186 = new System.Windows.Forms.Label();
		this.label25 = new System.Windows.Forms.Label();
		this.trkTintOBack1 = new System.Windows.Forms.TrackBar();
		this.txtTintOBack1 = new System.Windows.Forms.TextBox();
		this.label26 = new System.Windows.Forms.Label();
		this.trkSatOBack1 = new System.Windows.Forms.TrackBar();
		this.txtSatOBack1 = new System.Windows.Forms.TextBox();
		this.label27 = new System.Windows.Forms.Label();
		this.trkBOBack1 = new System.Windows.Forms.TrackBar();
		this.txtBOBack1 = new System.Windows.Forms.TextBox();
		this.label28 = new System.Windows.Forms.Label();
		this.trkGOBack1 = new System.Windows.Forms.TrackBar();
		this.txtGOBack1 = new System.Windows.Forms.TextBox();
		this.label29 = new System.Windows.Forms.Label();
		this.trkROBack1 = new System.Windows.Forms.TrackBar();
		this.txtROBack1 = new System.Windows.Forms.TextBox();
		this.label30 = new System.Windows.Forms.Label();
		this.panel6 = new System.Windows.Forms.Panel();
		this.trkGammaOMid = new System.Windows.Forms.TrackBar();
		this.txtGammaOMid = new System.Windows.Forms.TextBox();
		this.label187 = new System.Windows.Forms.Label();
		this.trkBriteOMid = new System.Windows.Forms.TrackBar();
		this.txtBriteOMid = new System.Windows.Forms.TextBox();
		this.label188 = new System.Windows.Forms.Label();
		this.label31 = new System.Windows.Forms.Label();
		this.trkTintOMid = new System.Windows.Forms.TrackBar();
		this.txtTintOMid = new System.Windows.Forms.TextBox();
		this.label32 = new System.Windows.Forms.Label();
		this.trkSatOMid = new System.Windows.Forms.TrackBar();
		this.txtSatOMid = new System.Windows.Forms.TextBox();
		this.label33 = new System.Windows.Forms.Label();
		this.trkBOMid = new System.Windows.Forms.TrackBar();
		this.txtBOMid = new System.Windows.Forms.TextBox();
		this.label34 = new System.Windows.Forms.Label();
		this.trkGOMid = new System.Windows.Forms.TrackBar();
		this.txtGOMid = new System.Windows.Forms.TextBox();
		this.label35 = new System.Windows.Forms.Label();
		this.trkROMid = new System.Windows.Forms.TrackBar();
		this.txtROMid = new System.Windows.Forms.TextBox();
		this.label36 = new System.Windows.Forms.Label();
		this.panel7 = new System.Windows.Forms.Panel();
		this.trkGammaOFore1 = new System.Windows.Forms.TrackBar();
		this.txtGammaOFore1 = new System.Windows.Forms.TextBox();
		this.label189 = new System.Windows.Forms.Label();
		this.trkBriteOFore1 = new System.Windows.Forms.TrackBar();
		this.txtBriteOFore1 = new System.Windows.Forms.TextBox();
		this.label190 = new System.Windows.Forms.Label();
		this.label37 = new System.Windows.Forms.Label();
		this.trkTintOFore1 = new System.Windows.Forms.TrackBar();
		this.txtTintOFore1 = new System.Windows.Forms.TextBox();
		this.label38 = new System.Windows.Forms.Label();
		this.trkSatOFore1 = new System.Windows.Forms.TrackBar();
		this.txtSatOFore1 = new System.Windows.Forms.TextBox();
		this.label39 = new System.Windows.Forms.Label();
		this.trkBOFore1 = new System.Windows.Forms.TrackBar();
		this.txtBOFore1 = new System.Windows.Forms.TextBox();
		this.label40 = new System.Windows.Forms.Label();
		this.trkGOFore1 = new System.Windows.Forms.TrackBar();
		this.txtGOFore1 = new System.Windows.Forms.TextBox();
		this.label41 = new System.Windows.Forms.Label();
		this.trkROFore1 = new System.Windows.Forms.TrackBar();
		this.txtROFore1 = new System.Windows.Forms.TextBox();
		this.label42 = new System.Windows.Forms.Label();
		this.panel8 = new System.Windows.Forms.Panel();
		this.trkGammaOFore2 = new System.Windows.Forms.TrackBar();
		this.txtGammaOFore2 = new System.Windows.Forms.TextBox();
		this.label191 = new System.Windows.Forms.Label();
		this.trkBriteOFore2 = new System.Windows.Forms.TrackBar();
		this.txtBriteOFore2 = new System.Windows.Forms.TextBox();
		this.label192 = new System.Windows.Forms.Label();
		this.label43 = new System.Windows.Forms.Label();
		this.trkTintOFore2 = new System.Windows.Forms.TrackBar();
		this.txtTintOFore2 = new System.Windows.Forms.TextBox();
		this.label44 = new System.Windows.Forms.Label();
		this.trkSatOFore2 = new System.Windows.Forms.TrackBar();
		this.txtSatOFore2 = new System.Windows.Forms.TextBox();
		this.label45 = new System.Windows.Forms.Label();
		this.trkBOFore2 = new System.Windows.Forms.TrackBar();
		this.txtBOFore2 = new System.Windows.Forms.TextBox();
		this.label46 = new System.Windows.Forms.Label();
		this.trkGOFore2 = new System.Windows.Forms.TrackBar();
		this.txtGOFore2 = new System.Windows.Forms.TextBox();
		this.label47 = new System.Windows.Forms.Label();
		this.trkROFore2 = new System.Windows.Forms.TrackBar();
		this.txtROFore2 = new System.Windows.Forms.TextBox();
		this.label48 = new System.Windows.Forms.Label();
		this.panel9 = new System.Windows.Forms.Panel();
		this.trkGammaOFore3 = new System.Windows.Forms.TrackBar();
		this.txtGammaOFore3 = new System.Windows.Forms.TextBox();
		this.label193 = new System.Windows.Forms.Label();
		this.trkBriteOFore3 = new System.Windows.Forms.TrackBar();
		this.txtBriteOFore3 = new System.Windows.Forms.TextBox();
		this.label194 = new System.Windows.Forms.Label();
		this.label49 = new System.Windows.Forms.Label();
		this.trkTintOFore3 = new System.Windows.Forms.TrackBar();
		this.txtTintOFore3 = new System.Windows.Forms.TextBox();
		this.label50 = new System.Windows.Forms.Label();
		this.trkSatOFore3 = new System.Windows.Forms.TrackBar();
		this.txtSatOFore3 = new System.Windows.Forms.TextBox();
		this.label51 = new System.Windows.Forms.Label();
		this.trkBOFore3 = new System.Windows.Forms.TrackBar();
		this.txtBOFore3 = new System.Windows.Forms.TextBox();
		this.label52 = new System.Windows.Forms.Label();
		this.trkGOFore3 = new System.Windows.Forms.TrackBar();
		this.txtGOFore3 = new System.Windows.Forms.TextBox();
		this.label53 = new System.Windows.Forms.Label();
		this.trkROFore3 = new System.Windows.Forms.TrackBar();
		this.txtROFore3 = new System.Windows.Forms.TextBox();
		this.label54 = new System.Windows.Forms.Label();
		this.panel10 = new System.Windows.Forms.Panel();
		this.trkGammaOFore4 = new System.Windows.Forms.TrackBar();
		this.txtGammaOFore4 = new System.Windows.Forms.TextBox();
		this.label195 = new System.Windows.Forms.Label();
		this.trkBriteOFore4 = new System.Windows.Forms.TrackBar();
		this.txtBriteOFore4 = new System.Windows.Forms.TextBox();
		this.label196 = new System.Windows.Forms.Label();
		this.label55 = new System.Windows.Forms.Label();
		this.trkTintOFore4 = new System.Windows.Forms.TrackBar();
		this.txtTintOFore4 = new System.Windows.Forms.TextBox();
		this.label56 = new System.Windows.Forms.Label();
		this.trkSatOFore4 = new System.Windows.Forms.TrackBar();
		this.txtSatOFore4 = new System.Windows.Forms.TextBox();
		this.label57 = new System.Windows.Forms.Label();
		this.trkBOFore4 = new System.Windows.Forms.TrackBar();
		this.txtBOFore4 = new System.Windows.Forms.TextBox();
		this.label58 = new System.Windows.Forms.Label();
		this.trkGOFore4 = new System.Windows.Forms.TrackBar();
		this.txtGOFore4 = new System.Windows.Forms.TextBox();
		this.label59 = new System.Windows.Forms.Label();
		this.trkROFore4 = new System.Windows.Forms.TrackBar();
		this.txtROFore4 = new System.Windows.Forms.TextBox();
		this.label60 = new System.Windows.Forms.Label();
		this.panel11 = new System.Windows.Forms.Panel();
		this.trkGammaOFore5 = new System.Windows.Forms.TrackBar();
		this.txtGammaOFore5 = new System.Windows.Forms.TextBox();
		this.label197 = new System.Windows.Forms.Label();
		this.trkBriteOFore5 = new System.Windows.Forms.TrackBar();
		this.txtBriteOFore5 = new System.Windows.Forms.TextBox();
		this.label198 = new System.Windows.Forms.Label();
		this.label61 = new System.Windows.Forms.Label();
		this.trkTintOFore5 = new System.Windows.Forms.TrackBar();
		this.txtTintOFore5 = new System.Windows.Forms.TextBox();
		this.label62 = new System.Windows.Forms.Label();
		this.trkSatOFore5 = new System.Windows.Forms.TrackBar();
		this.txtSatOFore5 = new System.Windows.Forms.TextBox();
		this.label63 = new System.Windows.Forms.Label();
		this.trkBOFore5 = new System.Windows.Forms.TrackBar();
		this.txtBOFore5 = new System.Windows.Forms.TextBox();
		this.label64 = new System.Windows.Forms.Label();
		this.trkGOFore5 = new System.Windows.Forms.TrackBar();
		this.txtGOFore5 = new System.Windows.Forms.TextBox();
		this.label65 = new System.Windows.Forms.Label();
		this.trkROFore5 = new System.Windows.Forms.TrackBar();
		this.txtROFore5 = new System.Windows.Forms.TextBox();
		this.label66 = new System.Windows.Forms.Label();
		this.panel12 = new System.Windows.Forms.Panel();
		this.trkGammaIFore3 = new System.Windows.Forms.TrackBar();
		this.txtGammaIFore3 = new System.Windows.Forms.TextBox();
		this.label175 = new System.Windows.Forms.Label();
		this.trkBriteIFore3 = new System.Windows.Forms.TrackBar();
		this.txtBriteIFore3 = new System.Windows.Forms.TextBox();
		this.label176 = new System.Windows.Forms.Label();
		this.label67 = new System.Windows.Forms.Label();
		this.trkTintIFore3 = new System.Windows.Forms.TrackBar();
		this.txtTintIFore3 = new System.Windows.Forms.TextBox();
		this.label68 = new System.Windows.Forms.Label();
		this.trkSatIFore3 = new System.Windows.Forms.TrackBar();
		this.txtSatIFore3 = new System.Windows.Forms.TextBox();
		this.label69 = new System.Windows.Forms.Label();
		this.trkBIFore3 = new System.Windows.Forms.TrackBar();
		this.txtBIFore3 = new System.Windows.Forms.TextBox();
		this.label70 = new System.Windows.Forms.Label();
		this.trkGIFore3 = new System.Windows.Forms.TrackBar();
		this.txtGIFore3 = new System.Windows.Forms.TextBox();
		this.label71 = new System.Windows.Forms.Label();
		this.trkRIFore3 = new System.Windows.Forms.TrackBar();
		this.txtRIFore3 = new System.Windows.Forms.TextBox();
		this.label72 = new System.Windows.Forms.Label();
		this.panel13 = new System.Windows.Forms.Panel();
		this.trkGammaIFore2 = new System.Windows.Forms.TrackBar();
		this.txtGammaIFore2 = new System.Windows.Forms.TextBox();
		this.label173 = new System.Windows.Forms.Label();
		this.trkBriteIFore2 = new System.Windows.Forms.TrackBar();
		this.txtBriteIFore2 = new System.Windows.Forms.TextBox();
		this.label174 = new System.Windows.Forms.Label();
		this.label73 = new System.Windows.Forms.Label();
		this.trkTintIFore2 = new System.Windows.Forms.TrackBar();
		this.txtTintIFore2 = new System.Windows.Forms.TextBox();
		this.label74 = new System.Windows.Forms.Label();
		this.trkSatIFore2 = new System.Windows.Forms.TrackBar();
		this.txtSatIFore2 = new System.Windows.Forms.TextBox();
		this.label75 = new System.Windows.Forms.Label();
		this.trkBIFore2 = new System.Windows.Forms.TrackBar();
		this.txtBIFore2 = new System.Windows.Forms.TextBox();
		this.label76 = new System.Windows.Forms.Label();
		this.trkGIFore2 = new System.Windows.Forms.TrackBar();
		this.txtGIFore2 = new System.Windows.Forms.TextBox();
		this.label77 = new System.Windows.Forms.Label();
		this.trkRIFore2 = new System.Windows.Forms.TrackBar();
		this.txtRIFore2 = new System.Windows.Forms.TextBox();
		this.label78 = new System.Windows.Forms.Label();
		this.panel14 = new System.Windows.Forms.Panel();
		this.trkGammaIFore1 = new System.Windows.Forms.TrackBar();
		this.txtGammaIFore1 = new System.Windows.Forms.TextBox();
		this.label171 = new System.Windows.Forms.Label();
		this.trkBriteIFore1 = new System.Windows.Forms.TrackBar();
		this.txtBriteIFore1 = new System.Windows.Forms.TextBox();
		this.label172 = new System.Windows.Forms.Label();
		this.label79 = new System.Windows.Forms.Label();
		this.trkTintIFore1 = new System.Windows.Forms.TrackBar();
		this.txtTintIFore1 = new System.Windows.Forms.TextBox();
		this.label80 = new System.Windows.Forms.Label();
		this.trkSatIFore1 = new System.Windows.Forms.TrackBar();
		this.txtSatIFore1 = new System.Windows.Forms.TextBox();
		this.label81 = new System.Windows.Forms.Label();
		this.trkBIFore1 = new System.Windows.Forms.TrackBar();
		this.txtBIFore1 = new System.Windows.Forms.TextBox();
		this.label82 = new System.Windows.Forms.Label();
		this.trkGIFore1 = new System.Windows.Forms.TrackBar();
		this.txtGIFore1 = new System.Windows.Forms.TextBox();
		this.label83 = new System.Windows.Forms.Label();
		this.trkRIFore1 = new System.Windows.Forms.TrackBar();
		this.txtRIFore1 = new System.Windows.Forms.TextBox();
		this.label84 = new System.Windows.Forms.Label();
		this.panel15 = new System.Windows.Forms.Panel();
		this.trkGammaIMid = new System.Windows.Forms.TrackBar();
		this.txtGammaIMid = new System.Windows.Forms.TextBox();
		this.label169 = new System.Windows.Forms.Label();
		this.trkBriteIMid = new System.Windows.Forms.TrackBar();
		this.txtBriteIMid = new System.Windows.Forms.TextBox();
		this.label170 = new System.Windows.Forms.Label();
		this.label85 = new System.Windows.Forms.Label();
		this.trkTintIMid = new System.Windows.Forms.TrackBar();
		this.txtTintIMid = new System.Windows.Forms.TextBox();
		this.label86 = new System.Windows.Forms.Label();
		this.trkSatIMid = new System.Windows.Forms.TrackBar();
		this.txtSatIMid = new System.Windows.Forms.TextBox();
		this.label87 = new System.Windows.Forms.Label();
		this.trkBIMid = new System.Windows.Forms.TrackBar();
		this.txtBIMid = new System.Windows.Forms.TextBox();
		this.label88 = new System.Windows.Forms.Label();
		this.trkGIMid = new System.Windows.Forms.TrackBar();
		this.txtGIMid = new System.Windows.Forms.TextBox();
		this.label89 = new System.Windows.Forms.Label();
		this.trkRIMid = new System.Windows.Forms.TrackBar();
		this.txtRIMid = new System.Windows.Forms.TextBox();
		this.label90 = new System.Windows.Forms.Label();
		this.panel16 = new System.Windows.Forms.Panel();
		this.trkGammaIBack1 = new System.Windows.Forms.TrackBar();
		this.txtGammaIBack1 = new System.Windows.Forms.TextBox();
		this.label167 = new System.Windows.Forms.Label();
		this.trkBriteIBack1 = new System.Windows.Forms.TrackBar();
		this.txtBriteIBack1 = new System.Windows.Forms.TextBox();
		this.label168 = new System.Windows.Forms.Label();
		this.label91 = new System.Windows.Forms.Label();
		this.trkTintIBack1 = new System.Windows.Forms.TrackBar();
		this.txtTintIBack1 = new System.Windows.Forms.TextBox();
		this.label92 = new System.Windows.Forms.Label();
		this.trkSatIBack1 = new System.Windows.Forms.TrackBar();
		this.txtSatIBack1 = new System.Windows.Forms.TextBox();
		this.label93 = new System.Windows.Forms.Label();
		this.trkBIBack1 = new System.Windows.Forms.TrackBar();
		this.txtBIBack1 = new System.Windows.Forms.TextBox();
		this.label94 = new System.Windows.Forms.Label();
		this.trkGIBack1 = new System.Windows.Forms.TrackBar();
		this.txtGIBack1 = new System.Windows.Forms.TextBox();
		this.label95 = new System.Windows.Forms.Label();
		this.trkRIBack1 = new System.Windows.Forms.TrackBar();
		this.txtRIBack1 = new System.Windows.Forms.TextBox();
		this.label96 = new System.Windows.Forms.Label();
		this.panel17 = new System.Windows.Forms.Panel();
		this.trkGammaIBack2 = new System.Windows.Forms.TrackBar();
		this.txtGammaIBack2 = new System.Windows.Forms.TextBox();
		this.label165 = new System.Windows.Forms.Label();
		this.trkBriteIBack2 = new System.Windows.Forms.TrackBar();
		this.txtBriteIBack2 = new System.Windows.Forms.TextBox();
		this.label166 = new System.Windows.Forms.Label();
		this.label97 = new System.Windows.Forms.Label();
		this.trkTintIBack2 = new System.Windows.Forms.TrackBar();
		this.txtTintIBack2 = new System.Windows.Forms.TextBox();
		this.label98 = new System.Windows.Forms.Label();
		this.trkSatIBack2 = new System.Windows.Forms.TrackBar();
		this.txtSatIBack2 = new System.Windows.Forms.TextBox();
		this.label99 = new System.Windows.Forms.Label();
		this.trkBIBack2 = new System.Windows.Forms.TrackBar();
		this.txtBIBack2 = new System.Windows.Forms.TextBox();
		this.label100 = new System.Windows.Forms.Label();
		this.trkGIBack2 = new System.Windows.Forms.TrackBar();
		this.txtGIBack2 = new System.Windows.Forms.TextBox();
		this.label101 = new System.Windows.Forms.Label();
		this.trkRIBack2 = new System.Windows.Forms.TrackBar();
		this.txtRIBack2 = new System.Windows.Forms.TextBox();
		this.label102 = new System.Windows.Forms.Label();
		this.panel18 = new System.Windows.Forms.Panel();
		this.trkGammaIBack3 = new System.Windows.Forms.TrackBar();
		this.txtGammaIBack3 = new System.Windows.Forms.TextBox();
		this.label163 = new System.Windows.Forms.Label();
		this.trkBriteIBack3 = new System.Windows.Forms.TrackBar();
		this.txtBriteIBack3 = new System.Windows.Forms.TextBox();
		this.label164 = new System.Windows.Forms.Label();
		this.label103 = new System.Windows.Forms.Label();
		this.trkTintIBack3 = new System.Windows.Forms.TrackBar();
		this.txtTintIBack3 = new System.Windows.Forms.TextBox();
		this.label104 = new System.Windows.Forms.Label();
		this.trkSatIBack3 = new System.Windows.Forms.TrackBar();
		this.txtSatIBack3 = new System.Windows.Forms.TextBox();
		this.label105 = new System.Windows.Forms.Label();
		this.trkBIBack3 = new System.Windows.Forms.TrackBar();
		this.txtBIBack3 = new System.Windows.Forms.TextBox();
		this.label106 = new System.Windows.Forms.Label();
		this.trkGIBack3 = new System.Windows.Forms.TrackBar();
		this.txtGIBack3 = new System.Windows.Forms.TextBox();
		this.label107 = new System.Windows.Forms.Label();
		this.trkRIBack3 = new System.Windows.Forms.TrackBar();
		this.txtRIBack3 = new System.Windows.Forms.TextBox();
		this.label108 = new System.Windows.Forms.Label();
		this.panel19 = new System.Windows.Forms.Panel();
		this.trkGammaIBack4 = new System.Windows.Forms.TrackBar();
		this.txtGammaIBack4 = new System.Windows.Forms.TextBox();
		this.label162 = new System.Windows.Forms.Label();
		this.trkBriteIBack4 = new System.Windows.Forms.TrackBar();
		this.txtBriteIBack4 = new System.Windows.Forms.TextBox();
		this.label161 = new System.Windows.Forms.Label();
		this.label109 = new System.Windows.Forms.Label();
		this.trkTintIBack4 = new System.Windows.Forms.TrackBar();
		this.txtTintIBack4 = new System.Windows.Forms.TextBox();
		this.label110 = new System.Windows.Forms.Label();
		this.trkSatIBack4 = new System.Windows.Forms.TrackBar();
		this.txtSatIBack4 = new System.Windows.Forms.TextBox();
		this.label111 = new System.Windows.Forms.Label();
		this.trkBIBack4 = new System.Windows.Forms.TrackBar();
		this.txtBIBack4 = new System.Windows.Forms.TextBox();
		this.label112 = new System.Windows.Forms.Label();
		this.trkGIBack4 = new System.Windows.Forms.TrackBar();
		this.txtGIBack4 = new System.Windows.Forms.TextBox();
		this.label113 = new System.Windows.Forms.Label();
		this.trkRIBack4 = new System.Windows.Forms.TrackBar();
		this.txtRIBack4 = new System.Windows.Forms.TextBox();
		this.label114 = new System.Windows.Forms.Label();
		this.trktB = new System.Windows.Forms.TrackBar();
		this.txttB = new System.Windows.Forms.TextBox();
		this.label115 = new System.Windows.Forms.Label();
		this.trktG = new System.Windows.Forms.TrackBar();
		this.txttG = new System.Windows.Forms.TextBox();
		this.label116 = new System.Windows.Forms.Label();
		this.trktR = new System.Windows.Forms.TrackBar();
		this.txttR = new System.Windows.Forms.TextBox();
		this.label117 = new System.Windows.Forms.Label();
		this.trkbB = new System.Windows.Forms.TrackBar();
		this.txtbB = new System.Windows.Forms.TextBox();
		this.label118 = new System.Windows.Forms.Label();
		this.trkbG = new System.Windows.Forms.TrackBar();
		this.txtbG = new System.Windows.Forms.TextBox();
		this.label119 = new System.Windows.Forms.Label();
		this.trkbR = new System.Windows.Forms.TrackBar();
		this.txtbR = new System.Windows.Forms.TextBox();
		this.label120 = new System.Windows.Forms.Label();
		this.trkbgB = new System.Windows.Forms.TrackBar();
		this.txtbgB = new System.Windows.Forms.TextBox();
		this.label121 = new System.Windows.Forms.Label();
		this.trkbgG = new System.Windows.Forms.TrackBar();
		this.txtbgG = new System.Windows.Forms.TextBox();
		this.label122 = new System.Windows.Forms.Label();
		this.trkbgR = new System.Windows.Forms.TrackBar();
		this.txtbgR = new System.Windows.Forms.TextBox();
		this.label123 = new System.Windows.Forms.Label();
		this.trkburnB = new System.Windows.Forms.TrackBar();
		this.txtburnB = new System.Windows.Forms.TextBox();
		this.trkburnG = new System.Windows.Forms.TrackBar();
		this.txtburnG = new System.Windows.Forms.TextBox();
		this.trkburnR = new System.Windows.Forms.TrackBar();
		this.txtburnR = new System.Windows.Forms.TextBox();
		this.lstLayers = new System.Windows.Forms.ListView();
		this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
		this.chkIndoors = new System.Windows.Forms.CheckBox();
		this.trkBrite = new System.Windows.Forms.TrackBar();
		this.txtBrite = new System.Windows.Forms.TextBox();
		this.label127 = new System.Windows.Forms.Label();
		this.trkGamma = new System.Windows.Forms.TrackBar();
		this.txtGamma = new System.Windows.Forms.TextBox();
		this.label128 = new System.Windows.Forms.Label();
		this.trkBloomBase = new System.Windows.Forms.TrackBar();
		this.txtBloomBase = new System.Windows.Forms.TextBox();
		this.label129 = new System.Windows.Forms.Label();
		this.trkBloomThresh = new System.Windows.Forms.TrackBar();
		this.txtBloomThresh = new System.Windows.Forms.TextBox();
		this.label130 = new System.Windows.Forms.Label();
		this.trkBloomSat = new System.Windows.Forms.TrackBar();
		this.txtBloomSat = new System.Windows.Forms.TextBox();
		this.label131 = new System.Windows.Forms.Label();
		this.trkBloomIntensity = new System.Windows.Forms.TrackBar();
		this.txtBloomIntensity = new System.Windows.Forms.TextBox();
		this.label132 = new System.Windows.Forms.Label();
		this.trkBloomFloor = new System.Windows.Forms.TrackBar();
		this.txtBloomFloor = new System.Windows.Forms.TextBox();
		this.label133 = new System.Windows.Forms.Label();
		this.trkDarkBlur = new System.Windows.Forms.TrackBar();
		this.txtDarkBlur = new System.Windows.Forms.TextBox();
		this.label134 = new System.Windows.Forms.Label();
		this.trkLightDesat = new System.Windows.Forms.TrackBar();
		this.txtLightDesat = new System.Windows.Forms.TextBox();
		this.label135 = new System.Windows.Forms.Label();
		this.trkLightRed = new System.Windows.Forms.TrackBar();
		this.txtLightRed = new System.Windows.Forms.TextBox();
		this.label136 = new System.Windows.Forms.Label();
		this.trkLightBlue = new System.Windows.Forms.TrackBar();
		this.txtLightBlue = new System.Windows.Forms.TextBox();
		this.label137 = new System.Windows.Forms.Label();
		this.trkLightThresh = new System.Windows.Forms.TrackBar();
		this.txtLightThresh = new System.Windows.Forms.TextBox();
		this.label138 = new System.Windows.Forms.Label();
		this.panel20 = new System.Windows.Forms.Panel();
		this.label139 = new System.Windows.Forms.Label();
		this.panel21 = new System.Windows.Forms.Panel();
		this.label140 = new System.Windows.Forms.Label();
		this.panel22 = new System.Windows.Forms.Panel();
		this.label124 = new System.Windows.Forms.Label();
		this.label125 = new System.Windows.Forms.Label();
		this.label126 = new System.Windows.Forms.Label();
		this.label141 = new System.Windows.Forms.Label();
		this.panel23 = new System.Windows.Forms.Panel();
		this.trkBloomDesatBase = new System.Windows.Forms.TrackBar();
		this.label245 = new System.Windows.Forms.Label();
		this.txtBloomDesatBase = new System.Windows.Forms.TextBox();
		this.label145 = new System.Windows.Forms.Label();
		this.panel24 = new System.Windows.Forms.Panel();
		this.trkLightFac = new System.Windows.Forms.TrackBar();
		this.trkLightMap = new System.Windows.Forms.TrackBar();
		this.txtLightFac = new System.Windows.Forms.TextBox();
		this.label144 = new System.Windows.Forms.Label();
		this.txtLightMap = new System.Windows.Forms.TextBox();
		this.label146 = new System.Windows.Forms.Label();
		this.label142 = new System.Windows.Forms.Label();
		this.panel25 = new System.Windows.Forms.Panel();
		this.txtBaseSat = new System.Windows.Forms.TextBox();
		this.trkBaseSat = new System.Windows.Forms.TrackBar();
		this.label147 = new System.Windows.Forms.Label();
		this.label143 = new System.Windows.Forms.Label();
		this.panel26 = new System.Windows.Forms.Panel();
		this.trkLeavesAlpha = new System.Windows.Forms.TrackBar();
		this.label152 = new System.Windows.Forms.Label();
		this.txtLeavesAlpha = new System.Windows.Forms.TextBox();
		this.trkRainAlpha = new System.Windows.Forms.TrackBar();
		this.trkSnowAlpha = new System.Windows.Forms.TrackBar();
		this.label148 = new System.Windows.Forms.Label();
		this.label149 = new System.Windows.Forms.Label();
		this.label150 = new System.Windows.Forms.Label();
		this.label151 = new System.Windows.Forms.Label();
		this.txtDotsAlpha = new System.Windows.Forms.TextBox();
		this.trkDotsAlpha = new System.Windows.Forms.TrackBar();
		this.txtSnowAlpha = new System.Windows.Forms.TextBox();
		this.txtRainAlpha = new System.Windows.Forms.TextBox();
		this.panel27 = new System.Windows.Forms.Panel();
		this.trkBloodSat = new System.Windows.Forms.TrackBar();
		this.trkBloodAlpha = new System.Windows.Forms.TrackBar();
		this.label153 = new System.Windows.Forms.Label();
		this.txtBloodAlpha = new System.Windows.Forms.TextBox();
		this.label154 = new System.Windows.Forms.Label();
		this.label155 = new System.Windows.Forms.Label();
		this.txtBloodSat = new System.Windows.Forms.TextBox();
		this.panel28 = new System.Windows.Forms.Panel();
		this.trkpA = new System.Windows.Forms.TrackBar();
		this.label160 = new System.Windows.Forms.Label();
		this.txtpA = new System.Windows.Forms.TextBox();
		this.trkpB = new System.Windows.Forms.TrackBar();
		this.trkpG = new System.Windows.Forms.TrackBar();
		this.label156 = new System.Windows.Forms.Label();
		this.label157 = new System.Windows.Forms.Label();
		this.label158 = new System.Windows.Forms.Label();
		this.label159 = new System.Windows.Forms.Label();
		this.txtpR = new System.Windows.Forms.TextBox();
		this.trkpR = new System.Windows.Forms.TrackBar();
		this.txtpG = new System.Windows.Forms.TextBox();
		this.txtpB = new System.Windows.Forms.TextBox();
		this.menuStrip1 = new System.Windows.Forms.MenuStrip();
		this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.interpolateParallaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.midInclusiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.midExclusiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.panel29 = new System.Windows.Forms.Panel();
		this.trkRainSkewAdjust0 = new System.Windows.Forms.TrackBar();
		this.label199 = new System.Windows.Forms.Label();
		this.txtRainSkewAdjust0 = new System.Windows.Forms.TextBox();
		this.trkRainSkewBase0 = new System.Windows.Forms.TrackBar();
		this.trkRainAlpha0 = new System.Windows.Forms.TrackBar();
		this.label200 = new System.Windows.Forms.Label();
		this.label201 = new System.Windows.Forms.Label();
		this.label202 = new System.Windows.Forms.Label();
		this.label203 = new System.Windows.Forms.Label();
		this.txtRainStretch0 = new System.Windows.Forms.TextBox();
		this.trkRainStretch0 = new System.Windows.Forms.TrackBar();
		this.txtRainAlpha0 = new System.Windows.Forms.TextBox();
		this.txtRainSkewBase0 = new System.Windows.Forms.TextBox();
		this.panel30 = new System.Windows.Forms.Panel();
		this.trkRainSkewAdjust1 = new System.Windows.Forms.TrackBar();
		this.label204 = new System.Windows.Forms.Label();
		this.txtRainSkewAdjust1 = new System.Windows.Forms.TextBox();
		this.trkRainSkewBase1 = new System.Windows.Forms.TrackBar();
		this.trkRainAlpha1 = new System.Windows.Forms.TrackBar();
		this.label205 = new System.Windows.Forms.Label();
		this.label206 = new System.Windows.Forms.Label();
		this.label207 = new System.Windows.Forms.Label();
		this.label208 = new System.Windows.Forms.Label();
		this.txtRainStretch1 = new System.Windows.Forms.TextBox();
		this.trkRainStretch1 = new System.Windows.Forms.TrackBar();
		this.txtRainAlpha1 = new System.Windows.Forms.TextBox();
		this.txtRainSkewBase1 = new System.Windows.Forms.TextBox();
		this.panel31 = new System.Windows.Forms.Panel();
		this.trkRainB0 = new System.Windows.Forms.TrackBar();
		this.trkRainG0 = new System.Windows.Forms.TrackBar();
		this.label210 = new System.Windows.Forms.Label();
		this.label211 = new System.Windows.Forms.Label();
		this.label212 = new System.Windows.Forms.Label();
		this.label213 = new System.Windows.Forms.Label();
		this.txtRainR0 = new System.Windows.Forms.TextBox();
		this.trkRainR0 = new System.Windows.Forms.TrackBar();
		this.txtRainG0 = new System.Windows.Forms.TextBox();
		this.txtRainB0 = new System.Windows.Forms.TextBox();
		this.tbPanels = new System.Windows.Forms.TabControl();
		this.tabPage1 = new System.Windows.Forms.TabPage();
		this.tabPage2 = new System.Windows.Forms.TabPage();
		this.panel39 = new System.Windows.Forms.Panel();
		this.trkGammaBG = new System.Windows.Forms.TrackBar();
		this.txtGammaBG = new System.Windows.Forms.TextBox();
		this.label250 = new System.Windows.Forms.Label();
		this.trkBriteBG = new System.Windows.Forms.TrackBar();
		this.txtBriteBG = new System.Windows.Forms.TextBox();
		this.label251 = new System.Windows.Forms.Label();
		this.label252 = new System.Windows.Forms.Label();
		this.trkTintBG = new System.Windows.Forms.TrackBar();
		this.txtTintBG = new System.Windows.Forms.TextBox();
		this.label253 = new System.Windows.Forms.Label();
		this.trkSatBG = new System.Windows.Forms.TrackBar();
		this.txtSatBG = new System.Windows.Forms.TextBox();
		this.label254 = new System.Windows.Forms.Label();
		this.trkBBG = new System.Windows.Forms.TrackBar();
		this.txtBBG = new System.Windows.Forms.TextBox();
		this.label255 = new System.Windows.Forms.Label();
		this.trkGBG = new System.Windows.Forms.TrackBar();
		this.txtGBG = new System.Windows.Forms.TextBox();
		this.label256 = new System.Windows.Forms.Label();
		this.trkRBG = new System.Windows.Forms.TrackBar();
		this.txtRBG = new System.Windows.Forms.TextBox();
		this.label257 = new System.Windows.Forms.Label();
		this.tabPage3 = new System.Windows.Forms.TabPage();
		this.panel38 = new System.Windows.Forms.Panel();
		this.label249 = new System.Windows.Forms.Label();
		this.txtRainGamma3 = new System.Windows.Forms.TextBox();
		this.trkRainGamma3 = new System.Windows.Forms.TrackBar();
		this.label248 = new System.Windows.Forms.Label();
		this.txtRainGamma2 = new System.Windows.Forms.TextBox();
		this.trkRainGamma2 = new System.Windows.Forms.TrackBar();
		this.label247 = new System.Windows.Forms.Label();
		this.txtRainGamma1 = new System.Windows.Forms.TextBox();
		this.trkRainGamma1 = new System.Windows.Forms.TrackBar();
		this.label246 = new System.Windows.Forms.Label();
		this.panel37 = new System.Windows.Forms.Panel();
		this.trkRefractRainB = new System.Windows.Forms.TrackBar();
		this.trkRefractRainG = new System.Windows.Forms.TrackBar();
		this.label242 = new System.Windows.Forms.Label();
		this.label243 = new System.Windows.Forms.Label();
		this.label244 = new System.Windows.Forms.Label();
		this.txtRefractRainR = new System.Windows.Forms.TextBox();
		this.trkRefractRainR = new System.Windows.Forms.TrackBar();
		this.txtRefractRainG = new System.Windows.Forms.TextBox();
		this.txtRefractRainB = new System.Windows.Forms.TextBox();
		this.label241 = new System.Windows.Forms.Label();
		this.txtRefractRainGlow = new System.Windows.Forms.TextBox();
		this.trkRefractRainGlow = new System.Windows.Forms.TrackBar();
		this.label240 = new System.Windows.Forms.Label();
		this.txtRefractRainGlimmer = new System.Windows.Forms.TextBox();
		this.trkRefractRainGlimmer = new System.Windows.Forms.TrackBar();
		this.label239 = new System.Windows.Forms.Label();
		this.txtRefractRainDark = new System.Windows.Forms.TextBox();
		this.trkRefractRainDark = new System.Windows.Forms.TrackBar();
		this.label237 = new System.Windows.Forms.Label();
		this.label238 = new System.Windows.Forms.Label();
		this.txtRefractRainBrite = new System.Windows.Forms.TextBox();
		this.trkRefractRainBrite = new System.Windows.Forms.TrackBar();
		this.panel36 = new System.Windows.Forms.Panel();
		this.trkRainSkewAdjust5 = new System.Windows.Forms.TrackBar();
		this.label232 = new System.Windows.Forms.Label();
		this.txtRainSkewAdjust5 = new System.Windows.Forms.TextBox();
		this.trkRainSkewBase5 = new System.Windows.Forms.TrackBar();
		this.trkRainAlpha5 = new System.Windows.Forms.TrackBar();
		this.label233 = new System.Windows.Forms.Label();
		this.label234 = new System.Windows.Forms.Label();
		this.label235 = new System.Windows.Forms.Label();
		this.label236 = new System.Windows.Forms.Label();
		this.txtRainStretch5 = new System.Windows.Forms.TextBox();
		this.trkRainStretch5 = new System.Windows.Forms.TrackBar();
		this.txtRainAlpha5 = new System.Windows.Forms.TextBox();
		this.txtRainSkewBase5 = new System.Windows.Forms.TextBox();
		this.panel35 = new System.Windows.Forms.Panel();
		this.trkRainSkewAdjust4 = new System.Windows.Forms.TrackBar();
		this.label227 = new System.Windows.Forms.Label();
		this.txtRainSkewAdjust4 = new System.Windows.Forms.TextBox();
		this.trkRainSkewBase4 = new System.Windows.Forms.TrackBar();
		this.trkRainAlpha4 = new System.Windows.Forms.TrackBar();
		this.label228 = new System.Windows.Forms.Label();
		this.label229 = new System.Windows.Forms.Label();
		this.label230 = new System.Windows.Forms.Label();
		this.label231 = new System.Windows.Forms.Label();
		this.txtRainStretch4 = new System.Windows.Forms.TextBox();
		this.trkRainStretch4 = new System.Windows.Forms.TrackBar();
		this.txtRainAlpha4 = new System.Windows.Forms.TextBox();
		this.txtRainSkewBase4 = new System.Windows.Forms.TextBox();
		this.panel34 = new System.Windows.Forms.Panel();
		this.trkRainB1 = new System.Windows.Forms.TrackBar();
		this.trkRainG1 = new System.Windows.Forms.TrackBar();
		this.label223 = new System.Windows.Forms.Label();
		this.label224 = new System.Windows.Forms.Label();
		this.label225 = new System.Windows.Forms.Label();
		this.label226 = new System.Windows.Forms.Label();
		this.txtRainR1 = new System.Windows.Forms.TextBox();
		this.trkRainR1 = new System.Windows.Forms.TrackBar();
		this.txtRainG1 = new System.Windows.Forms.TextBox();
		this.txtRainB1 = new System.Windows.Forms.TextBox();
		this.panel33 = new System.Windows.Forms.Panel();
		this.trkRainSkewAdjust3 = new System.Windows.Forms.TrackBar();
		this.label218 = new System.Windows.Forms.Label();
		this.txtRainSkewAdjust3 = new System.Windows.Forms.TextBox();
		this.trkRainSkewBase3 = new System.Windows.Forms.TrackBar();
		this.trkRainAlpha3 = new System.Windows.Forms.TrackBar();
		this.label219 = new System.Windows.Forms.Label();
		this.label220 = new System.Windows.Forms.Label();
		this.label221 = new System.Windows.Forms.Label();
		this.label222 = new System.Windows.Forms.Label();
		this.txtRainStretch3 = new System.Windows.Forms.TextBox();
		this.trkRainStretch3 = new System.Windows.Forms.TrackBar();
		this.txtRainAlpha3 = new System.Windows.Forms.TextBox();
		this.txtRainSkewBase3 = new System.Windows.Forms.TextBox();
		this.panel32 = new System.Windows.Forms.Panel();
		this.trkRainSkewAdjust2 = new System.Windows.Forms.TrackBar();
		this.label209 = new System.Windows.Forms.Label();
		this.txtRainSkewAdjust2 = new System.Windows.Forms.TextBox();
		this.trkRainSkewBase2 = new System.Windows.Forms.TrackBar();
		this.trkRainAlpha2 = new System.Windows.Forms.TrackBar();
		this.label214 = new System.Windows.Forms.Label();
		this.label215 = new System.Windows.Forms.Label();
		this.label216 = new System.Windows.Forms.Label();
		this.label217 = new System.Windows.Forms.Label();
		this.txtRainStretch2 = new System.Windows.Forms.TextBox();
		this.trkRainStretch2 = new System.Windows.Forms.TrackBar();
		this.txtRainAlpha2 = new System.Windows.Forms.TextBox();
		this.txtRainSkewBase2 = new System.Windows.Forms.TextBox();
		this.tabPage4 = new System.Windows.Forms.TabPage();
		this.chkNoMusic = new System.Windows.Forms.CheckBox();
		this.chkNoGravestones = new System.Windows.Forms.CheckBox();
		this.chkSanctuary = new System.Windows.Forms.CheckBox();
		this.chkLightning = new System.Windows.Forms.CheckBox();
		this.chkSndLightRain = new System.Windows.Forms.CheckBox();
		this.chkSndStorm = new System.Windows.Forms.CheckBox();
		this.chkSndRain = new System.Windows.Forms.CheckBox();
		this.chkSndRainIn = new System.Windows.Forms.CheckBox();
		this.chkSndDungeon = new System.Windows.Forms.CheckBox();
		this.chkSndDrips = new System.Windows.Forms.CheckBox();
		this.chkSndCreak = new System.Windows.Forms.CheckBox();
		this.chkSndChains = new System.Windows.Forms.CheckBox();
		this.chkSndCaveDrips = new System.Windows.Forms.CheckBox();
		this.chkSndCave = new System.Windows.Forms.CheckBox();
		this.chkSndBugs = new System.Windows.Forms.CheckBox();
		this.chkStarry = new System.Windows.Forms.CheckBox();
		this.txtBBBG = new System.Windows.Forms.TextBox();
		this.txtBGBG = new System.Windows.Forms.TextBox();
		this.txtBRBG = new System.Windows.Forms.TextBox();
		this.txtBBOBack5 = new System.Windows.Forms.TextBox();
		this.txtBGOBack5 = new System.Windows.Forms.TextBox();
		this.txtBROBack5 = new System.Windows.Forms.TextBox();
		this.txtBBOBack4 = new System.Windows.Forms.TextBox();
		this.txtBGOBack4 = new System.Windows.Forms.TextBox();
		this.txtBROBack4 = new System.Windows.Forms.TextBox();
		this.txtBBOBack3 = new System.Windows.Forms.TextBox();
		this.txtBGOBack3 = new System.Windows.Forms.TextBox();
		this.txtBROBack3 = new System.Windows.Forms.TextBox();
		this.txtBBOBack2 = new System.Windows.Forms.TextBox();
		this.txtBGOBack2 = new System.Windows.Forms.TextBox();
		this.txtBROBack2 = new System.Windows.Forms.TextBox();
		this.txtBBOBack1 = new System.Windows.Forms.TextBox();
		this.txtBGOBack1 = new System.Windows.Forms.TextBox();
		this.txtBROBack1 = new System.Windows.Forms.TextBox();
		this.txtBBOMid = new System.Windows.Forms.TextBox();
		this.txtBGOMid = new System.Windows.Forms.TextBox();
		this.txtBROMid = new System.Windows.Forms.TextBox();
		this.txtBBOFore1 = new System.Windows.Forms.TextBox();
		this.txtBGOFore1 = new System.Windows.Forms.TextBox();
		this.txtBROFore1 = new System.Windows.Forms.TextBox();
		this.txtBBOFore2 = new System.Windows.Forms.TextBox();
		this.txtBGOFore2 = new System.Windows.Forms.TextBox();
		this.txtBROFore2 = new System.Windows.Forms.TextBox();
		this.txtBBOFore3 = new System.Windows.Forms.TextBox();
		this.txtBGOFore3 = new System.Windows.Forms.TextBox();
		this.txtBROFore3 = new System.Windows.Forms.TextBox();
		this.txtBBOFore4 = new System.Windows.Forms.TextBox();
		this.txtBGOFore4 = new System.Windows.Forms.TextBox();
		this.txtBROFore4 = new System.Windows.Forms.TextBox();
		this.txtBBOFore5 = new System.Windows.Forms.TextBox();
		this.txtBGOFore5 = new System.Windows.Forms.TextBox();
		this.txtBROFore5 = new System.Windows.Forms.TextBox();
		this.txtBBIBack4 = new System.Windows.Forms.TextBox();
		this.txtBGIBack4 = new System.Windows.Forms.TextBox();
		this.txtBRIBack4 = new System.Windows.Forms.TextBox();
		this.txtBBIBack3 = new System.Windows.Forms.TextBox();
		this.txtBGIBack3 = new System.Windows.Forms.TextBox();
		this.txtBRIBack3 = new System.Windows.Forms.TextBox();
		this.txtBBIBack2 = new System.Windows.Forms.TextBox();
		this.txtBGIBack2 = new System.Windows.Forms.TextBox();
		this.txtBRIBack2 = new System.Windows.Forms.TextBox();
		this.txtBBIBack1 = new System.Windows.Forms.TextBox();
		this.txtBGIBack1 = new System.Windows.Forms.TextBox();
		this.txtBRIBack1 = new System.Windows.Forms.TextBox();
		this.txtBBIMid = new System.Windows.Forms.TextBox();
		this.txtBGIMid = new System.Windows.Forms.TextBox();
		this.txtBRIMid = new System.Windows.Forms.TextBox();
		this.txtBBIFore1 = new System.Windows.Forms.TextBox();
		this.txtBGIFore1 = new System.Windows.Forms.TextBox();
		this.txtBRIFore1 = new System.Windows.Forms.TextBox();
		this.txtBBIFore2 = new System.Windows.Forms.TextBox();
		this.txtBGIFore2 = new System.Windows.Forms.TextBox();
		this.txtBRIFore2 = new System.Windows.Forms.TextBox();
		this.txtBBIFore3 = new System.Windows.Forms.TextBox();
		this.txtBGIFore3 = new System.Windows.Forms.TextBox();
		this.txtBRIFore3 = new System.Windows.Forms.TextBox();
		this.trkROBack5.BeginInit();
		this.panel1.SuspendLayout();
		this.trkGammaOBack5.BeginInit();
		this.trkBriteOBack5.BeginInit();
		this.trkTintOBack5.BeginInit();
		this.trkSatOBack5.BeginInit();
		this.trkBOBack5.BeginInit();
		this.trkGOBack5.BeginInit();
		this.panel2.SuspendLayout();
		this.trkGammaOBack4.BeginInit();
		this.trkBriteOBack4.BeginInit();
		this.trkTintOBack4.BeginInit();
		this.trkSatOBack4.BeginInit();
		this.trkBOBack4.BeginInit();
		this.trkGOBack4.BeginInit();
		this.trkROBack4.BeginInit();
		this.panel3.SuspendLayout();
		this.trkGammaOBack3.BeginInit();
		this.trkBriteOBack3.BeginInit();
		this.trkTintOBack3.BeginInit();
		this.trkSatOBack3.BeginInit();
		this.trkBOBack3.BeginInit();
		this.trkGOBack3.BeginInit();
		this.trkROBack3.BeginInit();
		this.panel4.SuspendLayout();
		this.trkGammaOBack2.BeginInit();
		this.trkBriteOBack2.BeginInit();
		this.trkTintOBack2.BeginInit();
		this.trkSatOBack2.BeginInit();
		this.trkBOBack2.BeginInit();
		this.trkGOBack2.BeginInit();
		this.trkROBack2.BeginInit();
		this.panel5.SuspendLayout();
		this.trkGammaOBack1.BeginInit();
		this.trkBriteOBack1.BeginInit();
		this.trkTintOBack1.BeginInit();
		this.trkSatOBack1.BeginInit();
		this.trkBOBack1.BeginInit();
		this.trkGOBack1.BeginInit();
		this.trkROBack1.BeginInit();
		this.panel6.SuspendLayout();
		this.trkGammaOMid.BeginInit();
		this.trkBriteOMid.BeginInit();
		this.trkTintOMid.BeginInit();
		this.trkSatOMid.BeginInit();
		this.trkBOMid.BeginInit();
		this.trkGOMid.BeginInit();
		this.trkROMid.BeginInit();
		this.panel7.SuspendLayout();
		this.trkGammaOFore1.BeginInit();
		this.trkBriteOFore1.BeginInit();
		this.trkTintOFore1.BeginInit();
		this.trkSatOFore1.BeginInit();
		this.trkBOFore1.BeginInit();
		this.trkGOFore1.BeginInit();
		this.trkROFore1.BeginInit();
		this.panel8.SuspendLayout();
		this.trkGammaOFore2.BeginInit();
		this.trkBriteOFore2.BeginInit();
		this.trkTintOFore2.BeginInit();
		this.trkSatOFore2.BeginInit();
		this.trkBOFore2.BeginInit();
		this.trkGOFore2.BeginInit();
		this.trkROFore2.BeginInit();
		this.panel9.SuspendLayout();
		this.trkGammaOFore3.BeginInit();
		this.trkBriteOFore3.BeginInit();
		this.trkTintOFore3.BeginInit();
		this.trkSatOFore3.BeginInit();
		this.trkBOFore3.BeginInit();
		this.trkGOFore3.BeginInit();
		this.trkROFore3.BeginInit();
		this.panel10.SuspendLayout();
		this.trkGammaOFore4.BeginInit();
		this.trkBriteOFore4.BeginInit();
		this.trkTintOFore4.BeginInit();
		this.trkSatOFore4.BeginInit();
		this.trkBOFore4.BeginInit();
		this.trkGOFore4.BeginInit();
		this.trkROFore4.BeginInit();
		this.panel11.SuspendLayout();
		this.trkGammaOFore5.BeginInit();
		this.trkBriteOFore5.BeginInit();
		this.trkTintOFore5.BeginInit();
		this.trkSatOFore5.BeginInit();
		this.trkBOFore5.BeginInit();
		this.trkGOFore5.BeginInit();
		this.trkROFore5.BeginInit();
		this.panel12.SuspendLayout();
		this.trkGammaIFore3.BeginInit();
		this.trkBriteIFore3.BeginInit();
		this.trkTintIFore3.BeginInit();
		this.trkSatIFore3.BeginInit();
		this.trkBIFore3.BeginInit();
		this.trkGIFore3.BeginInit();
		this.trkRIFore3.BeginInit();
		this.panel13.SuspendLayout();
		this.trkGammaIFore2.BeginInit();
		this.trkBriteIFore2.BeginInit();
		this.trkTintIFore2.BeginInit();
		this.trkSatIFore2.BeginInit();
		this.trkBIFore2.BeginInit();
		this.trkGIFore2.BeginInit();
		this.trkRIFore2.BeginInit();
		this.panel14.SuspendLayout();
		this.trkGammaIFore1.BeginInit();
		this.trkBriteIFore1.BeginInit();
		this.trkTintIFore1.BeginInit();
		this.trkSatIFore1.BeginInit();
		this.trkBIFore1.BeginInit();
		this.trkGIFore1.BeginInit();
		this.trkRIFore1.BeginInit();
		this.panel15.SuspendLayout();
		this.trkGammaIMid.BeginInit();
		this.trkBriteIMid.BeginInit();
		this.trkTintIMid.BeginInit();
		this.trkSatIMid.BeginInit();
		this.trkBIMid.BeginInit();
		this.trkGIMid.BeginInit();
		this.trkRIMid.BeginInit();
		this.panel16.SuspendLayout();
		this.trkGammaIBack1.BeginInit();
		this.trkBriteIBack1.BeginInit();
		this.trkTintIBack1.BeginInit();
		this.trkSatIBack1.BeginInit();
		this.trkBIBack1.BeginInit();
		this.trkGIBack1.BeginInit();
		this.trkRIBack1.BeginInit();
		this.panel17.SuspendLayout();
		this.trkGammaIBack2.BeginInit();
		this.trkBriteIBack2.BeginInit();
		this.trkTintIBack2.BeginInit();
		this.trkSatIBack2.BeginInit();
		this.trkBIBack2.BeginInit();
		this.trkGIBack2.BeginInit();
		this.trkRIBack2.BeginInit();
		this.panel18.SuspendLayout();
		this.trkGammaIBack3.BeginInit();
		this.trkBriteIBack3.BeginInit();
		this.trkTintIBack3.BeginInit();
		this.trkSatIBack3.BeginInit();
		this.trkBIBack3.BeginInit();
		this.trkGIBack3.BeginInit();
		this.trkRIBack3.BeginInit();
		this.panel19.SuspendLayout();
		this.trkGammaIBack4.BeginInit();
		this.trkBriteIBack4.BeginInit();
		this.trkTintIBack4.BeginInit();
		this.trkSatIBack4.BeginInit();
		this.trkBIBack4.BeginInit();
		this.trkGIBack4.BeginInit();
		this.trkRIBack4.BeginInit();
		this.trktB.BeginInit();
		this.trktG.BeginInit();
		this.trktR.BeginInit();
		this.trkbB.BeginInit();
		this.trkbG.BeginInit();
		this.trkbR.BeginInit();
		this.trkbgB.BeginInit();
		this.trkbgG.BeginInit();
		this.trkbgR.BeginInit();
		this.trkburnB.BeginInit();
		this.trkburnG.BeginInit();
		this.trkburnR.BeginInit();
		this.trkBrite.BeginInit();
		this.trkGamma.BeginInit();
		this.trkBloomBase.BeginInit();
		this.trkBloomThresh.BeginInit();
		this.trkBloomSat.BeginInit();
		this.trkBloomIntensity.BeginInit();
		this.trkBloomFloor.BeginInit();
		this.trkDarkBlur.BeginInit();
		this.trkLightDesat.BeginInit();
		this.trkLightRed.BeginInit();
		this.trkLightBlue.BeginInit();
		this.trkLightThresh.BeginInit();
		this.panel20.SuspendLayout();
		this.panel21.SuspendLayout();
		this.panel22.SuspendLayout();
		this.panel23.SuspendLayout();
		this.trkBloomDesatBase.BeginInit();
		this.panel24.SuspendLayout();
		this.trkLightFac.BeginInit();
		this.trkLightMap.BeginInit();
		this.panel25.SuspendLayout();
		this.trkBaseSat.BeginInit();
		this.panel26.SuspendLayout();
		this.trkLeavesAlpha.BeginInit();
		this.trkRainAlpha.BeginInit();
		this.trkSnowAlpha.BeginInit();
		this.trkDotsAlpha.BeginInit();
		this.panel27.SuspendLayout();
		this.trkBloodSat.BeginInit();
		this.trkBloodAlpha.BeginInit();
		this.panel28.SuspendLayout();
		this.trkpA.BeginInit();
		this.trkpB.BeginInit();
		this.trkpG.BeginInit();
		this.trkpR.BeginInit();
		this.menuStrip1.SuspendLayout();
		this.panel29.SuspendLayout();
		this.trkRainSkewAdjust0.BeginInit();
		this.trkRainSkewBase0.BeginInit();
		this.trkRainAlpha0.BeginInit();
		this.trkRainStretch0.BeginInit();
		this.panel30.SuspendLayout();
		this.trkRainSkewAdjust1.BeginInit();
		this.trkRainSkewBase1.BeginInit();
		this.trkRainAlpha1.BeginInit();
		this.trkRainStretch1.BeginInit();
		this.panel31.SuspendLayout();
		this.trkRainB0.BeginInit();
		this.trkRainG0.BeginInit();
		this.trkRainR0.BeginInit();
		this.tbPanels.SuspendLayout();
		this.tabPage1.SuspendLayout();
		this.tabPage2.SuspendLayout();
		this.panel39.SuspendLayout();
		this.trkGammaBG.BeginInit();
		this.trkBriteBG.BeginInit();
		this.trkTintBG.BeginInit();
		this.trkSatBG.BeginInit();
		this.trkBBG.BeginInit();
		this.trkGBG.BeginInit();
		this.trkRBG.BeginInit();
		this.tabPage3.SuspendLayout();
		this.panel38.SuspendLayout();
		this.trkRainGamma3.BeginInit();
		this.trkRainGamma2.BeginInit();
		this.trkRainGamma1.BeginInit();
		this.panel37.SuspendLayout();
		this.trkRefractRainB.BeginInit();
		this.trkRefractRainG.BeginInit();
		this.trkRefractRainR.BeginInit();
		this.trkRefractRainGlow.BeginInit();
		this.trkRefractRainGlimmer.BeginInit();
		this.trkRefractRainDark.BeginInit();
		this.trkRefractRainBrite.BeginInit();
		this.panel36.SuspendLayout();
		this.trkRainSkewAdjust5.BeginInit();
		this.trkRainSkewBase5.BeginInit();
		this.trkRainAlpha5.BeginInit();
		this.trkRainStretch5.BeginInit();
		this.panel35.SuspendLayout();
		this.trkRainSkewAdjust4.BeginInit();
		this.trkRainSkewBase4.BeginInit();
		this.trkRainAlpha4.BeginInit();
		this.trkRainStretch4.BeginInit();
		this.panel34.SuspendLayout();
		this.trkRainB1.BeginInit();
		this.trkRainG1.BeginInit();
		this.trkRainR1.BeginInit();
		this.panel33.SuspendLayout();
		this.trkRainSkewAdjust3.BeginInit();
		this.trkRainSkewBase3.BeginInit();
		this.trkRainAlpha3.BeginInit();
		this.trkRainStretch3.BeginInit();
		this.panel32.SuspendLayout();
		this.trkRainSkewAdjust2.BeginInit();
		this.trkRainSkewBase2.BeginInit();
		this.trkRainAlpha2.BeginInit();
		this.trkRainStretch2.BeginInit();
		this.tabPage4.SuspendLayout();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(12, 34);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(18, 13);
		this.label1.TabIndex = 1;
		this.label1.Text = "R:";
		this.trkROBack5.Location = new System.Drawing.Point(36, 34);
		this.trkROBack5.Maximum = 1000;
		this.trkROBack5.Name = "trkROBack5";
		this.trkROBack5.Size = new System.Drawing.Size(85, 45);
		this.trkROBack5.TabIndex = 2;
		this.trkROBack5.TickFrequency = 100;
		this.trkROBack5.Scroll += new System.EventHandler(trkROBack5_Scroll);
		this.txtROBack5.Location = new System.Drawing.Point(127, 34);
		this.txtROBack5.Name = "txtROBack5";
		this.txtROBack5.Size = new System.Drawing.Size(35, 20);
		this.txtROBack5.TabIndex = 3;
		this.txtROBack5.TextChanged += new System.EventHandler(txtROBack5_TextChanged);
		this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel1.Controls.Add(this.txtBBOBack5);
		this.panel1.Controls.Add(this.txtBGOBack5);
		this.panel1.Controls.Add(this.txtBROBack5);
		this.panel1.Controls.Add(this.trkGammaOBack5);
		this.panel1.Controls.Add(this.txtGammaOBack5);
		this.panel1.Controls.Add(this.label177);
		this.panel1.Controls.Add(this.trkBriteOBack5);
		this.panel1.Controls.Add(this.txtBriteOBack5);
		this.panel1.Controls.Add(this.label178);
		this.panel1.Controls.Add(this.label6);
		this.panel1.Controls.Add(this.trkTintOBack5);
		this.panel1.Controls.Add(this.txtTintOBack5);
		this.panel1.Controls.Add(this.label5);
		this.panel1.Controls.Add(this.trkSatOBack5);
		this.panel1.Controls.Add(this.txtSatOBack5);
		this.panel1.Controls.Add(this.label4);
		this.panel1.Controls.Add(this.trkBOBack5);
		this.panel1.Controls.Add(this.txtBOBack5);
		this.panel1.Controls.Add(this.label3);
		this.panel1.Controls.Add(this.trkGOBack5);
		this.panel1.Controls.Add(this.txtGOBack5);
		this.panel1.Controls.Add(this.label2);
		this.panel1.Controls.Add(this.trkROBack5);
		this.panel1.Controls.Add(this.txtROBack5);
		this.panel1.Controls.Add(this.label1);
		this.panel1.Location = new System.Drawing.Point(225, 8);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(213, 220);
		this.panel1.TabIndex = 4;
		this.trkGammaOBack5.Location = new System.Drawing.Point(36, 189);
		this.trkGammaOBack5.Maximum = 1000;
		this.trkGammaOBack5.Minimum = -1000;
		this.trkGammaOBack5.Name = "trkGammaOBack5";
		this.trkGammaOBack5.Size = new System.Drawing.Size(104, 45);
		this.trkGammaOBack5.TabIndex = 27;
		this.trkGammaOBack5.TickFrequency = 200;
		this.trkGammaOBack5.Scroll += new System.EventHandler(trkGammaOBack5_Scroll);
		this.txtGammaOBack5.Location = new System.Drawing.Point(147, 189);
		this.txtGammaOBack5.Name = "txtGammaOBack5";
		this.txtGammaOBack5.Size = new System.Drawing.Size(56, 20);
		this.txtGammaOBack5.TabIndex = 28;
		this.txtGammaOBack5.TextChanged += new System.EventHandler(txtGammaOBack5_TextChanged);
		this.label177.AutoSize = true;
		this.label177.Location = new System.Drawing.Point(12, 189);
		this.label177.Name = "label177";
		this.label177.Size = new System.Drawing.Size(26, 13);
		this.label177.TabIndex = 26;
		this.label177.Text = "Gm:";
		this.trkBriteOBack5.Location = new System.Drawing.Point(36, 163);
		this.trkBriteOBack5.Maximum = 1000;
		this.trkBriteOBack5.Name = "trkBriteOBack5";
		this.trkBriteOBack5.Size = new System.Drawing.Size(104, 45);
		this.trkBriteOBack5.TabIndex = 24;
		this.trkBriteOBack5.TickFrequency = 100;
		this.trkBriteOBack5.Scroll += new System.EventHandler(trkBriteOBack5_Scroll);
		this.txtBriteOBack5.Location = new System.Drawing.Point(147, 163);
		this.txtBriteOBack5.Name = "txtBriteOBack5";
		this.txtBriteOBack5.Size = new System.Drawing.Size(56, 20);
		this.txtBriteOBack5.TabIndex = 25;
		this.txtBriteOBack5.TextChanged += new System.EventHandler(txtBriteOBack5_TextChanged);
		this.label178.AutoSize = true;
		this.label178.Location = new System.Drawing.Point(12, 163);
		this.label178.Name = "label178";
		this.label178.Size = new System.Drawing.Size(25, 13);
		this.label178.TabIndex = 23;
		this.label178.Text = "Brit:";
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.Location = new System.Drawing.Point(12, 13);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(60, 13);
		this.label6.TabIndex = 16;
		this.label6.Text = "O Back 5";
		this.trkTintOBack5.Location = new System.Drawing.Point(36, 137);
		this.trkTintOBack5.Maximum = 1000;
		this.trkTintOBack5.Name = "trkTintOBack5";
		this.trkTintOBack5.Size = new System.Drawing.Size(104, 45);
		this.trkTintOBack5.TabIndex = 14;
		this.trkTintOBack5.TickFrequency = 100;
		this.trkTintOBack5.Scroll += new System.EventHandler(trkTintOBack5_Scroll);
		this.txtTintOBack5.Location = new System.Drawing.Point(147, 137);
		this.txtTintOBack5.Name = "txtTintOBack5";
		this.txtTintOBack5.Size = new System.Drawing.Size(56, 20);
		this.txtTintOBack5.TabIndex = 15;
		this.txtTintOBack5.TextChanged += new System.EventHandler(txtTintOBack5_TextChanged);
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(12, 137);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(28, 13);
		this.label5.TabIndex = 13;
		this.label5.Text = "Tint:";
		this.trkSatOBack5.Location = new System.Drawing.Point(36, 111);
		this.trkSatOBack5.Maximum = 1000;
		this.trkSatOBack5.Name = "trkSatOBack5";
		this.trkSatOBack5.Size = new System.Drawing.Size(104, 45);
		this.trkSatOBack5.TabIndex = 11;
		this.trkSatOBack5.TickFrequency = 100;
		this.trkSatOBack5.Scroll += new System.EventHandler(trkSatOBack5_Scroll);
		this.txtSatOBack5.Location = new System.Drawing.Point(147, 111);
		this.txtSatOBack5.Name = "txtSatOBack5";
		this.txtSatOBack5.Size = new System.Drawing.Size(56, 20);
		this.txtSatOBack5.TabIndex = 12;
		this.txtSatOBack5.TextChanged += new System.EventHandler(txtSatOBack5_TextChanged);
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(12, 111);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(26, 13);
		this.label4.TabIndex = 10;
		this.label4.Text = "Sat:";
		this.trkBOBack5.Location = new System.Drawing.Point(36, 85);
		this.trkBOBack5.Maximum = 1000;
		this.trkBOBack5.Name = "trkBOBack5";
		this.trkBOBack5.Size = new System.Drawing.Size(85, 45);
		this.trkBOBack5.TabIndex = 8;
		this.trkBOBack5.TickFrequency = 100;
		this.trkBOBack5.Scroll += new System.EventHandler(trkBOBack5_Scroll);
		this.txtBOBack5.Location = new System.Drawing.Point(127, 85);
		this.txtBOBack5.Name = "txtBOBack5";
		this.txtBOBack5.Size = new System.Drawing.Size(35, 20);
		this.txtBOBack5.TabIndex = 9;
		this.txtBOBack5.TextChanged += new System.EventHandler(txtBOBack5_TextChanged);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(12, 85);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(17, 13);
		this.label3.TabIndex = 7;
		this.label3.Text = "B:";
		this.trkGOBack5.Location = new System.Drawing.Point(36, 60);
		this.trkGOBack5.Maximum = 1000;
		this.trkGOBack5.Name = "trkGOBack5";
		this.trkGOBack5.Size = new System.Drawing.Size(85, 45);
		this.trkGOBack5.TabIndex = 5;
		this.trkGOBack5.TickFrequency = 100;
		this.trkGOBack5.Scroll += new System.EventHandler(trkGOBack5_Scroll);
		this.txtGOBack5.Location = new System.Drawing.Point(127, 60);
		this.txtGOBack5.Name = "txtGOBack5";
		this.txtGOBack5.Size = new System.Drawing.Size(35, 20);
		this.txtGOBack5.TabIndex = 6;
		this.txtGOBack5.TextChanged += new System.EventHandler(txtGOBack5_TextChanged);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(12, 60);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(18, 13);
		this.label2.TabIndex = 4;
		this.label2.Text = "G:";
		this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel2.Controls.Add(this.txtBBOBack4);
		this.panel2.Controls.Add(this.txtBGOBack4);
		this.panel2.Controls.Add(this.txtBROBack4);
		this.panel2.Controls.Add(this.trkGammaOBack4);
		this.panel2.Controls.Add(this.txtGammaOBack4);
		this.panel2.Controls.Add(this.label179);
		this.panel2.Controls.Add(this.trkBriteOBack4);
		this.panel2.Controls.Add(this.txtBriteOBack4);
		this.panel2.Controls.Add(this.label180);
		this.panel2.Controls.Add(this.label7);
		this.panel2.Controls.Add(this.trkTintOBack4);
		this.panel2.Controls.Add(this.txtTintOBack4);
		this.panel2.Controls.Add(this.label8);
		this.panel2.Controls.Add(this.trkSatOBack4);
		this.panel2.Controls.Add(this.txtSatOBack4);
		this.panel2.Controls.Add(this.label9);
		this.panel2.Controls.Add(this.trkBOBack4);
		this.panel2.Controls.Add(this.txtBOBack4);
		this.panel2.Controls.Add(this.label10);
		this.panel2.Controls.Add(this.trkGOBack4);
		this.panel2.Controls.Add(this.txtGOBack4);
		this.panel2.Controls.Add(this.label11);
		this.panel2.Controls.Add(this.trkROBack4);
		this.panel2.Controls.Add(this.txtROBack4);
		this.panel2.Controls.Add(this.label12);
		this.panel2.Location = new System.Drawing.Point(444, 8);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(213, 220);
		this.panel2.TabIndex = 17;
		this.trkGammaOBack4.Location = new System.Drawing.Point(36, 189);
		this.trkGammaOBack4.Maximum = 1000;
		this.trkGammaOBack4.Minimum = -1000;
		this.trkGammaOBack4.Name = "trkGammaOBack4";
		this.trkGammaOBack4.Size = new System.Drawing.Size(104, 45);
		this.trkGammaOBack4.TabIndex = 27;
		this.trkGammaOBack4.TickFrequency = 200;
		this.trkGammaOBack4.Scroll += new System.EventHandler(trkGammaOBack4_Scroll);
		this.txtGammaOBack4.Location = new System.Drawing.Point(147, 189);
		this.txtGammaOBack4.Name = "txtGammaOBack4";
		this.txtGammaOBack4.Size = new System.Drawing.Size(56, 20);
		this.txtGammaOBack4.TabIndex = 28;
		this.txtGammaOBack4.TextChanged += new System.EventHandler(txtGammaOBack4_TextChanged);
		this.label179.AutoSize = true;
		this.label179.Location = new System.Drawing.Point(12, 189);
		this.label179.Name = "label179";
		this.label179.Size = new System.Drawing.Size(26, 13);
		this.label179.TabIndex = 26;
		this.label179.Text = "Gm:";
		this.trkBriteOBack4.Location = new System.Drawing.Point(36, 163);
		this.trkBriteOBack4.Maximum = 1000;
		this.trkBriteOBack4.Name = "trkBriteOBack4";
		this.trkBriteOBack4.Size = new System.Drawing.Size(104, 45);
		this.trkBriteOBack4.TabIndex = 24;
		this.trkBriteOBack4.TickFrequency = 100;
		this.trkBriteOBack4.Scroll += new System.EventHandler(trkBriteOBack4_Scroll);
		this.txtBriteOBack4.Location = new System.Drawing.Point(147, 163);
		this.txtBriteOBack4.Name = "txtBriteOBack4";
		this.txtBriteOBack4.Size = new System.Drawing.Size(56, 20);
		this.txtBriteOBack4.TabIndex = 25;
		this.txtBriteOBack4.TextChanged += new System.EventHandler(txtBriteOBack4_TextChanged);
		this.label180.AutoSize = true;
		this.label180.Location = new System.Drawing.Point(12, 163);
		this.label180.Name = "label180";
		this.label180.Size = new System.Drawing.Size(25, 13);
		this.label180.TabIndex = 23;
		this.label180.Text = "Brit:";
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.Location = new System.Drawing.Point(12, 13);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(60, 13);
		this.label7.TabIndex = 16;
		this.label7.Text = "O Back 4";
		this.trkTintOBack4.Location = new System.Drawing.Point(36, 137);
		this.trkTintOBack4.Maximum = 1000;
		this.trkTintOBack4.Name = "trkTintOBack4";
		this.trkTintOBack4.Size = new System.Drawing.Size(104, 45);
		this.trkTintOBack4.TabIndex = 14;
		this.trkTintOBack4.TickFrequency = 100;
		this.trkTintOBack4.Scroll += new System.EventHandler(trkTintOBack4_Scroll);
		this.txtTintOBack4.Location = new System.Drawing.Point(147, 137);
		this.txtTintOBack4.Name = "txtTintOBack4";
		this.txtTintOBack4.Size = new System.Drawing.Size(56, 20);
		this.txtTintOBack4.TabIndex = 15;
		this.txtTintOBack4.TextChanged += new System.EventHandler(txtTintOBack4_TextChanged);
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(12, 137);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(28, 13);
		this.label8.TabIndex = 13;
		this.label8.Text = "Tint:";
		this.trkSatOBack4.Location = new System.Drawing.Point(36, 111);
		this.trkSatOBack4.Maximum = 1000;
		this.trkSatOBack4.Name = "trkSatOBack4";
		this.trkSatOBack4.Size = new System.Drawing.Size(104, 45);
		this.trkSatOBack4.TabIndex = 11;
		this.trkSatOBack4.TickFrequency = 100;
		this.trkSatOBack4.Scroll += new System.EventHandler(trkSatOBack4_Scroll);
		this.txtSatOBack4.Location = new System.Drawing.Point(147, 111);
		this.txtSatOBack4.Name = "txtSatOBack4";
		this.txtSatOBack4.Size = new System.Drawing.Size(56, 20);
		this.txtSatOBack4.TabIndex = 12;
		this.txtSatOBack4.TextChanged += new System.EventHandler(txtSatOBack4_TextChanged);
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(12, 111);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(26, 13);
		this.label9.TabIndex = 10;
		this.label9.Text = "Sat:";
		this.trkBOBack4.Location = new System.Drawing.Point(36, 85);
		this.trkBOBack4.Maximum = 1000;
		this.trkBOBack4.Name = "trkBOBack4";
		this.trkBOBack4.Size = new System.Drawing.Size(85, 45);
		this.trkBOBack4.TabIndex = 8;
		this.trkBOBack4.TickFrequency = 100;
		this.trkBOBack4.Scroll += new System.EventHandler(trkBOBack4_Scroll);
		this.txtBOBack4.Location = new System.Drawing.Point(127, 85);
		this.txtBOBack4.Name = "txtBOBack4";
		this.txtBOBack4.Size = new System.Drawing.Size(35, 20);
		this.txtBOBack4.TabIndex = 9;
		this.txtBOBack4.TextChanged += new System.EventHandler(txtBOBack4_TextChanged);
		this.label10.AutoSize = true;
		this.label10.Location = new System.Drawing.Point(12, 85);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(17, 13);
		this.label10.TabIndex = 7;
		this.label10.Text = "B:";
		this.trkGOBack4.Location = new System.Drawing.Point(36, 60);
		this.trkGOBack4.Maximum = 1000;
		this.trkGOBack4.Name = "trkGOBack4";
		this.trkGOBack4.Size = new System.Drawing.Size(85, 45);
		this.trkGOBack4.TabIndex = 5;
		this.trkGOBack4.TickFrequency = 100;
		this.trkGOBack4.Scroll += new System.EventHandler(trkGOBack4_Scroll);
		this.txtGOBack4.Location = new System.Drawing.Point(127, 60);
		this.txtGOBack4.Name = "txtGOBack4";
		this.txtGOBack4.Size = new System.Drawing.Size(35, 20);
		this.txtGOBack4.TabIndex = 6;
		this.txtGOBack4.TextChanged += new System.EventHandler(txtGOBack4_TextChanged);
		this.label11.AutoSize = true;
		this.label11.Location = new System.Drawing.Point(12, 60);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(18, 13);
		this.label11.TabIndex = 4;
		this.label11.Text = "G:";
		this.trkROBack4.Location = new System.Drawing.Point(36, 34);
		this.trkROBack4.Maximum = 1000;
		this.trkROBack4.Name = "trkROBack4";
		this.trkROBack4.Size = new System.Drawing.Size(85, 45);
		this.trkROBack4.TabIndex = 2;
		this.trkROBack4.TickFrequency = 100;
		this.trkROBack4.Scroll += new System.EventHandler(trkROBack4_Scroll);
		this.txtROBack4.Location = new System.Drawing.Point(127, 34);
		this.txtROBack4.Name = "txtROBack4";
		this.txtROBack4.Size = new System.Drawing.Size(35, 20);
		this.txtROBack4.TabIndex = 3;
		this.txtROBack4.TextChanged += new System.EventHandler(txtROBack4_TextChanged);
		this.label12.AutoSize = true;
		this.label12.Location = new System.Drawing.Point(12, 34);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(18, 13);
		this.label12.TabIndex = 1;
		this.label12.Text = "R:";
		this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel3.Controls.Add(this.txtBBOBack3);
		this.panel3.Controls.Add(this.txtBGOBack3);
		this.panel3.Controls.Add(this.txtBROBack3);
		this.panel3.Controls.Add(this.trkGammaOBack3);
		this.panel3.Controls.Add(this.txtGammaOBack3);
		this.panel3.Controls.Add(this.label181);
		this.panel3.Controls.Add(this.trkBriteOBack3);
		this.panel3.Controls.Add(this.txtBriteOBack3);
		this.panel3.Controls.Add(this.label182);
		this.panel3.Controls.Add(this.label13);
		this.panel3.Controls.Add(this.trkTintOBack3);
		this.panel3.Controls.Add(this.txtTintOBack3);
		this.panel3.Controls.Add(this.label14);
		this.panel3.Controls.Add(this.trkSatOBack3);
		this.panel3.Controls.Add(this.txtSatOBack3);
		this.panel3.Controls.Add(this.label15);
		this.panel3.Controls.Add(this.trkBOBack3);
		this.panel3.Controls.Add(this.txtBOBack3);
		this.panel3.Controls.Add(this.label16);
		this.panel3.Controls.Add(this.trkGOBack3);
		this.panel3.Controls.Add(this.txtGOBack3);
		this.panel3.Controls.Add(this.label17);
		this.panel3.Controls.Add(this.trkROBack3);
		this.panel3.Controls.Add(this.txtROBack3);
		this.panel3.Controls.Add(this.label18);
		this.panel3.Location = new System.Drawing.Point(663, 8);
		this.panel3.Name = "panel3";
		this.panel3.Size = new System.Drawing.Size(213, 220);
		this.panel3.TabIndex = 18;
		this.trkGammaOBack3.Location = new System.Drawing.Point(36, 189);
		this.trkGammaOBack3.Maximum = 1000;
		this.trkGammaOBack3.Minimum = -1000;
		this.trkGammaOBack3.Name = "trkGammaOBack3";
		this.trkGammaOBack3.Size = new System.Drawing.Size(104, 45);
		this.trkGammaOBack3.TabIndex = 27;
		this.trkGammaOBack3.TickFrequency = 200;
		this.trkGammaOBack3.Scroll += new System.EventHandler(trkGammaOBack3_Scroll);
		this.txtGammaOBack3.Location = new System.Drawing.Point(147, 189);
		this.txtGammaOBack3.Name = "txtGammaOBack3";
		this.txtGammaOBack3.Size = new System.Drawing.Size(56, 20);
		this.txtGammaOBack3.TabIndex = 28;
		this.txtGammaOBack3.TextChanged += new System.EventHandler(txtGammaOBack3_TextChanged);
		this.label181.AutoSize = true;
		this.label181.Location = new System.Drawing.Point(12, 189);
		this.label181.Name = "label181";
		this.label181.Size = new System.Drawing.Size(26, 13);
		this.label181.TabIndex = 26;
		this.label181.Text = "Gm:";
		this.trkBriteOBack3.Location = new System.Drawing.Point(36, 163);
		this.trkBriteOBack3.Maximum = 1000;
		this.trkBriteOBack3.Name = "trkBriteOBack3";
		this.trkBriteOBack3.Size = new System.Drawing.Size(104, 45);
		this.trkBriteOBack3.TabIndex = 24;
		this.trkBriteOBack3.TickFrequency = 100;
		this.trkBriteOBack3.Scroll += new System.EventHandler(trkBriteOBack3_Scroll);
		this.txtBriteOBack3.Location = new System.Drawing.Point(147, 163);
		this.txtBriteOBack3.Name = "txtBriteOBack3";
		this.txtBriteOBack3.Size = new System.Drawing.Size(56, 20);
		this.txtBriteOBack3.TabIndex = 25;
		this.txtBriteOBack3.TextChanged += new System.EventHandler(txtBriteOBack3_TextChanged);
		this.label182.AutoSize = true;
		this.label182.Location = new System.Drawing.Point(12, 163);
		this.label182.Name = "label182";
		this.label182.Size = new System.Drawing.Size(25, 13);
		this.label182.TabIndex = 23;
		this.label182.Text = "Brit:";
		this.label13.AutoSize = true;
		this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label13.Location = new System.Drawing.Point(12, 13);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(60, 13);
		this.label13.TabIndex = 16;
		this.label13.Text = "O Back 3";
		this.trkTintOBack3.Location = new System.Drawing.Point(36, 137);
		this.trkTintOBack3.Maximum = 1000;
		this.trkTintOBack3.Name = "trkTintOBack3";
		this.trkTintOBack3.Size = new System.Drawing.Size(104, 45);
		this.trkTintOBack3.TabIndex = 14;
		this.trkTintOBack3.TickFrequency = 100;
		this.trkTintOBack3.Scroll += new System.EventHandler(trkTintOBack3_Scroll);
		this.txtTintOBack3.Location = new System.Drawing.Point(147, 137);
		this.txtTintOBack3.Name = "txtTintOBack3";
		this.txtTintOBack3.Size = new System.Drawing.Size(56, 20);
		this.txtTintOBack3.TabIndex = 15;
		this.txtTintOBack3.TextChanged += new System.EventHandler(txtTintOBack3_TextChanged);
		this.label14.AutoSize = true;
		this.label14.Location = new System.Drawing.Point(12, 137);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(28, 13);
		this.label14.TabIndex = 13;
		this.label14.Text = "Tint:";
		this.trkSatOBack3.Location = new System.Drawing.Point(36, 111);
		this.trkSatOBack3.Maximum = 1000;
		this.trkSatOBack3.Name = "trkSatOBack3";
		this.trkSatOBack3.Size = new System.Drawing.Size(104, 45);
		this.trkSatOBack3.TabIndex = 11;
		this.trkSatOBack3.TickFrequency = 100;
		this.trkSatOBack3.Scroll += new System.EventHandler(trkSatOBack3_Scroll);
		this.txtSatOBack3.Location = new System.Drawing.Point(147, 111);
		this.txtSatOBack3.Name = "txtSatOBack3";
		this.txtSatOBack3.Size = new System.Drawing.Size(56, 20);
		this.txtSatOBack3.TabIndex = 12;
		this.txtSatOBack3.TextChanged += new System.EventHandler(txtSatOBack3_TextChanged);
		this.label15.AutoSize = true;
		this.label15.Location = new System.Drawing.Point(12, 111);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(26, 13);
		this.label15.TabIndex = 10;
		this.label15.Text = "Sat:";
		this.trkBOBack3.Location = new System.Drawing.Point(36, 85);
		this.trkBOBack3.Maximum = 1000;
		this.trkBOBack3.Name = "trkBOBack3";
		this.trkBOBack3.Size = new System.Drawing.Size(85, 45);
		this.trkBOBack3.TabIndex = 8;
		this.trkBOBack3.TickFrequency = 100;
		this.trkBOBack3.Scroll += new System.EventHandler(trkBOBack3_Scroll);
		this.txtBOBack3.Location = new System.Drawing.Point(127, 85);
		this.txtBOBack3.Name = "txtBOBack3";
		this.txtBOBack3.Size = new System.Drawing.Size(35, 20);
		this.txtBOBack3.TabIndex = 9;
		this.txtBOBack3.TextChanged += new System.EventHandler(txtBOBack3_TextChanged);
		this.label16.AutoSize = true;
		this.label16.Location = new System.Drawing.Point(12, 85);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(17, 13);
		this.label16.TabIndex = 7;
		this.label16.Text = "B:";
		this.trkGOBack3.Location = new System.Drawing.Point(36, 60);
		this.trkGOBack3.Maximum = 1000;
		this.trkGOBack3.Name = "trkGOBack3";
		this.trkGOBack3.Size = new System.Drawing.Size(85, 45);
		this.trkGOBack3.TabIndex = 5;
		this.trkGOBack3.TickFrequency = 100;
		this.trkGOBack3.Scroll += new System.EventHandler(trkGOBack3_Scroll);
		this.txtGOBack3.Location = new System.Drawing.Point(127, 60);
		this.txtGOBack3.Name = "txtGOBack3";
		this.txtGOBack3.Size = new System.Drawing.Size(35, 20);
		this.txtGOBack3.TabIndex = 6;
		this.txtGOBack3.TextChanged += new System.EventHandler(txtGOBack3_TextChanged);
		this.label17.AutoSize = true;
		this.label17.Location = new System.Drawing.Point(12, 60);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(18, 13);
		this.label17.TabIndex = 4;
		this.label17.Text = "G:";
		this.trkROBack3.Location = new System.Drawing.Point(36, 34);
		this.trkROBack3.Maximum = 1000;
		this.trkROBack3.Name = "trkROBack3";
		this.trkROBack3.Size = new System.Drawing.Size(85, 45);
		this.trkROBack3.TabIndex = 2;
		this.trkROBack3.TickFrequency = 100;
		this.trkROBack3.Scroll += new System.EventHandler(trkROBack3_Scroll);
		this.txtROBack3.Location = new System.Drawing.Point(127, 34);
		this.txtROBack3.Name = "txtROBack3";
		this.txtROBack3.Size = new System.Drawing.Size(35, 20);
		this.txtROBack3.TabIndex = 3;
		this.txtROBack3.TextChanged += new System.EventHandler(txtROBack3_TextChanged);
		this.label18.AutoSize = true;
		this.label18.Location = new System.Drawing.Point(12, 34);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(18, 13);
		this.label18.TabIndex = 1;
		this.label18.Text = "R:";
		this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel4.Controls.Add(this.txtBBOBack2);
		this.panel4.Controls.Add(this.txtBGOBack2);
		this.panel4.Controls.Add(this.txtBROBack2);
		this.panel4.Controls.Add(this.trkGammaOBack2);
		this.panel4.Controls.Add(this.txtGammaOBack2);
		this.panel4.Controls.Add(this.label183);
		this.panel4.Controls.Add(this.trkBriteOBack2);
		this.panel4.Controls.Add(this.txtBriteOBack2);
		this.panel4.Controls.Add(this.label184);
		this.panel4.Controls.Add(this.label19);
		this.panel4.Controls.Add(this.trkTintOBack2);
		this.panel4.Controls.Add(this.txtTintOBack2);
		this.panel4.Controls.Add(this.label20);
		this.panel4.Controls.Add(this.trkSatOBack2);
		this.panel4.Controls.Add(this.txtSatOBack2);
		this.panel4.Controls.Add(this.label21);
		this.panel4.Controls.Add(this.trkBOBack2);
		this.panel4.Controls.Add(this.txtBOBack2);
		this.panel4.Controls.Add(this.label22);
		this.panel4.Controls.Add(this.trkGOBack2);
		this.panel4.Controls.Add(this.txtGOBack2);
		this.panel4.Controls.Add(this.label23);
		this.panel4.Controls.Add(this.trkROBack2);
		this.panel4.Controls.Add(this.txtROBack2);
		this.panel4.Controls.Add(this.label24);
		this.panel4.Location = new System.Drawing.Point(6, 234);
		this.panel4.Name = "panel4";
		this.panel4.Size = new System.Drawing.Size(213, 220);
		this.panel4.TabIndex = 19;
		this.trkGammaOBack2.Location = new System.Drawing.Point(36, 189);
		this.trkGammaOBack2.Maximum = 1000;
		this.trkGammaOBack2.Minimum = -1000;
		this.trkGammaOBack2.Name = "trkGammaOBack2";
		this.trkGammaOBack2.Size = new System.Drawing.Size(104, 45);
		this.trkGammaOBack2.TabIndex = 27;
		this.trkGammaOBack2.TickFrequency = 200;
		this.trkGammaOBack2.Scroll += new System.EventHandler(trkGammaOBack2_Scroll);
		this.txtGammaOBack2.Location = new System.Drawing.Point(147, 189);
		this.txtGammaOBack2.Name = "txtGammaOBack2";
		this.txtGammaOBack2.Size = new System.Drawing.Size(56, 20);
		this.txtGammaOBack2.TabIndex = 28;
		this.txtGammaOBack2.TextChanged += new System.EventHandler(txtGammaOBack2_TextChanged);
		this.label183.AutoSize = true;
		this.label183.Location = new System.Drawing.Point(12, 189);
		this.label183.Name = "label183";
		this.label183.Size = new System.Drawing.Size(26, 13);
		this.label183.TabIndex = 26;
		this.label183.Text = "Gm:";
		this.trkBriteOBack2.Location = new System.Drawing.Point(36, 163);
		this.trkBriteOBack2.Maximum = 1000;
		this.trkBriteOBack2.Name = "trkBriteOBack2";
		this.trkBriteOBack2.Size = new System.Drawing.Size(104, 45);
		this.trkBriteOBack2.TabIndex = 24;
		this.trkBriteOBack2.TickFrequency = 100;
		this.trkBriteOBack2.Scroll += new System.EventHandler(trkBriteOBack2_Scroll);
		this.txtBriteOBack2.Location = new System.Drawing.Point(147, 163);
		this.txtBriteOBack2.Name = "txtBriteOBack2";
		this.txtBriteOBack2.Size = new System.Drawing.Size(56, 20);
		this.txtBriteOBack2.TabIndex = 25;
		this.txtBriteOBack2.TextChanged += new System.EventHandler(txtBriteOBack2_TextChanged);
		this.label184.AutoSize = true;
		this.label184.Location = new System.Drawing.Point(12, 163);
		this.label184.Name = "label184";
		this.label184.Size = new System.Drawing.Size(25, 13);
		this.label184.TabIndex = 23;
		this.label184.Text = "Brit:";
		this.label19.AutoSize = true;
		this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label19.Location = new System.Drawing.Point(12, 13);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(60, 13);
		this.label19.TabIndex = 16;
		this.label19.Text = "O Back 2";
		this.trkTintOBack2.Location = new System.Drawing.Point(36, 137);
		this.trkTintOBack2.Maximum = 1000;
		this.trkTintOBack2.Name = "trkTintOBack2";
		this.trkTintOBack2.Size = new System.Drawing.Size(104, 45);
		this.trkTintOBack2.TabIndex = 14;
		this.trkTintOBack2.TickFrequency = 100;
		this.trkTintOBack2.Scroll += new System.EventHandler(trkTintOBack2_Scroll);
		this.txtTintOBack2.Location = new System.Drawing.Point(147, 137);
		this.txtTintOBack2.Name = "txtTintOBack2";
		this.txtTintOBack2.Size = new System.Drawing.Size(56, 20);
		this.txtTintOBack2.TabIndex = 15;
		this.txtTintOBack2.TextChanged += new System.EventHandler(txtTintOBack2_TextChanged);
		this.label20.AutoSize = true;
		this.label20.Location = new System.Drawing.Point(12, 137);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(28, 13);
		this.label20.TabIndex = 13;
		this.label20.Text = "Tint:";
		this.trkSatOBack2.Location = new System.Drawing.Point(36, 111);
		this.trkSatOBack2.Maximum = 1000;
		this.trkSatOBack2.Name = "trkSatOBack2";
		this.trkSatOBack2.Size = new System.Drawing.Size(104, 45);
		this.trkSatOBack2.TabIndex = 11;
		this.trkSatOBack2.TickFrequency = 100;
		this.trkSatOBack2.Scroll += new System.EventHandler(trkSatOBack2_Scroll);
		this.txtSatOBack2.Location = new System.Drawing.Point(147, 111);
		this.txtSatOBack2.Name = "txtSatOBack2";
		this.txtSatOBack2.Size = new System.Drawing.Size(56, 20);
		this.txtSatOBack2.TabIndex = 12;
		this.txtSatOBack2.TextChanged += new System.EventHandler(txtSatOBack2_TextChanged);
		this.label21.AutoSize = true;
		this.label21.Location = new System.Drawing.Point(12, 111);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(26, 13);
		this.label21.TabIndex = 10;
		this.label21.Text = "Sat:";
		this.trkBOBack2.Location = new System.Drawing.Point(36, 85);
		this.trkBOBack2.Maximum = 1000;
		this.trkBOBack2.Name = "trkBOBack2";
		this.trkBOBack2.Size = new System.Drawing.Size(85, 45);
		this.trkBOBack2.TabIndex = 8;
		this.trkBOBack2.TickFrequency = 100;
		this.trkBOBack2.Scroll += new System.EventHandler(trkBOBack2_Scroll);
		this.txtBOBack2.Location = new System.Drawing.Point(127, 85);
		this.txtBOBack2.Name = "txtBOBack2";
		this.txtBOBack2.Size = new System.Drawing.Size(35, 20);
		this.txtBOBack2.TabIndex = 9;
		this.txtBOBack2.TextChanged += new System.EventHandler(txtBOBack2_TextChanged);
		this.label22.AutoSize = true;
		this.label22.Location = new System.Drawing.Point(12, 85);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(17, 13);
		this.label22.TabIndex = 7;
		this.label22.Text = "B:";
		this.trkGOBack2.Location = new System.Drawing.Point(36, 60);
		this.trkGOBack2.Maximum = 1000;
		this.trkGOBack2.Name = "trkGOBack2";
		this.trkGOBack2.Size = new System.Drawing.Size(85, 45);
		this.trkGOBack2.TabIndex = 5;
		this.trkGOBack2.TickFrequency = 100;
		this.trkGOBack2.Scroll += new System.EventHandler(trkGOBack2_Scroll);
		this.txtGOBack2.Location = new System.Drawing.Point(127, 60);
		this.txtGOBack2.Name = "txtGOBack2";
		this.txtGOBack2.Size = new System.Drawing.Size(35, 20);
		this.txtGOBack2.TabIndex = 6;
		this.txtGOBack2.TextChanged += new System.EventHandler(txtGOBack2_TextChanged);
		this.label23.AutoSize = true;
		this.label23.Location = new System.Drawing.Point(12, 60);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(18, 13);
		this.label23.TabIndex = 4;
		this.label23.Text = "G:";
		this.trkROBack2.Location = new System.Drawing.Point(36, 34);
		this.trkROBack2.Maximum = 1000;
		this.trkROBack2.Name = "trkROBack2";
		this.trkROBack2.Size = new System.Drawing.Size(85, 45);
		this.trkROBack2.TabIndex = 2;
		this.trkROBack2.TickFrequency = 100;
		this.trkROBack2.Scroll += new System.EventHandler(trkROBack2_Scroll);
		this.txtROBack2.Location = new System.Drawing.Point(127, 34);
		this.txtROBack2.Name = "txtROBack2";
		this.txtROBack2.Size = new System.Drawing.Size(35, 20);
		this.txtROBack2.TabIndex = 3;
		this.txtROBack2.TextChanged += new System.EventHandler(txtROBack2_TextChanged);
		this.label24.AutoSize = true;
		this.label24.Location = new System.Drawing.Point(12, 34);
		this.label24.Name = "label24";
		this.label24.Size = new System.Drawing.Size(18, 13);
		this.label24.TabIndex = 1;
		this.label24.Text = "R:";
		this.panel5.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel5.Controls.Add(this.txtBBOBack1);
		this.panel5.Controls.Add(this.txtBGOBack1);
		this.panel5.Controls.Add(this.txtBROBack1);
		this.panel5.Controls.Add(this.trkGammaOBack1);
		this.panel5.Controls.Add(this.txtGammaOBack1);
		this.panel5.Controls.Add(this.label185);
		this.panel5.Controls.Add(this.trkBriteOBack1);
		this.panel5.Controls.Add(this.txtBriteOBack1);
		this.panel5.Controls.Add(this.label186);
		this.panel5.Controls.Add(this.label25);
		this.panel5.Controls.Add(this.trkTintOBack1);
		this.panel5.Controls.Add(this.txtTintOBack1);
		this.panel5.Controls.Add(this.label26);
		this.panel5.Controls.Add(this.trkSatOBack1);
		this.panel5.Controls.Add(this.txtSatOBack1);
		this.panel5.Controls.Add(this.label27);
		this.panel5.Controls.Add(this.trkBOBack1);
		this.panel5.Controls.Add(this.txtBOBack1);
		this.panel5.Controls.Add(this.label28);
		this.panel5.Controls.Add(this.trkGOBack1);
		this.panel5.Controls.Add(this.txtGOBack1);
		this.panel5.Controls.Add(this.label29);
		this.panel5.Controls.Add(this.trkROBack1);
		this.panel5.Controls.Add(this.txtROBack1);
		this.panel5.Controls.Add(this.label30);
		this.panel5.Location = new System.Drawing.Point(225, 234);
		this.panel5.Name = "panel5";
		this.panel5.Size = new System.Drawing.Size(213, 220);
		this.panel5.TabIndex = 20;
		this.trkGammaOBack1.Location = new System.Drawing.Point(36, 189);
		this.trkGammaOBack1.Maximum = 1000;
		this.trkGammaOBack1.Minimum = -1000;
		this.trkGammaOBack1.Name = "trkGammaOBack1";
		this.trkGammaOBack1.Size = new System.Drawing.Size(104, 45);
		this.trkGammaOBack1.TabIndex = 27;
		this.trkGammaOBack1.TickFrequency = 200;
		this.trkGammaOBack1.Scroll += new System.EventHandler(trkGammaOBack1_Scroll);
		this.txtGammaOBack1.Location = new System.Drawing.Point(147, 189);
		this.txtGammaOBack1.Name = "txtGammaOBack1";
		this.txtGammaOBack1.Size = new System.Drawing.Size(56, 20);
		this.txtGammaOBack1.TabIndex = 28;
		this.txtGammaOBack1.TextChanged += new System.EventHandler(txtGammaOBack1_TextChanged);
		this.label185.AutoSize = true;
		this.label185.Location = new System.Drawing.Point(12, 189);
		this.label185.Name = "label185";
		this.label185.Size = new System.Drawing.Size(26, 13);
		this.label185.TabIndex = 26;
		this.label185.Text = "Gm:";
		this.trkBriteOBack1.Location = new System.Drawing.Point(36, 163);
		this.trkBriteOBack1.Maximum = 1000;
		this.trkBriteOBack1.Name = "trkBriteOBack1";
		this.trkBriteOBack1.Size = new System.Drawing.Size(104, 45);
		this.trkBriteOBack1.TabIndex = 24;
		this.trkBriteOBack1.TickFrequency = 100;
		this.trkBriteOBack1.Scroll += new System.EventHandler(trkBriteOBack1_Scroll);
		this.txtBriteOBack1.Location = new System.Drawing.Point(147, 163);
		this.txtBriteOBack1.Name = "txtBriteOBack1";
		this.txtBriteOBack1.Size = new System.Drawing.Size(56, 20);
		this.txtBriteOBack1.TabIndex = 25;
		this.txtBriteOBack1.TextChanged += new System.EventHandler(txtBriteOBack1_TextChanged);
		this.label186.AutoSize = true;
		this.label186.Location = new System.Drawing.Point(12, 163);
		this.label186.Name = "label186";
		this.label186.Size = new System.Drawing.Size(25, 13);
		this.label186.TabIndex = 23;
		this.label186.Text = "Brit:";
		this.label25.AutoSize = true;
		this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label25.Location = new System.Drawing.Point(12, 13);
		this.label25.Name = "label25";
		this.label25.Size = new System.Drawing.Size(60, 13);
		this.label25.TabIndex = 16;
		this.label25.Text = "O Back 1";
		this.trkTintOBack1.Location = new System.Drawing.Point(36, 137);
		this.trkTintOBack1.Maximum = 1000;
		this.trkTintOBack1.Name = "trkTintOBack1";
		this.trkTintOBack1.Size = new System.Drawing.Size(104, 45);
		this.trkTintOBack1.TabIndex = 14;
		this.trkTintOBack1.TickFrequency = 100;
		this.trkTintOBack1.Scroll += new System.EventHandler(trkTintOBack1_Scroll);
		this.txtTintOBack1.Location = new System.Drawing.Point(147, 137);
		this.txtTintOBack1.Name = "txtTintOBack1";
		this.txtTintOBack1.Size = new System.Drawing.Size(56, 20);
		this.txtTintOBack1.TabIndex = 15;
		this.txtTintOBack1.TextChanged += new System.EventHandler(txtTintOBack1_TextChanged);
		this.label26.AutoSize = true;
		this.label26.Location = new System.Drawing.Point(12, 137);
		this.label26.Name = "label26";
		this.label26.Size = new System.Drawing.Size(28, 13);
		this.label26.TabIndex = 13;
		this.label26.Text = "Tint:";
		this.trkSatOBack1.Location = new System.Drawing.Point(36, 111);
		this.trkSatOBack1.Maximum = 1000;
		this.trkSatOBack1.Name = "trkSatOBack1";
		this.trkSatOBack1.Size = new System.Drawing.Size(104, 45);
		this.trkSatOBack1.TabIndex = 11;
		this.trkSatOBack1.TickFrequency = 100;
		this.trkSatOBack1.Scroll += new System.EventHandler(trkSatOBack1_Scroll);
		this.txtSatOBack1.Location = new System.Drawing.Point(147, 111);
		this.txtSatOBack1.Name = "txtSatOBack1";
		this.txtSatOBack1.Size = new System.Drawing.Size(56, 20);
		this.txtSatOBack1.TabIndex = 12;
		this.txtSatOBack1.TextChanged += new System.EventHandler(txtSatOBack1_TextChanged);
		this.label27.AutoSize = true;
		this.label27.Location = new System.Drawing.Point(12, 111);
		this.label27.Name = "label27";
		this.label27.Size = new System.Drawing.Size(26, 13);
		this.label27.TabIndex = 10;
		this.label27.Text = "Sat:";
		this.trkBOBack1.Location = new System.Drawing.Point(36, 85);
		this.trkBOBack1.Maximum = 1000;
		this.trkBOBack1.Name = "trkBOBack1";
		this.trkBOBack1.Size = new System.Drawing.Size(85, 45);
		this.trkBOBack1.TabIndex = 8;
		this.trkBOBack1.TickFrequency = 100;
		this.trkBOBack1.Scroll += new System.EventHandler(trkBOBack1_Scroll);
		this.txtBOBack1.Location = new System.Drawing.Point(127, 85);
		this.txtBOBack1.Name = "txtBOBack1";
		this.txtBOBack1.Size = new System.Drawing.Size(35, 20);
		this.txtBOBack1.TabIndex = 9;
		this.txtBOBack1.TextChanged += new System.EventHandler(txtBOBack1_TextChanged);
		this.label28.AutoSize = true;
		this.label28.Location = new System.Drawing.Point(12, 85);
		this.label28.Name = "label28";
		this.label28.Size = new System.Drawing.Size(17, 13);
		this.label28.TabIndex = 7;
		this.label28.Text = "B:";
		this.trkGOBack1.Location = new System.Drawing.Point(36, 60);
		this.trkGOBack1.Maximum = 1000;
		this.trkGOBack1.Name = "trkGOBack1";
		this.trkGOBack1.Size = new System.Drawing.Size(85, 45);
		this.trkGOBack1.TabIndex = 5;
		this.trkGOBack1.TickFrequency = 100;
		this.trkGOBack1.Scroll += new System.EventHandler(trkGOBack1_Scroll);
		this.txtGOBack1.Location = new System.Drawing.Point(127, 60);
		this.txtGOBack1.Name = "txtGOBack1";
		this.txtGOBack1.Size = new System.Drawing.Size(35, 20);
		this.txtGOBack1.TabIndex = 6;
		this.txtGOBack1.TextChanged += new System.EventHandler(txtGOBack1_TextChanged);
		this.label29.AutoSize = true;
		this.label29.Location = new System.Drawing.Point(12, 60);
		this.label29.Name = "label29";
		this.label29.Size = new System.Drawing.Size(18, 13);
		this.label29.TabIndex = 4;
		this.label29.Text = "G:";
		this.trkROBack1.Location = new System.Drawing.Point(36, 34);
		this.trkROBack1.Maximum = 1000;
		this.trkROBack1.Name = "trkROBack1";
		this.trkROBack1.Size = new System.Drawing.Size(85, 45);
		this.trkROBack1.TabIndex = 2;
		this.trkROBack1.TickFrequency = 100;
		this.trkROBack1.Scroll += new System.EventHandler(trkROBack1_Scroll);
		this.txtROBack1.Location = new System.Drawing.Point(127, 34);
		this.txtROBack1.Name = "txtROBack1";
		this.txtROBack1.Size = new System.Drawing.Size(35, 20);
		this.txtROBack1.TabIndex = 3;
		this.txtROBack1.TextChanged += new System.EventHandler(txtROBack1_TextChanged);
		this.label30.AutoSize = true;
		this.label30.Location = new System.Drawing.Point(12, 34);
		this.label30.Name = "label30";
		this.label30.Size = new System.Drawing.Size(18, 13);
		this.label30.TabIndex = 1;
		this.label30.Text = "R:";
		this.panel6.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.panel6.Controls.Add(this.txtBBOMid);
		this.panel6.Controls.Add(this.txtBGOMid);
		this.panel6.Controls.Add(this.txtBROMid);
		this.panel6.Controls.Add(this.trkGammaOMid);
		this.panel6.Controls.Add(this.txtGammaOMid);
		this.panel6.Controls.Add(this.label187);
		this.panel6.Controls.Add(this.trkBriteOMid);
		this.panel6.Controls.Add(this.txtBriteOMid);
		this.panel6.Controls.Add(this.label188);
		this.panel6.Controls.Add(this.label31);
		this.panel6.Controls.Add(this.trkTintOMid);
		this.panel6.Controls.Add(this.txtTintOMid);
		this.panel6.Controls.Add(this.label32);
		this.panel6.Controls.Add(this.trkSatOMid);
		this.panel6.Controls.Add(this.txtSatOMid);
		this.panel6.Controls.Add(this.label33);
		this.panel6.Controls.Add(this.trkBOMid);
		this.panel6.Controls.Add(this.txtBOMid);
		this.panel6.Controls.Add(this.label34);
		this.panel6.Controls.Add(this.trkGOMid);
		this.panel6.Controls.Add(this.txtGOMid);
		this.panel6.Controls.Add(this.label35);
		this.panel6.Controls.Add(this.trkROMid);
		this.panel6.Controls.Add(this.txtROMid);
		this.panel6.Controls.Add(this.label36);
		this.panel6.Location = new System.Drawing.Point(444, 234);
		this.panel6.Name = "panel6";
		this.panel6.Size = new System.Drawing.Size(213, 220);
		this.panel6.TabIndex = 21;
		this.trkGammaOMid.Location = new System.Drawing.Point(36, 189);
		this.trkGammaOMid.Maximum = 1000;
		this.trkGammaOMid.Minimum = -1000;
		this.trkGammaOMid.Name = "trkGammaOMid";
		this.trkGammaOMid.Size = new System.Drawing.Size(104, 45);
		this.trkGammaOMid.TabIndex = 27;
		this.trkGammaOMid.TickFrequency = 200;
		this.trkGammaOMid.Scroll += new System.EventHandler(trkGammaOMid_Scroll);
		this.txtGammaOMid.Location = new System.Drawing.Point(147, 189);
		this.txtGammaOMid.Name = "txtGammaOMid";
		this.txtGammaOMid.Size = new System.Drawing.Size(56, 20);
		this.txtGammaOMid.TabIndex = 28;
		this.txtGammaOMid.TextChanged += new System.EventHandler(txtGammaOMid_TextChanged);
		this.label187.AutoSize = true;
		this.label187.Location = new System.Drawing.Point(12, 189);
		this.label187.Name = "label187";
		this.label187.Size = new System.Drawing.Size(26, 13);
		this.label187.TabIndex = 26;
		this.label187.Text = "Gm:";
		this.trkBriteOMid.Location = new System.Drawing.Point(36, 163);
		this.trkBriteOMid.Maximum = 1000;
		this.trkBriteOMid.Name = "trkBriteOMid";
		this.trkBriteOMid.Size = new System.Drawing.Size(104, 45);
		this.trkBriteOMid.TabIndex = 24;
		this.trkBriteOMid.TickFrequency = 100;
		this.trkBriteOMid.Scroll += new System.EventHandler(trkBriteOMid_Scroll);
		this.txtBriteOMid.Location = new System.Drawing.Point(147, 163);
		this.txtBriteOMid.Name = "txtBriteOMid";
		this.txtBriteOMid.Size = new System.Drawing.Size(56, 20);
		this.txtBriteOMid.TabIndex = 25;
		this.txtBriteOMid.TextChanged += new System.EventHandler(txtBriteOMid_TextChanged);
		this.label188.AutoSize = true;
		this.label188.Location = new System.Drawing.Point(12, 163);
		this.label188.Name = "label188";
		this.label188.Size = new System.Drawing.Size(25, 13);
		this.label188.TabIndex = 23;
		this.label188.Text = "Brit:";
		this.label31.AutoSize = true;
		this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label31.Location = new System.Drawing.Point(12, 13);
		this.label31.Name = "label31";
		this.label31.Size = new System.Drawing.Size(40, 13);
		this.label31.TabIndex = 16;
		this.label31.Text = "O Mid";
		this.trkTintOMid.Location = new System.Drawing.Point(36, 137);
		this.trkTintOMid.Maximum = 1000;
		this.trkTintOMid.Name = "trkTintOMid";
		this.trkTintOMid.Size = new System.Drawing.Size(104, 45);
		this.trkTintOMid.TabIndex = 14;
		this.trkTintOMid.TickFrequency = 100;
		this.trkTintOMid.Scroll += new System.EventHandler(trkTintOMid_Scroll);
		this.txtTintOMid.Location = new System.Drawing.Point(147, 137);
		this.txtTintOMid.Name = "txtTintOMid";
		this.txtTintOMid.Size = new System.Drawing.Size(56, 20);
		this.txtTintOMid.TabIndex = 15;
		this.txtTintOMid.TextChanged += new System.EventHandler(txtTintOMid_TextChanged);
		this.label32.AutoSize = true;
		this.label32.Location = new System.Drawing.Point(12, 137);
		this.label32.Name = "label32";
		this.label32.Size = new System.Drawing.Size(28, 13);
		this.label32.TabIndex = 13;
		this.label32.Text = "Tint:";
		this.trkSatOMid.Location = new System.Drawing.Point(36, 111);
		this.trkSatOMid.Maximum = 1000;
		this.trkSatOMid.Name = "trkSatOMid";
		this.trkSatOMid.Size = new System.Drawing.Size(104, 45);
		this.trkSatOMid.TabIndex = 11;
		this.trkSatOMid.TickFrequency = 100;
		this.trkSatOMid.Scroll += new System.EventHandler(trkSatOMid_Scroll);
		this.txtSatOMid.Location = new System.Drawing.Point(147, 111);
		this.txtSatOMid.Name = "txtSatOMid";
		this.txtSatOMid.Size = new System.Drawing.Size(56, 20);
		this.txtSatOMid.TabIndex = 12;
		this.txtSatOMid.TextChanged += new System.EventHandler(txtSatOMid_TextChanged);
		this.label33.AutoSize = true;
		this.label33.Location = new System.Drawing.Point(12, 111);
		this.label33.Name = "label33";
		this.label33.Size = new System.Drawing.Size(26, 13);
		this.label33.TabIndex = 10;
		this.label33.Text = "Sat:";
		this.trkBOMid.Location = new System.Drawing.Point(36, 85);
		this.trkBOMid.Maximum = 1000;
		this.trkBOMid.Name = "trkBOMid";
		this.trkBOMid.Size = new System.Drawing.Size(85, 45);
		this.trkBOMid.TabIndex = 8;
		this.trkBOMid.TickFrequency = 100;
		this.trkBOMid.Scroll += new System.EventHandler(trkBOMid_Scroll);
		this.txtBOMid.Location = new System.Drawing.Point(127, 85);
		this.txtBOMid.Name = "txtBOMid";
		this.txtBOMid.Size = new System.Drawing.Size(35, 20);
		this.txtBOMid.TabIndex = 9;
		this.txtBOMid.TextChanged += new System.EventHandler(txtBOMid_TextChanged);
		this.label34.AutoSize = true;
		this.label34.Location = new System.Drawing.Point(12, 85);
		this.label34.Name = "label34";
		this.label34.Size = new System.Drawing.Size(17, 13);
		this.label34.TabIndex = 7;
		this.label34.Text = "B:";
		this.trkGOMid.Location = new System.Drawing.Point(36, 60);
		this.trkGOMid.Maximum = 1000;
		this.trkGOMid.Name = "trkGOMid";
		this.trkGOMid.Size = new System.Drawing.Size(85, 45);
		this.trkGOMid.TabIndex = 5;
		this.trkGOMid.TickFrequency = 100;
		this.trkGOMid.Scroll += new System.EventHandler(trkGOMid_Scroll);
		this.txtGOMid.Location = new System.Drawing.Point(127, 60);
		this.txtGOMid.Name = "txtGOMid";
		this.txtGOMid.Size = new System.Drawing.Size(35, 20);
		this.txtGOMid.TabIndex = 6;
		this.txtGOMid.TextChanged += new System.EventHandler(txtGOMid_TextChanged);
		this.label35.AutoSize = true;
		this.label35.Location = new System.Drawing.Point(12, 60);
		this.label35.Name = "label35";
		this.label35.Size = new System.Drawing.Size(18, 13);
		this.label35.TabIndex = 4;
		this.label35.Text = "G:";
		this.trkROMid.Location = new System.Drawing.Point(36, 34);
		this.trkROMid.Maximum = 1000;
		this.trkROMid.Name = "trkROMid";
		this.trkROMid.Size = new System.Drawing.Size(85, 45);
		this.trkROMid.TabIndex = 2;
		this.trkROMid.TickFrequency = 100;
		this.trkROMid.Scroll += new System.EventHandler(trkROMid_Scroll);
		this.txtROMid.Location = new System.Drawing.Point(127, 34);
		this.txtROMid.Name = "txtROMid";
		this.txtROMid.Size = new System.Drawing.Size(35, 20);
		this.txtROMid.TabIndex = 3;
		this.txtROMid.TextChanged += new System.EventHandler(txtROMid_TextChanged);
		this.label36.AutoSize = true;
		this.label36.Location = new System.Drawing.Point(12, 34);
		this.label36.Name = "label36";
		this.label36.Size = new System.Drawing.Size(18, 13);
		this.label36.TabIndex = 1;
		this.label36.Text = "R:";
		this.panel7.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel7.Controls.Add(this.txtBBOFore1);
		this.panel7.Controls.Add(this.txtBGOFore1);
		this.panel7.Controls.Add(this.txtBROFore1);
		this.panel7.Controls.Add(this.trkGammaOFore1);
		this.panel7.Controls.Add(this.txtGammaOFore1);
		this.panel7.Controls.Add(this.label189);
		this.panel7.Controls.Add(this.trkBriteOFore1);
		this.panel7.Controls.Add(this.txtBriteOFore1);
		this.panel7.Controls.Add(this.label190);
		this.panel7.Controls.Add(this.label37);
		this.panel7.Controls.Add(this.trkTintOFore1);
		this.panel7.Controls.Add(this.txtTintOFore1);
		this.panel7.Controls.Add(this.label38);
		this.panel7.Controls.Add(this.trkSatOFore1);
		this.panel7.Controls.Add(this.txtSatOFore1);
		this.panel7.Controls.Add(this.label39);
		this.panel7.Controls.Add(this.trkBOFore1);
		this.panel7.Controls.Add(this.txtBOFore1);
		this.panel7.Controls.Add(this.label40);
		this.panel7.Controls.Add(this.trkGOFore1);
		this.panel7.Controls.Add(this.txtGOFore1);
		this.panel7.Controls.Add(this.label41);
		this.panel7.Controls.Add(this.trkROFore1);
		this.panel7.Controls.Add(this.txtROFore1);
		this.panel7.Controls.Add(this.label42);
		this.panel7.Location = new System.Drawing.Point(663, 234);
		this.panel7.Name = "panel7";
		this.panel7.Size = new System.Drawing.Size(213, 220);
		this.panel7.TabIndex = 21;
		this.trkGammaOFore1.Location = new System.Drawing.Point(36, 189);
		this.trkGammaOFore1.Maximum = 1000;
		this.trkGammaOFore1.Minimum = -1000;
		this.trkGammaOFore1.Name = "trkGammaOFore1";
		this.trkGammaOFore1.Size = new System.Drawing.Size(104, 45);
		this.trkGammaOFore1.TabIndex = 27;
		this.trkGammaOFore1.TickFrequency = 200;
		this.trkGammaOFore1.Scroll += new System.EventHandler(trkGammaOFore1_Scroll);
		this.txtGammaOFore1.Location = new System.Drawing.Point(147, 189);
		this.txtGammaOFore1.Name = "txtGammaOFore1";
		this.txtGammaOFore1.Size = new System.Drawing.Size(56, 20);
		this.txtGammaOFore1.TabIndex = 28;
		this.txtGammaOFore1.TextChanged += new System.EventHandler(txtGammaOFore1_TextChanged);
		this.label189.AutoSize = true;
		this.label189.Location = new System.Drawing.Point(12, 189);
		this.label189.Name = "label189";
		this.label189.Size = new System.Drawing.Size(26, 13);
		this.label189.TabIndex = 26;
		this.label189.Text = "Gm:";
		this.trkBriteOFore1.Location = new System.Drawing.Point(36, 163);
		this.trkBriteOFore1.Maximum = 1000;
		this.trkBriteOFore1.Name = "trkBriteOFore1";
		this.trkBriteOFore1.Size = new System.Drawing.Size(104, 45);
		this.trkBriteOFore1.TabIndex = 24;
		this.trkBriteOFore1.TickFrequency = 100;
		this.trkBriteOFore1.Scroll += new System.EventHandler(trkBriteOFore1_Scroll);
		this.txtBriteOFore1.Location = new System.Drawing.Point(147, 163);
		this.txtBriteOFore1.Name = "txtBriteOFore1";
		this.txtBriteOFore1.Size = new System.Drawing.Size(56, 20);
		this.txtBriteOFore1.TabIndex = 25;
		this.txtBriteOFore1.TextChanged += new System.EventHandler(txtBriteOFore1_TextChanged);
		this.label190.AutoSize = true;
		this.label190.Location = new System.Drawing.Point(12, 163);
		this.label190.Name = "label190";
		this.label190.Size = new System.Drawing.Size(25, 13);
		this.label190.TabIndex = 23;
		this.label190.Text = "Brit:";
		this.label37.AutoSize = true;
		this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label37.Location = new System.Drawing.Point(12, 13);
		this.label37.Name = "label37";
		this.label37.Size = new System.Drawing.Size(56, 13);
		this.label37.TabIndex = 16;
		this.label37.Text = "O Fore 1";
		this.trkTintOFore1.Location = new System.Drawing.Point(36, 137);
		this.trkTintOFore1.Maximum = 1000;
		this.trkTintOFore1.Name = "trkTintOFore1";
		this.trkTintOFore1.Size = new System.Drawing.Size(104, 45);
		this.trkTintOFore1.TabIndex = 14;
		this.trkTintOFore1.TickFrequency = 100;
		this.trkTintOFore1.Scroll += new System.EventHandler(trkTintOFore1_Scroll);
		this.txtTintOFore1.Location = new System.Drawing.Point(147, 137);
		this.txtTintOFore1.Name = "txtTintOFore1";
		this.txtTintOFore1.Size = new System.Drawing.Size(56, 20);
		this.txtTintOFore1.TabIndex = 15;
		this.txtTintOFore1.TextChanged += new System.EventHandler(txtTintOFore1_TextChanged);
		this.label38.AutoSize = true;
		this.label38.Location = new System.Drawing.Point(12, 137);
		this.label38.Name = "label38";
		this.label38.Size = new System.Drawing.Size(28, 13);
		this.label38.TabIndex = 13;
		this.label38.Text = "Tint:";
		this.trkSatOFore1.Location = new System.Drawing.Point(36, 111);
		this.trkSatOFore1.Maximum = 1000;
		this.trkSatOFore1.Name = "trkSatOFore1";
		this.trkSatOFore1.Size = new System.Drawing.Size(104, 45);
		this.trkSatOFore1.TabIndex = 11;
		this.trkSatOFore1.TickFrequency = 100;
		this.trkSatOFore1.Scroll += new System.EventHandler(trkSatOFore1_Scroll);
		this.txtSatOFore1.Location = new System.Drawing.Point(147, 111);
		this.txtSatOFore1.Name = "txtSatOFore1";
		this.txtSatOFore1.Size = new System.Drawing.Size(56, 20);
		this.txtSatOFore1.TabIndex = 12;
		this.txtSatOFore1.TextChanged += new System.EventHandler(txtSatOFore1_TextChanged);
		this.label39.AutoSize = true;
		this.label39.Location = new System.Drawing.Point(12, 113);
		this.label39.Name = "label39";
		this.label39.Size = new System.Drawing.Size(26, 13);
		this.label39.TabIndex = 10;
		this.label39.Text = "Sat:";
		this.trkBOFore1.Location = new System.Drawing.Point(36, 85);
		this.trkBOFore1.Maximum = 1000;
		this.trkBOFore1.Name = "trkBOFore1";
		this.trkBOFore1.Size = new System.Drawing.Size(85, 45);
		this.trkBOFore1.TabIndex = 8;
		this.trkBOFore1.TickFrequency = 100;
		this.trkBOFore1.Scroll += new System.EventHandler(trkBOFore1_Scroll);
		this.txtBOFore1.Location = new System.Drawing.Point(127, 85);
		this.txtBOFore1.Name = "txtBOFore1";
		this.txtBOFore1.Size = new System.Drawing.Size(35, 20);
		this.txtBOFore1.TabIndex = 9;
		this.txtBOFore1.TextChanged += new System.EventHandler(txtBOFore1_TextChanged);
		this.label40.AutoSize = true;
		this.label40.Location = new System.Drawing.Point(12, 85);
		this.label40.Name = "label40";
		this.label40.Size = new System.Drawing.Size(17, 13);
		this.label40.TabIndex = 7;
		this.label40.Text = "B:";
		this.trkGOFore1.Location = new System.Drawing.Point(36, 60);
		this.trkGOFore1.Maximum = 1000;
		this.trkGOFore1.Name = "trkGOFore1";
		this.trkGOFore1.Size = new System.Drawing.Size(85, 45);
		this.trkGOFore1.TabIndex = 5;
		this.trkGOFore1.TickFrequency = 100;
		this.trkGOFore1.Scroll += new System.EventHandler(trkGOFore1_Scroll);
		this.txtGOFore1.Location = new System.Drawing.Point(127, 60);
		this.txtGOFore1.Name = "txtGOFore1";
		this.txtGOFore1.Size = new System.Drawing.Size(35, 20);
		this.txtGOFore1.TabIndex = 6;
		this.txtGOFore1.TextChanged += new System.EventHandler(txtGOFore1_TextChanged);
		this.label41.AutoSize = true;
		this.label41.Location = new System.Drawing.Point(12, 60);
		this.label41.Name = "label41";
		this.label41.Size = new System.Drawing.Size(18, 13);
		this.label41.TabIndex = 4;
		this.label41.Text = "G:";
		this.trkROFore1.Location = new System.Drawing.Point(36, 34);
		this.trkROFore1.Maximum = 1000;
		this.trkROFore1.Name = "trkROFore1";
		this.trkROFore1.Size = new System.Drawing.Size(85, 45);
		this.trkROFore1.TabIndex = 2;
		this.trkROFore1.TickFrequency = 100;
		this.trkROFore1.Scroll += new System.EventHandler(trkROFore1_Scroll);
		this.txtROFore1.Location = new System.Drawing.Point(127, 34);
		this.txtROFore1.Name = "txtROFore1";
		this.txtROFore1.Size = new System.Drawing.Size(35, 20);
		this.txtROFore1.TabIndex = 3;
		this.txtROFore1.TextChanged += new System.EventHandler(txtROFore1_TextChanged);
		this.label42.AutoSize = true;
		this.label42.Location = new System.Drawing.Point(12, 34);
		this.label42.Name = "label42";
		this.label42.Size = new System.Drawing.Size(18, 13);
		this.label42.TabIndex = 1;
		this.label42.Text = "R:";
		this.panel8.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel8.Controls.Add(this.txtBBOFore2);
		this.panel8.Controls.Add(this.txtBGOFore2);
		this.panel8.Controls.Add(this.txtBROFore2);
		this.panel8.Controls.Add(this.trkGammaOFore2);
		this.panel8.Controls.Add(this.txtGammaOFore2);
		this.panel8.Controls.Add(this.label191);
		this.panel8.Controls.Add(this.trkBriteOFore2);
		this.panel8.Controls.Add(this.txtBriteOFore2);
		this.panel8.Controls.Add(this.label192);
		this.panel8.Controls.Add(this.label43);
		this.panel8.Controls.Add(this.trkTintOFore2);
		this.panel8.Controls.Add(this.txtTintOFore2);
		this.panel8.Controls.Add(this.label44);
		this.panel8.Controls.Add(this.trkSatOFore2);
		this.panel8.Controls.Add(this.txtSatOFore2);
		this.panel8.Controls.Add(this.label45);
		this.panel8.Controls.Add(this.trkBOFore2);
		this.panel8.Controls.Add(this.txtBOFore2);
		this.panel8.Controls.Add(this.label46);
		this.panel8.Controls.Add(this.trkGOFore2);
		this.panel8.Controls.Add(this.txtGOFore2);
		this.panel8.Controls.Add(this.label47);
		this.panel8.Controls.Add(this.trkROFore2);
		this.panel8.Controls.Add(this.txtROFore2);
		this.panel8.Controls.Add(this.label48);
		this.panel8.Location = new System.Drawing.Point(6, 460);
		this.panel8.Name = "panel8";
		this.panel8.Size = new System.Drawing.Size(213, 220);
		this.panel8.TabIndex = 22;
		this.trkGammaOFore2.Location = new System.Drawing.Point(36, 189);
		this.trkGammaOFore2.Maximum = 1000;
		this.trkGammaOFore2.Minimum = -1000;
		this.trkGammaOFore2.Name = "trkGammaOFore2";
		this.trkGammaOFore2.Size = new System.Drawing.Size(104, 45);
		this.trkGammaOFore2.TabIndex = 27;
		this.trkGammaOFore2.TickFrequency = 200;
		this.trkGammaOFore2.Scroll += new System.EventHandler(trkGammaOFore2_Scroll);
		this.txtGammaOFore2.Location = new System.Drawing.Point(147, 189);
		this.txtGammaOFore2.Name = "txtGammaOFore2";
		this.txtGammaOFore2.Size = new System.Drawing.Size(56, 20);
		this.txtGammaOFore2.TabIndex = 28;
		this.txtGammaOFore2.TextChanged += new System.EventHandler(txtGammaOFore2_TextChanged);
		this.label191.AutoSize = true;
		this.label191.Location = new System.Drawing.Point(12, 189);
		this.label191.Name = "label191";
		this.label191.Size = new System.Drawing.Size(26, 13);
		this.label191.TabIndex = 26;
		this.label191.Text = "Gm:";
		this.trkBriteOFore2.Location = new System.Drawing.Point(36, 163);
		this.trkBriteOFore2.Maximum = 1000;
		this.trkBriteOFore2.Name = "trkBriteOFore2";
		this.trkBriteOFore2.Size = new System.Drawing.Size(104, 45);
		this.trkBriteOFore2.TabIndex = 24;
		this.trkBriteOFore2.TickFrequency = 100;
		this.trkBriteOFore2.Scroll += new System.EventHandler(trkBriteOFore2_Scroll);
		this.txtBriteOFore2.Location = new System.Drawing.Point(147, 163);
		this.txtBriteOFore2.Name = "txtBriteOFore2";
		this.txtBriteOFore2.Size = new System.Drawing.Size(56, 20);
		this.txtBriteOFore2.TabIndex = 25;
		this.txtBriteOFore2.TextChanged += new System.EventHandler(txtBriteOFore2_TextChanged);
		this.label192.AutoSize = true;
		this.label192.Location = new System.Drawing.Point(12, 163);
		this.label192.Name = "label192";
		this.label192.Size = new System.Drawing.Size(25, 13);
		this.label192.TabIndex = 23;
		this.label192.Text = "Brit:";
		this.label43.AutoSize = true;
		this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label43.Location = new System.Drawing.Point(12, 13);
		this.label43.Name = "label43";
		this.label43.Size = new System.Drawing.Size(56, 13);
		this.label43.TabIndex = 16;
		this.label43.Text = "O Fore 2";
		this.trkTintOFore2.Location = new System.Drawing.Point(36, 137);
		this.trkTintOFore2.Maximum = 1000;
		this.trkTintOFore2.Name = "trkTintOFore2";
		this.trkTintOFore2.Size = new System.Drawing.Size(104, 45);
		this.trkTintOFore2.TabIndex = 14;
		this.trkTintOFore2.TickFrequency = 100;
		this.trkTintOFore2.Scroll += new System.EventHandler(trkTintOFore2_Scroll);
		this.txtTintOFore2.Location = new System.Drawing.Point(147, 137);
		this.txtTintOFore2.Name = "txtTintOFore2";
		this.txtTintOFore2.Size = new System.Drawing.Size(56, 20);
		this.txtTintOFore2.TabIndex = 15;
		this.txtTintOFore2.TextChanged += new System.EventHandler(txtTintOFore2_TextChanged);
		this.label44.AutoSize = true;
		this.label44.Location = new System.Drawing.Point(12, 137);
		this.label44.Name = "label44";
		this.label44.Size = new System.Drawing.Size(28, 13);
		this.label44.TabIndex = 13;
		this.label44.Text = "Tint:";
		this.trkSatOFore2.Location = new System.Drawing.Point(36, 111);
		this.trkSatOFore2.Maximum = 1000;
		this.trkSatOFore2.Name = "trkSatOFore2";
		this.trkSatOFore2.Size = new System.Drawing.Size(104, 45);
		this.trkSatOFore2.TabIndex = 11;
		this.trkSatOFore2.TickFrequency = 100;
		this.trkSatOFore2.Scroll += new System.EventHandler(trkSatOFore2_Scroll);
		this.txtSatOFore2.Location = new System.Drawing.Point(147, 111);
		this.txtSatOFore2.Name = "txtSatOFore2";
		this.txtSatOFore2.Size = new System.Drawing.Size(56, 20);
		this.txtSatOFore2.TabIndex = 12;
		this.txtSatOFore2.TextChanged += new System.EventHandler(txtSatOFore2_TextChanged);
		this.label45.AutoSize = true;
		this.label45.Location = new System.Drawing.Point(12, 111);
		this.label45.Name = "label45";
		this.label45.Size = new System.Drawing.Size(26, 13);
		this.label45.TabIndex = 10;
		this.label45.Text = "Sat:";
		this.trkBOFore2.Location = new System.Drawing.Point(36, 85);
		this.trkBOFore2.Maximum = 1000;
		this.trkBOFore2.Name = "trkBOFore2";
		this.trkBOFore2.Size = new System.Drawing.Size(85, 45);
		this.trkBOFore2.TabIndex = 8;
		this.trkBOFore2.TickFrequency = 100;
		this.trkBOFore2.Scroll += new System.EventHandler(trkBOFore2_Scroll);
		this.txtBOFore2.Location = new System.Drawing.Point(127, 85);
		this.txtBOFore2.Name = "txtBOFore2";
		this.txtBOFore2.Size = new System.Drawing.Size(35, 20);
		this.txtBOFore2.TabIndex = 9;
		this.txtBOFore2.TextChanged += new System.EventHandler(txtBOFore2_TextChanged);
		this.label46.AutoSize = true;
		this.label46.Location = new System.Drawing.Point(12, 85);
		this.label46.Name = "label46";
		this.label46.Size = new System.Drawing.Size(17, 13);
		this.label46.TabIndex = 7;
		this.label46.Text = "B:";
		this.trkGOFore2.Location = new System.Drawing.Point(36, 60);
		this.trkGOFore2.Maximum = 1000;
		this.trkGOFore2.Name = "trkGOFore2";
		this.trkGOFore2.Size = new System.Drawing.Size(85, 45);
		this.trkGOFore2.TabIndex = 5;
		this.trkGOFore2.TickFrequency = 100;
		this.trkGOFore2.Scroll += new System.EventHandler(trkGOFore2_Scroll);
		this.txtGOFore2.Location = new System.Drawing.Point(127, 60);
		this.txtGOFore2.Name = "txtGOFore2";
		this.txtGOFore2.Size = new System.Drawing.Size(35, 20);
		this.txtGOFore2.TabIndex = 6;
		this.txtGOFore2.TextChanged += new System.EventHandler(txtGOFore2_TextChanged);
		this.label47.AutoSize = true;
		this.label47.Location = new System.Drawing.Point(12, 60);
		this.label47.Name = "label47";
		this.label47.Size = new System.Drawing.Size(18, 13);
		this.label47.TabIndex = 4;
		this.label47.Text = "G:";
		this.trkROFore2.Location = new System.Drawing.Point(36, 34);
		this.trkROFore2.Maximum = 1000;
		this.trkROFore2.Name = "trkROFore2";
		this.trkROFore2.Size = new System.Drawing.Size(85, 45);
		this.trkROFore2.TabIndex = 2;
		this.trkROFore2.TickFrequency = 100;
		this.trkROFore2.Scroll += new System.EventHandler(trkROFore2_Scroll);
		this.txtROFore2.Location = new System.Drawing.Point(127, 34);
		this.txtROFore2.Name = "txtROFore2";
		this.txtROFore2.Size = new System.Drawing.Size(35, 20);
		this.txtROFore2.TabIndex = 3;
		this.txtROFore2.TextChanged += new System.EventHandler(txtROFore2_TextChanged);
		this.label48.AutoSize = true;
		this.label48.Location = new System.Drawing.Point(12, 34);
		this.label48.Name = "label48";
		this.label48.Size = new System.Drawing.Size(18, 13);
		this.label48.TabIndex = 1;
		this.label48.Text = "R:";
		this.panel9.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel9.Controls.Add(this.txtBBOFore3);
		this.panel9.Controls.Add(this.txtBGOFore3);
		this.panel9.Controls.Add(this.txtBROFore3);
		this.panel9.Controls.Add(this.trkGammaOFore3);
		this.panel9.Controls.Add(this.txtGammaOFore3);
		this.panel9.Controls.Add(this.label193);
		this.panel9.Controls.Add(this.trkBriteOFore3);
		this.panel9.Controls.Add(this.txtBriteOFore3);
		this.panel9.Controls.Add(this.label194);
		this.panel9.Controls.Add(this.label49);
		this.panel9.Controls.Add(this.trkTintOFore3);
		this.panel9.Controls.Add(this.txtTintOFore3);
		this.panel9.Controls.Add(this.label50);
		this.panel9.Controls.Add(this.trkSatOFore3);
		this.panel9.Controls.Add(this.txtSatOFore3);
		this.panel9.Controls.Add(this.label51);
		this.panel9.Controls.Add(this.trkBOFore3);
		this.panel9.Controls.Add(this.txtBOFore3);
		this.panel9.Controls.Add(this.label52);
		this.panel9.Controls.Add(this.trkGOFore3);
		this.panel9.Controls.Add(this.txtGOFore3);
		this.panel9.Controls.Add(this.label53);
		this.panel9.Controls.Add(this.trkROFore3);
		this.panel9.Controls.Add(this.txtROFore3);
		this.panel9.Controls.Add(this.label54);
		this.panel9.Location = new System.Drawing.Point(225, 460);
		this.panel9.Name = "panel9";
		this.panel9.Size = new System.Drawing.Size(213, 220);
		this.panel9.TabIndex = 23;
		this.trkGammaOFore3.Location = new System.Drawing.Point(36, 189);
		this.trkGammaOFore3.Maximum = 1000;
		this.trkGammaOFore3.Minimum = -1000;
		this.trkGammaOFore3.Name = "trkGammaOFore3";
		this.trkGammaOFore3.Size = new System.Drawing.Size(104, 45);
		this.trkGammaOFore3.TabIndex = 27;
		this.trkGammaOFore3.TickFrequency = 200;
		this.trkGammaOFore3.Scroll += new System.EventHandler(trkGammaOFore3_Scroll);
		this.txtGammaOFore3.Location = new System.Drawing.Point(147, 189);
		this.txtGammaOFore3.Name = "txtGammaOFore3";
		this.txtGammaOFore3.Size = new System.Drawing.Size(56, 20);
		this.txtGammaOFore3.TabIndex = 28;
		this.txtGammaOFore3.TextChanged += new System.EventHandler(txtGammaOFore3_TextChanged);
		this.label193.AutoSize = true;
		this.label193.Location = new System.Drawing.Point(12, 189);
		this.label193.Name = "label193";
		this.label193.Size = new System.Drawing.Size(26, 13);
		this.label193.TabIndex = 26;
		this.label193.Text = "Gm:";
		this.trkBriteOFore3.Location = new System.Drawing.Point(36, 163);
		this.trkBriteOFore3.Maximum = 1000;
		this.trkBriteOFore3.Name = "trkBriteOFore3";
		this.trkBriteOFore3.Size = new System.Drawing.Size(104, 45);
		this.trkBriteOFore3.TabIndex = 24;
		this.trkBriteOFore3.TickFrequency = 100;
		this.trkBriteOFore3.Scroll += new System.EventHandler(trkBriteOFore3_Scroll);
		this.txtBriteOFore3.Location = new System.Drawing.Point(147, 163);
		this.txtBriteOFore3.Name = "txtBriteOFore3";
		this.txtBriteOFore3.Size = new System.Drawing.Size(56, 20);
		this.txtBriteOFore3.TabIndex = 25;
		this.txtBriteOFore3.TextChanged += new System.EventHandler(txtBriteOFore3_TextChanged);
		this.label194.AutoSize = true;
		this.label194.Location = new System.Drawing.Point(12, 163);
		this.label194.Name = "label194";
		this.label194.Size = new System.Drawing.Size(25, 13);
		this.label194.TabIndex = 23;
		this.label194.Text = "Brit:";
		this.label49.AutoSize = true;
		this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label49.Location = new System.Drawing.Point(12, 13);
		this.label49.Name = "label49";
		this.label49.Size = new System.Drawing.Size(56, 13);
		this.label49.TabIndex = 16;
		this.label49.Text = "O Fore 3";
		this.trkTintOFore3.Location = new System.Drawing.Point(36, 137);
		this.trkTintOFore3.Maximum = 1000;
		this.trkTintOFore3.Name = "trkTintOFore3";
		this.trkTintOFore3.Size = new System.Drawing.Size(104, 45);
		this.trkTintOFore3.TabIndex = 14;
		this.trkTintOFore3.TickFrequency = 100;
		this.trkTintOFore3.Scroll += new System.EventHandler(trkTintOFore3_Scroll);
		this.txtTintOFore3.Location = new System.Drawing.Point(147, 137);
		this.txtTintOFore3.Name = "txtTintOFore3";
		this.txtTintOFore3.Size = new System.Drawing.Size(56, 20);
		this.txtTintOFore3.TabIndex = 15;
		this.txtTintOFore3.TextChanged += new System.EventHandler(txtTintOFore3_TextChanged);
		this.label50.AutoSize = true;
		this.label50.Location = new System.Drawing.Point(12, 137);
		this.label50.Name = "label50";
		this.label50.Size = new System.Drawing.Size(28, 13);
		this.label50.TabIndex = 13;
		this.label50.Text = "Tint:";
		this.trkSatOFore3.Location = new System.Drawing.Point(36, 111);
		this.trkSatOFore3.Maximum = 1000;
		this.trkSatOFore3.Name = "trkSatOFore3";
		this.trkSatOFore3.Size = new System.Drawing.Size(104, 45);
		this.trkSatOFore3.TabIndex = 11;
		this.trkSatOFore3.TickFrequency = 100;
		this.trkSatOFore3.Scroll += new System.EventHandler(trkSatOFore3_Scroll);
		this.txtSatOFore3.Location = new System.Drawing.Point(147, 111);
		this.txtSatOFore3.Name = "txtSatOFore3";
		this.txtSatOFore3.Size = new System.Drawing.Size(56, 20);
		this.txtSatOFore3.TabIndex = 12;
		this.txtSatOFore3.TextChanged += new System.EventHandler(txtSatOFore3_TextChanged);
		this.label51.AutoSize = true;
		this.label51.Location = new System.Drawing.Point(12, 111);
		this.label51.Name = "label51";
		this.label51.Size = new System.Drawing.Size(26, 13);
		this.label51.TabIndex = 10;
		this.label51.Text = "Sat:";
		this.trkBOFore3.Location = new System.Drawing.Point(36, 85);
		this.trkBOFore3.Maximum = 1000;
		this.trkBOFore3.Name = "trkBOFore3";
		this.trkBOFore3.Size = new System.Drawing.Size(85, 45);
		this.trkBOFore3.TabIndex = 8;
		this.trkBOFore3.TickFrequency = 100;
		this.trkBOFore3.Scroll += new System.EventHandler(trkBOFore3_Scroll);
		this.txtBOFore3.Location = new System.Drawing.Point(127, 85);
		this.txtBOFore3.Name = "txtBOFore3";
		this.txtBOFore3.Size = new System.Drawing.Size(35, 20);
		this.txtBOFore3.TabIndex = 9;
		this.txtBOFore3.TextChanged += new System.EventHandler(txtBOFore3_TextChanged);
		this.label52.AutoSize = true;
		this.label52.Location = new System.Drawing.Point(12, 85);
		this.label52.Name = "label52";
		this.label52.Size = new System.Drawing.Size(17, 13);
		this.label52.TabIndex = 7;
		this.label52.Text = "B:";
		this.trkGOFore3.Location = new System.Drawing.Point(36, 60);
		this.trkGOFore3.Maximum = 1000;
		this.trkGOFore3.Name = "trkGOFore3";
		this.trkGOFore3.Size = new System.Drawing.Size(85, 45);
		this.trkGOFore3.TabIndex = 5;
		this.trkGOFore3.TickFrequency = 100;
		this.trkGOFore3.Scroll += new System.EventHandler(trkGOFore3_Scroll);
		this.txtGOFore3.Location = new System.Drawing.Point(127, 60);
		this.txtGOFore3.Name = "txtGOFore3";
		this.txtGOFore3.Size = new System.Drawing.Size(35, 20);
		this.txtGOFore3.TabIndex = 6;
		this.txtGOFore3.TextChanged += new System.EventHandler(txtGOFore3_TextChanged);
		this.label53.AutoSize = true;
		this.label53.Location = new System.Drawing.Point(12, 60);
		this.label53.Name = "label53";
		this.label53.Size = new System.Drawing.Size(18, 13);
		this.label53.TabIndex = 4;
		this.label53.Text = "G:";
		this.trkROFore3.Location = new System.Drawing.Point(36, 34);
		this.trkROFore3.Maximum = 1000;
		this.trkROFore3.Name = "trkROFore3";
		this.trkROFore3.Size = new System.Drawing.Size(85, 45);
		this.trkROFore3.TabIndex = 2;
		this.trkROFore3.TickFrequency = 100;
		this.trkROFore3.Scroll += new System.EventHandler(trkROFore3_Scroll);
		this.txtROFore3.Location = new System.Drawing.Point(127, 34);
		this.txtROFore3.Name = "txtROFore3";
		this.txtROFore3.Size = new System.Drawing.Size(35, 20);
		this.txtROFore3.TabIndex = 3;
		this.txtROFore3.TextChanged += new System.EventHandler(txtROFore3_TextChanged);
		this.label54.AutoSize = true;
		this.label54.Location = new System.Drawing.Point(12, 34);
		this.label54.Name = "label54";
		this.label54.Size = new System.Drawing.Size(18, 13);
		this.label54.TabIndex = 1;
		this.label54.Text = "R:";
		this.panel10.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel10.Controls.Add(this.txtBBOFore4);
		this.panel10.Controls.Add(this.txtBGOFore4);
		this.panel10.Controls.Add(this.txtBROFore4);
		this.panel10.Controls.Add(this.trkGammaOFore4);
		this.panel10.Controls.Add(this.txtGammaOFore4);
		this.panel10.Controls.Add(this.label195);
		this.panel10.Controls.Add(this.trkBriteOFore4);
		this.panel10.Controls.Add(this.txtBriteOFore4);
		this.panel10.Controls.Add(this.label196);
		this.panel10.Controls.Add(this.label55);
		this.panel10.Controls.Add(this.trkTintOFore4);
		this.panel10.Controls.Add(this.txtTintOFore4);
		this.panel10.Controls.Add(this.label56);
		this.panel10.Controls.Add(this.trkSatOFore4);
		this.panel10.Controls.Add(this.txtSatOFore4);
		this.panel10.Controls.Add(this.label57);
		this.panel10.Controls.Add(this.trkBOFore4);
		this.panel10.Controls.Add(this.txtBOFore4);
		this.panel10.Controls.Add(this.label58);
		this.panel10.Controls.Add(this.trkGOFore4);
		this.panel10.Controls.Add(this.txtGOFore4);
		this.panel10.Controls.Add(this.label59);
		this.panel10.Controls.Add(this.trkROFore4);
		this.panel10.Controls.Add(this.txtROFore4);
		this.panel10.Controls.Add(this.label60);
		this.panel10.Location = new System.Drawing.Point(444, 460);
		this.panel10.Name = "panel10";
		this.panel10.Size = new System.Drawing.Size(213, 220);
		this.panel10.TabIndex = 24;
		this.trkGammaOFore4.Location = new System.Drawing.Point(36, 189);
		this.trkGammaOFore4.Maximum = 1000;
		this.trkGammaOFore4.Minimum = -1000;
		this.trkGammaOFore4.Name = "trkGammaOFore4";
		this.trkGammaOFore4.Size = new System.Drawing.Size(104, 45);
		this.trkGammaOFore4.TabIndex = 27;
		this.trkGammaOFore4.TickFrequency = 200;
		this.trkGammaOFore4.Scroll += new System.EventHandler(trkGammaOFore4_Scroll);
		this.txtGammaOFore4.Location = new System.Drawing.Point(147, 189);
		this.txtGammaOFore4.Name = "txtGammaOFore4";
		this.txtGammaOFore4.Size = new System.Drawing.Size(56, 20);
		this.txtGammaOFore4.TabIndex = 28;
		this.txtGammaOFore4.TextChanged += new System.EventHandler(txtGammaOFore4_TextChanged);
		this.label195.AutoSize = true;
		this.label195.Location = new System.Drawing.Point(12, 189);
		this.label195.Name = "label195";
		this.label195.Size = new System.Drawing.Size(26, 13);
		this.label195.TabIndex = 26;
		this.label195.Text = "Gm:";
		this.trkBriteOFore4.Location = new System.Drawing.Point(36, 163);
		this.trkBriteOFore4.Maximum = 1000;
		this.trkBriteOFore4.Name = "trkBriteOFore4";
		this.trkBriteOFore4.Size = new System.Drawing.Size(104, 45);
		this.trkBriteOFore4.TabIndex = 24;
		this.trkBriteOFore4.TickFrequency = 100;
		this.trkBriteOFore4.Scroll += new System.EventHandler(trkBriteOFore4_Scroll);
		this.txtBriteOFore4.Location = new System.Drawing.Point(147, 163);
		this.txtBriteOFore4.Name = "txtBriteOFore4";
		this.txtBriteOFore4.Size = new System.Drawing.Size(56, 20);
		this.txtBriteOFore4.TabIndex = 25;
		this.txtBriteOFore4.TextChanged += new System.EventHandler(txtBriteOFore4_TextChanged);
		this.label196.AutoSize = true;
		this.label196.Location = new System.Drawing.Point(12, 163);
		this.label196.Name = "label196";
		this.label196.Size = new System.Drawing.Size(25, 13);
		this.label196.TabIndex = 23;
		this.label196.Text = "Brit:";
		this.label55.AutoSize = true;
		this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label55.Location = new System.Drawing.Point(12, 13);
		this.label55.Name = "label55";
		this.label55.Size = new System.Drawing.Size(56, 13);
		this.label55.TabIndex = 16;
		this.label55.Text = "O Fore 4";
		this.trkTintOFore4.Location = new System.Drawing.Point(36, 137);
		this.trkTintOFore4.Maximum = 1000;
		this.trkTintOFore4.Name = "trkTintOFore4";
		this.trkTintOFore4.Size = new System.Drawing.Size(104, 45);
		this.trkTintOFore4.TabIndex = 14;
		this.trkTintOFore4.TickFrequency = 100;
		this.trkTintOFore4.Scroll += new System.EventHandler(trkTintOFore4_Scroll);
		this.txtTintOFore4.Location = new System.Drawing.Point(147, 137);
		this.txtTintOFore4.Name = "txtTintOFore4";
		this.txtTintOFore4.Size = new System.Drawing.Size(56, 20);
		this.txtTintOFore4.TabIndex = 15;
		this.txtTintOFore4.TextChanged += new System.EventHandler(txtTintOFore4_TextChanged);
		this.label56.AutoSize = true;
		this.label56.Location = new System.Drawing.Point(12, 137);
		this.label56.Name = "label56";
		this.label56.Size = new System.Drawing.Size(28, 13);
		this.label56.TabIndex = 13;
		this.label56.Text = "Tint:";
		this.trkSatOFore4.Location = new System.Drawing.Point(36, 111);
		this.trkSatOFore4.Maximum = 1000;
		this.trkSatOFore4.Name = "trkSatOFore4";
		this.trkSatOFore4.Size = new System.Drawing.Size(104, 45);
		this.trkSatOFore4.TabIndex = 11;
		this.trkSatOFore4.TickFrequency = 100;
		this.trkSatOFore4.Scroll += new System.EventHandler(trkSatOFore4_Scroll);
		this.txtSatOFore4.Location = new System.Drawing.Point(147, 111);
		this.txtSatOFore4.Name = "txtSatOFore4";
		this.txtSatOFore4.Size = new System.Drawing.Size(56, 20);
		this.txtSatOFore4.TabIndex = 12;
		this.txtSatOFore4.TextChanged += new System.EventHandler(txtSatOFore4_TextChanged);
		this.label57.AutoSize = true;
		this.label57.Location = new System.Drawing.Point(12, 111);
		this.label57.Name = "label57";
		this.label57.Size = new System.Drawing.Size(26, 13);
		this.label57.TabIndex = 10;
		this.label57.Text = "Sat:";
		this.trkBOFore4.Location = new System.Drawing.Point(36, 85);
		this.trkBOFore4.Maximum = 1000;
		this.trkBOFore4.Name = "trkBOFore4";
		this.trkBOFore4.Size = new System.Drawing.Size(85, 45);
		this.trkBOFore4.TabIndex = 8;
		this.trkBOFore4.TickFrequency = 100;
		this.trkBOFore4.Scroll += new System.EventHandler(trkBOFore4_Scroll);
		this.txtBOFore4.Location = new System.Drawing.Point(127, 85);
		this.txtBOFore4.Name = "txtBOFore4";
		this.txtBOFore4.Size = new System.Drawing.Size(35, 20);
		this.txtBOFore4.TabIndex = 9;
		this.txtBOFore4.TextChanged += new System.EventHandler(txtBOFore4_TextChanged);
		this.label58.AutoSize = true;
		this.label58.Location = new System.Drawing.Point(12, 85);
		this.label58.Name = "label58";
		this.label58.Size = new System.Drawing.Size(17, 13);
		this.label58.TabIndex = 7;
		this.label58.Text = "B:";
		this.trkGOFore4.Location = new System.Drawing.Point(36, 60);
		this.trkGOFore4.Maximum = 1000;
		this.trkGOFore4.Name = "trkGOFore4";
		this.trkGOFore4.Size = new System.Drawing.Size(85, 45);
		this.trkGOFore4.TabIndex = 5;
		this.trkGOFore4.TickFrequency = 100;
		this.trkGOFore4.Scroll += new System.EventHandler(trkGOFore4_Scroll);
		this.txtGOFore4.Location = new System.Drawing.Point(127, 60);
		this.txtGOFore4.Name = "txtGOFore4";
		this.txtGOFore4.Size = new System.Drawing.Size(35, 20);
		this.txtGOFore4.TabIndex = 6;
		this.txtGOFore4.TextChanged += new System.EventHandler(txtGOFore4_TextChanged);
		this.label59.AutoSize = true;
		this.label59.Location = new System.Drawing.Point(12, 60);
		this.label59.Name = "label59";
		this.label59.Size = new System.Drawing.Size(18, 13);
		this.label59.TabIndex = 4;
		this.label59.Text = "G:";
		this.trkROFore4.Location = new System.Drawing.Point(36, 34);
		this.trkROFore4.Maximum = 1000;
		this.trkROFore4.Name = "trkROFore4";
		this.trkROFore4.Size = new System.Drawing.Size(85, 45);
		this.trkROFore4.TabIndex = 2;
		this.trkROFore4.TickFrequency = 100;
		this.trkROFore4.Scroll += new System.EventHandler(trkROFore4_Scroll);
		this.txtROFore4.Location = new System.Drawing.Point(127, 34);
		this.txtROFore4.Name = "txtROFore4";
		this.txtROFore4.Size = new System.Drawing.Size(35, 20);
		this.txtROFore4.TabIndex = 3;
		this.txtROFore4.TextChanged += new System.EventHandler(txtROFore4_TextChanged);
		this.label60.AutoSize = true;
		this.label60.Location = new System.Drawing.Point(12, 34);
		this.label60.Name = "label60";
		this.label60.Size = new System.Drawing.Size(18, 13);
		this.label60.TabIndex = 1;
		this.label60.Text = "R:";
		this.panel11.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel11.Controls.Add(this.txtBBOFore5);
		this.panel11.Controls.Add(this.txtBGOFore5);
		this.panel11.Controls.Add(this.txtBROFore5);
		this.panel11.Controls.Add(this.trkGammaOFore5);
		this.panel11.Controls.Add(this.txtGammaOFore5);
		this.panel11.Controls.Add(this.label197);
		this.panel11.Controls.Add(this.trkBriteOFore5);
		this.panel11.Controls.Add(this.txtBriteOFore5);
		this.panel11.Controls.Add(this.label198);
		this.panel11.Controls.Add(this.label61);
		this.panel11.Controls.Add(this.trkTintOFore5);
		this.panel11.Controls.Add(this.txtTintOFore5);
		this.panel11.Controls.Add(this.label62);
		this.panel11.Controls.Add(this.trkSatOFore5);
		this.panel11.Controls.Add(this.txtSatOFore5);
		this.panel11.Controls.Add(this.label63);
		this.panel11.Controls.Add(this.trkBOFore5);
		this.panel11.Controls.Add(this.txtBOFore5);
		this.panel11.Controls.Add(this.label64);
		this.panel11.Controls.Add(this.trkGOFore5);
		this.panel11.Controls.Add(this.txtGOFore5);
		this.panel11.Controls.Add(this.label65);
		this.panel11.Controls.Add(this.trkROFore5);
		this.panel11.Controls.Add(this.txtROFore5);
		this.panel11.Controls.Add(this.label66);
		this.panel11.Location = new System.Drawing.Point(663, 460);
		this.panel11.Name = "panel11";
		this.panel11.Size = new System.Drawing.Size(213, 220);
		this.panel11.TabIndex = 25;
		this.trkGammaOFore5.Location = new System.Drawing.Point(36, 189);
		this.trkGammaOFore5.Maximum = 1000;
		this.trkGammaOFore5.Minimum = -1000;
		this.trkGammaOFore5.Name = "trkGammaOFore5";
		this.trkGammaOFore5.Size = new System.Drawing.Size(104, 45);
		this.trkGammaOFore5.TabIndex = 27;
		this.trkGammaOFore5.TickFrequency = 200;
		this.trkGammaOFore5.Scroll += new System.EventHandler(trkGammaOFore5_Scroll);
		this.txtGammaOFore5.Location = new System.Drawing.Point(147, 189);
		this.txtGammaOFore5.Name = "txtGammaOFore5";
		this.txtGammaOFore5.Size = new System.Drawing.Size(56, 20);
		this.txtGammaOFore5.TabIndex = 28;
		this.txtGammaOFore5.TextChanged += new System.EventHandler(txtGammaOFore5_TextChanged);
		this.label197.AutoSize = true;
		this.label197.Location = new System.Drawing.Point(12, 189);
		this.label197.Name = "label197";
		this.label197.Size = new System.Drawing.Size(26, 13);
		this.label197.TabIndex = 26;
		this.label197.Text = "Gm:";
		this.trkBriteOFore5.Location = new System.Drawing.Point(36, 163);
		this.trkBriteOFore5.Maximum = 1000;
		this.trkBriteOFore5.Name = "trkBriteOFore5";
		this.trkBriteOFore5.Size = new System.Drawing.Size(104, 45);
		this.trkBriteOFore5.TabIndex = 24;
		this.trkBriteOFore5.TickFrequency = 100;
		this.trkBriteOFore5.Scroll += new System.EventHandler(trkBriteOFore5_Scroll);
		this.txtBriteOFore5.Location = new System.Drawing.Point(147, 163);
		this.txtBriteOFore5.Name = "txtBriteOFore5";
		this.txtBriteOFore5.Size = new System.Drawing.Size(56, 20);
		this.txtBriteOFore5.TabIndex = 25;
		this.txtBriteOFore5.TextChanged += new System.EventHandler(txtBriteOFore5_TextChanged);
		this.label198.AutoSize = true;
		this.label198.Location = new System.Drawing.Point(12, 163);
		this.label198.Name = "label198";
		this.label198.Size = new System.Drawing.Size(25, 13);
		this.label198.TabIndex = 23;
		this.label198.Text = "Brit:";
		this.label61.AutoSize = true;
		this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label61.Location = new System.Drawing.Point(12, 13);
		this.label61.Name = "label61";
		this.label61.Size = new System.Drawing.Size(56, 13);
		this.label61.TabIndex = 16;
		this.label61.Text = "O Fore 5";
		this.trkTintOFore5.Location = new System.Drawing.Point(36, 137);
		this.trkTintOFore5.Maximum = 1000;
		this.trkTintOFore5.Name = "trkTintOFore5";
		this.trkTintOFore5.Size = new System.Drawing.Size(104, 45);
		this.trkTintOFore5.TabIndex = 14;
		this.trkTintOFore5.TickFrequency = 100;
		this.trkTintOFore5.Scroll += new System.EventHandler(trkTintOFore5_Scroll);
		this.txtTintOFore5.Location = new System.Drawing.Point(147, 137);
		this.txtTintOFore5.Name = "txtTintOFore5";
		this.txtTintOFore5.Size = new System.Drawing.Size(56, 20);
		this.txtTintOFore5.TabIndex = 15;
		this.txtTintOFore5.TextChanged += new System.EventHandler(txtTintOFore5_TextChanged);
		this.label62.AutoSize = true;
		this.label62.Location = new System.Drawing.Point(12, 137);
		this.label62.Name = "label62";
		this.label62.Size = new System.Drawing.Size(28, 13);
		this.label62.TabIndex = 13;
		this.label62.Text = "Tint:";
		this.trkSatOFore5.Location = new System.Drawing.Point(36, 111);
		this.trkSatOFore5.Maximum = 1000;
		this.trkSatOFore5.Name = "trkSatOFore5";
		this.trkSatOFore5.Size = new System.Drawing.Size(104, 45);
		this.trkSatOFore5.TabIndex = 11;
		this.trkSatOFore5.TickFrequency = 100;
		this.trkSatOFore5.Scroll += new System.EventHandler(trkSatOFore5_Scroll);
		this.txtSatOFore5.Location = new System.Drawing.Point(147, 111);
		this.txtSatOFore5.Name = "txtSatOFore5";
		this.txtSatOFore5.Size = new System.Drawing.Size(56, 20);
		this.txtSatOFore5.TabIndex = 12;
		this.txtSatOFore5.TextChanged += new System.EventHandler(txtSatOFore5_TextChanged);
		this.label63.AutoSize = true;
		this.label63.Location = new System.Drawing.Point(12, 111);
		this.label63.Name = "label63";
		this.label63.Size = new System.Drawing.Size(26, 13);
		this.label63.TabIndex = 10;
		this.label63.Text = "Sat:";
		this.trkBOFore5.Location = new System.Drawing.Point(36, 85);
		this.trkBOFore5.Maximum = 1000;
		this.trkBOFore5.Name = "trkBOFore5";
		this.trkBOFore5.Size = new System.Drawing.Size(85, 45);
		this.trkBOFore5.TabIndex = 8;
		this.trkBOFore5.TickFrequency = 100;
		this.trkBOFore5.Scroll += new System.EventHandler(trkBOFore5_Scroll);
		this.txtBOFore5.Location = new System.Drawing.Point(127, 85);
		this.txtBOFore5.Name = "txtBOFore5";
		this.txtBOFore5.Size = new System.Drawing.Size(35, 20);
		this.txtBOFore5.TabIndex = 9;
		this.txtBOFore5.TextChanged += new System.EventHandler(txtBOFore5_TextChanged);
		this.label64.AutoSize = true;
		this.label64.Location = new System.Drawing.Point(12, 85);
		this.label64.Name = "label64";
		this.label64.Size = new System.Drawing.Size(17, 13);
		this.label64.TabIndex = 7;
		this.label64.Text = "B:";
		this.trkGOFore5.Location = new System.Drawing.Point(36, 60);
		this.trkGOFore5.Maximum = 1000;
		this.trkGOFore5.Name = "trkGOFore5";
		this.trkGOFore5.Size = new System.Drawing.Size(85, 45);
		this.trkGOFore5.TabIndex = 5;
		this.trkGOFore5.TickFrequency = 100;
		this.trkGOFore5.Scroll += new System.EventHandler(trkGOFore5_Scroll);
		this.txtGOFore5.Location = new System.Drawing.Point(127, 60);
		this.txtGOFore5.Name = "txtGOFore5";
		this.txtGOFore5.Size = new System.Drawing.Size(35, 20);
		this.txtGOFore5.TabIndex = 6;
		this.txtGOFore5.TextChanged += new System.EventHandler(txtGOFore5_TextChanged);
		this.label65.AutoSize = true;
		this.label65.Location = new System.Drawing.Point(12, 60);
		this.label65.Name = "label65";
		this.label65.Size = new System.Drawing.Size(18, 13);
		this.label65.TabIndex = 4;
		this.label65.Text = "G:";
		this.trkROFore5.Location = new System.Drawing.Point(36, 34);
		this.trkROFore5.Maximum = 1000;
		this.trkROFore5.Name = "trkROFore5";
		this.trkROFore5.Size = new System.Drawing.Size(85, 45);
		this.trkROFore5.TabIndex = 2;
		this.trkROFore5.TickFrequency = 100;
		this.trkROFore5.Scroll += new System.EventHandler(trkROFore5_Scroll);
		this.txtROFore5.Location = new System.Drawing.Point(127, 34);
		this.txtROFore5.Name = "txtROFore5";
		this.txtROFore5.Size = new System.Drawing.Size(35, 20);
		this.txtROFore5.TabIndex = 3;
		this.txtROFore5.TextChanged += new System.EventHandler(txtROFore5_TextChanged);
		this.label66.AutoSize = true;
		this.label66.Location = new System.Drawing.Point(12, 34);
		this.label66.Name = "label66";
		this.label66.Size = new System.Drawing.Size(18, 13);
		this.label66.TabIndex = 1;
		this.label66.Text = "R:";
		this.panel12.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel12.Controls.Add(this.txtBBIFore3);
		this.panel12.Controls.Add(this.txtBGIFore3);
		this.panel12.Controls.Add(this.txtBRIFore3);
		this.panel12.Controls.Add(this.trkGammaIFore3);
		this.panel12.Controls.Add(this.txtGammaIFore3);
		this.panel12.Controls.Add(this.label175);
		this.panel12.Controls.Add(this.trkBriteIFore3);
		this.panel12.Controls.Add(this.txtBriteIFore3);
		this.panel12.Controls.Add(this.label176);
		this.panel12.Controls.Add(this.label67);
		this.panel12.Controls.Add(this.trkTintIFore3);
		this.panel12.Controls.Add(this.txtTintIFore3);
		this.panel12.Controls.Add(this.label68);
		this.panel12.Controls.Add(this.trkSatIFore3);
		this.panel12.Controls.Add(this.txtSatIFore3);
		this.panel12.Controls.Add(this.label69);
		this.panel12.Controls.Add(this.trkBIFore3);
		this.panel12.Controls.Add(this.txtBIFore3);
		this.panel12.Controls.Add(this.label70);
		this.panel12.Controls.Add(this.trkGIFore3);
		this.panel12.Controls.Add(this.txtGIFore3);
		this.panel12.Controls.Add(this.label71);
		this.panel12.Controls.Add(this.trkRIFore3);
		this.panel12.Controls.Add(this.txtRIFore3);
		this.panel12.Controls.Add(this.label72);
		this.panel12.Location = new System.Drawing.Point(663, 234);
		this.panel12.Name = "panel12";
		this.panel12.Size = new System.Drawing.Size(213, 220);
		this.panel12.TabIndex = 31;
		this.trkGammaIFore3.Location = new System.Drawing.Point(35, 189);
		this.trkGammaIFore3.Maximum = 1000;
		this.trkGammaIFore3.Minimum = -1000;
		this.trkGammaIFore3.Name = "trkGammaIFore3";
		this.trkGammaIFore3.Size = new System.Drawing.Size(104, 45);
		this.trkGammaIFore3.TabIndex = 27;
		this.trkGammaIFore3.TickFrequency = 200;
		this.trkGammaIFore3.Scroll += new System.EventHandler(trkGammaIFore3_Scroll);
		this.txtGammaIFore3.Location = new System.Drawing.Point(146, 189);
		this.txtGammaIFore3.Name = "txtGammaIFore3";
		this.txtGammaIFore3.Size = new System.Drawing.Size(56, 20);
		this.txtGammaIFore3.TabIndex = 28;
		this.txtGammaIFore3.TextChanged += new System.EventHandler(txtGammaIFore3_TextChanged);
		this.label175.AutoSize = true;
		this.label175.Location = new System.Drawing.Point(11, 189);
		this.label175.Name = "label175";
		this.label175.Size = new System.Drawing.Size(26, 13);
		this.label175.TabIndex = 26;
		this.label175.Text = "Gm:";
		this.trkBriteIFore3.Location = new System.Drawing.Point(35, 163);
		this.trkBriteIFore3.Maximum = 1000;
		this.trkBriteIFore3.Name = "trkBriteIFore3";
		this.trkBriteIFore3.Size = new System.Drawing.Size(104, 45);
		this.trkBriteIFore3.TabIndex = 24;
		this.trkBriteIFore3.TickFrequency = 100;
		this.trkBriteIFore3.Scroll += new System.EventHandler(trkBriteIFore3_Scroll);
		this.txtBriteIFore3.Location = new System.Drawing.Point(146, 163);
		this.txtBriteIFore3.Name = "txtBriteIFore3";
		this.txtBriteIFore3.Size = new System.Drawing.Size(56, 20);
		this.txtBriteIFore3.TabIndex = 25;
		this.txtBriteIFore3.TextChanged += new System.EventHandler(txtBriteIFore3_TextChanged);
		this.label176.AutoSize = true;
		this.label176.Location = new System.Drawing.Point(11, 163);
		this.label176.Name = "label176";
		this.label176.Size = new System.Drawing.Size(25, 13);
		this.label176.TabIndex = 23;
		this.label176.Text = "Brit:";
		this.label67.AutoSize = true;
		this.label67.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label67.Location = new System.Drawing.Point(12, 13);
		this.label67.Name = "label67";
		this.label67.Size = new System.Drawing.Size(51, 13);
		this.label67.TabIndex = 16;
		this.label67.Text = "I Fore 3";
		this.trkTintIFore3.Location = new System.Drawing.Point(35, 137);
		this.trkTintIFore3.Maximum = 1000;
		this.trkTintIFore3.Name = "trkTintIFore3";
		this.trkTintIFore3.Size = new System.Drawing.Size(104, 45);
		this.trkTintIFore3.TabIndex = 14;
		this.trkTintIFore3.TickFrequency = 100;
		this.trkTintIFore3.Scroll += new System.EventHandler(trkTintIFore3_Scroll);
		this.txtTintIFore3.Location = new System.Drawing.Point(146, 137);
		this.txtTintIFore3.Name = "txtTintIFore3";
		this.txtTintIFore3.Size = new System.Drawing.Size(56, 20);
		this.txtTintIFore3.TabIndex = 15;
		this.txtTintIFore3.TextChanged += new System.EventHandler(txtTintIFore3_TextChanged);
		this.label68.AutoSize = true;
		this.label68.Location = new System.Drawing.Point(11, 137);
		this.label68.Name = "label68";
		this.label68.Size = new System.Drawing.Size(28, 13);
		this.label68.TabIndex = 13;
		this.label68.Text = "Tint:";
		this.trkSatIFore3.Location = new System.Drawing.Point(35, 111);
		this.trkSatIFore3.Maximum = 1000;
		this.trkSatIFore3.Name = "trkSatIFore3";
		this.trkSatIFore3.Size = new System.Drawing.Size(104, 45);
		this.trkSatIFore3.TabIndex = 11;
		this.trkSatIFore3.TickFrequency = 100;
		this.trkSatIFore3.Scroll += new System.EventHandler(trkSatIFore3_Scroll);
		this.txtSatIFore3.Location = new System.Drawing.Point(146, 111);
		this.txtSatIFore3.Name = "txtSatIFore3";
		this.txtSatIFore3.Size = new System.Drawing.Size(56, 20);
		this.txtSatIFore3.TabIndex = 12;
		this.txtSatIFore3.TextChanged += new System.EventHandler(txtSatIFore3_TextChanged);
		this.label69.AutoSize = true;
		this.label69.Location = new System.Drawing.Point(12, 111);
		this.label69.Name = "label69";
		this.label69.Size = new System.Drawing.Size(26, 13);
		this.label69.TabIndex = 10;
		this.label69.Text = "Sat:";
		this.trkBIFore3.Location = new System.Drawing.Point(36, 85);
		this.trkBIFore3.Maximum = 1000;
		this.trkBIFore3.Name = "trkBIFore3";
		this.trkBIFore3.Size = new System.Drawing.Size(85, 45);
		this.trkBIFore3.TabIndex = 8;
		this.trkBIFore3.TickFrequency = 100;
		this.trkBIFore3.Scroll += new System.EventHandler(trkBIFore3_Scroll);
		this.txtBIFore3.Location = new System.Drawing.Point(126, 85);
		this.txtBIFore3.Name = "txtBIFore3";
		this.txtBIFore3.Size = new System.Drawing.Size(35, 20);
		this.txtBIFore3.TabIndex = 9;
		this.txtBIFore3.TextChanged += new System.EventHandler(txtBIFore3_TextChanged);
		this.label70.AutoSize = true;
		this.label70.Location = new System.Drawing.Point(12, 85);
		this.label70.Name = "label70";
		this.label70.Size = new System.Drawing.Size(17, 13);
		this.label70.TabIndex = 7;
		this.label70.Text = "B:";
		this.trkGIFore3.Location = new System.Drawing.Point(36, 60);
		this.trkGIFore3.Maximum = 1000;
		this.trkGIFore3.Name = "trkGIFore3";
		this.trkGIFore3.Size = new System.Drawing.Size(85, 45);
		this.trkGIFore3.TabIndex = 5;
		this.trkGIFore3.TickFrequency = 100;
		this.trkGIFore3.Scroll += new System.EventHandler(trkGIFore3_Scroll);
		this.txtGIFore3.Location = new System.Drawing.Point(126, 60);
		this.txtGIFore3.Name = "txtGIFore3";
		this.txtGIFore3.Size = new System.Drawing.Size(35, 20);
		this.txtGIFore3.TabIndex = 6;
		this.txtGIFore3.TextChanged += new System.EventHandler(txtGIFore3_TextChanged);
		this.label71.AutoSize = true;
		this.label71.Location = new System.Drawing.Point(12, 60);
		this.label71.Name = "label71";
		this.label71.Size = new System.Drawing.Size(18, 13);
		this.label71.TabIndex = 4;
		this.label71.Text = "G:";
		this.trkRIFore3.Location = new System.Drawing.Point(36, 34);
		this.trkRIFore3.Maximum = 1000;
		this.trkRIFore3.Name = "trkRIFore3";
		this.trkRIFore3.Size = new System.Drawing.Size(85, 45);
		this.trkRIFore3.TabIndex = 2;
		this.trkRIFore3.TickFrequency = 100;
		this.trkRIFore3.Scroll += new System.EventHandler(trkRIFore3_Scroll);
		this.txtRIFore3.Location = new System.Drawing.Point(126, 34);
		this.txtRIFore3.Name = "txtRIFore3";
		this.txtRIFore3.Size = new System.Drawing.Size(35, 20);
		this.txtRIFore3.TabIndex = 3;
		this.txtRIFore3.TextChanged += new System.EventHandler(txtRIFore3_TextChanged);
		this.label72.AutoSize = true;
		this.label72.Location = new System.Drawing.Point(12, 34);
		this.label72.Name = "label72";
		this.label72.Size = new System.Drawing.Size(18, 13);
		this.label72.TabIndex = 1;
		this.label72.Text = "R:";
		this.panel13.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel13.Controls.Add(this.txtBBIFore2);
		this.panel13.Controls.Add(this.txtBGIFore2);
		this.panel13.Controls.Add(this.txtBRIFore2);
		this.panel13.Controls.Add(this.trkGammaIFore2);
		this.panel13.Controls.Add(this.txtGammaIFore2);
		this.panel13.Controls.Add(this.label173);
		this.panel13.Controls.Add(this.trkBriteIFore2);
		this.panel13.Controls.Add(this.txtBriteIFore2);
		this.panel13.Controls.Add(this.label174);
		this.panel13.Controls.Add(this.label73);
		this.panel13.Controls.Add(this.trkTintIFore2);
		this.panel13.Controls.Add(this.txtTintIFore2);
		this.panel13.Controls.Add(this.label74);
		this.panel13.Controls.Add(this.trkSatIFore2);
		this.panel13.Controls.Add(this.txtSatIFore2);
		this.panel13.Controls.Add(this.label75);
		this.panel13.Controls.Add(this.trkBIFore2);
		this.panel13.Controls.Add(this.txtBIFore2);
		this.panel13.Controls.Add(this.label76);
		this.panel13.Controls.Add(this.trkGIFore2);
		this.panel13.Controls.Add(this.txtGIFore2);
		this.panel13.Controls.Add(this.label77);
		this.panel13.Controls.Add(this.trkRIFore2);
		this.panel13.Controls.Add(this.txtRIFore2);
		this.panel13.Controls.Add(this.label78);
		this.panel13.Location = new System.Drawing.Point(444, 234);
		this.panel13.Name = "panel13";
		this.panel13.Size = new System.Drawing.Size(213, 220);
		this.panel13.TabIndex = 30;
		this.trkGammaIFore2.Location = new System.Drawing.Point(36, 189);
		this.trkGammaIFore2.Maximum = 1000;
		this.trkGammaIFore2.Minimum = -1000;
		this.trkGammaIFore2.Name = "trkGammaIFore2";
		this.trkGammaIFore2.Size = new System.Drawing.Size(104, 45);
		this.trkGammaIFore2.TabIndex = 27;
		this.trkGammaIFore2.TickFrequency = 200;
		this.trkGammaIFore2.Scroll += new System.EventHandler(trkGammaIFore2_Scroll);
		this.txtGammaIFore2.Location = new System.Drawing.Point(147, 189);
		this.txtGammaIFore2.Name = "txtGammaIFore2";
		this.txtGammaIFore2.Size = new System.Drawing.Size(56, 20);
		this.txtGammaIFore2.TabIndex = 28;
		this.txtGammaIFore2.TextChanged += new System.EventHandler(txtGammaIFore2_TextChanged);
		this.label173.AutoSize = true;
		this.label173.Location = new System.Drawing.Point(12, 189);
		this.label173.Name = "label173";
		this.label173.Size = new System.Drawing.Size(26, 13);
		this.label173.TabIndex = 26;
		this.label173.Text = "Gm:";
		this.trkBriteIFore2.Location = new System.Drawing.Point(36, 163);
		this.trkBriteIFore2.Maximum = 1000;
		this.trkBriteIFore2.Name = "trkBriteIFore2";
		this.trkBriteIFore2.Size = new System.Drawing.Size(104, 45);
		this.trkBriteIFore2.TabIndex = 24;
		this.trkBriteIFore2.TickFrequency = 100;
		this.trkBriteIFore2.Scroll += new System.EventHandler(trkBriteIFore2_Scroll);
		this.txtBriteIFore2.Location = new System.Drawing.Point(147, 163);
		this.txtBriteIFore2.Name = "txtBriteIFore2";
		this.txtBriteIFore2.Size = new System.Drawing.Size(56, 20);
		this.txtBriteIFore2.TabIndex = 25;
		this.txtBriteIFore2.TextChanged += new System.EventHandler(txtBriteIFore2_TextChanged);
		this.label174.AutoSize = true;
		this.label174.Location = new System.Drawing.Point(12, 163);
		this.label174.Name = "label174";
		this.label174.Size = new System.Drawing.Size(25, 13);
		this.label174.TabIndex = 23;
		this.label174.Text = "Brit:";
		this.label73.AutoSize = true;
		this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label73.Location = new System.Drawing.Point(12, 13);
		this.label73.Name = "label73";
		this.label73.Size = new System.Drawing.Size(51, 13);
		this.label73.TabIndex = 16;
		this.label73.Text = "I Fore 2";
		this.trkTintIFore2.Location = new System.Drawing.Point(36, 137);
		this.trkTintIFore2.Maximum = 1000;
		this.trkTintIFore2.Name = "trkTintIFore2";
		this.trkTintIFore2.Size = new System.Drawing.Size(104, 45);
		this.trkTintIFore2.TabIndex = 14;
		this.trkTintIFore2.TickFrequency = 100;
		this.trkTintIFore2.Scroll += new System.EventHandler(trkTintIFore2_Scroll);
		this.txtTintIFore2.Location = new System.Drawing.Point(147, 137);
		this.txtTintIFore2.Name = "txtTintIFore2";
		this.txtTintIFore2.Size = new System.Drawing.Size(56, 20);
		this.txtTintIFore2.TabIndex = 15;
		this.txtTintIFore2.TextChanged += new System.EventHandler(txtTintIFore2_TextChanged);
		this.label74.AutoSize = true;
		this.label74.Location = new System.Drawing.Point(12, 137);
		this.label74.Name = "label74";
		this.label74.Size = new System.Drawing.Size(28, 13);
		this.label74.TabIndex = 13;
		this.label74.Text = "Tint:";
		this.trkSatIFore2.Location = new System.Drawing.Point(36, 111);
		this.trkSatIFore2.Maximum = 1000;
		this.trkSatIFore2.Name = "trkSatIFore2";
		this.trkSatIFore2.Size = new System.Drawing.Size(104, 45);
		this.trkSatIFore2.TabIndex = 11;
		this.trkSatIFore2.TickFrequency = 100;
		this.trkSatIFore2.Scroll += new System.EventHandler(trkSatIFore2_Scroll);
		this.txtSatIFore2.Location = new System.Drawing.Point(147, 111);
		this.txtSatIFore2.Name = "txtSatIFore2";
		this.txtSatIFore2.Size = new System.Drawing.Size(56, 20);
		this.txtSatIFore2.TabIndex = 12;
		this.txtSatIFore2.TextChanged += new System.EventHandler(txtSatIFore2_TextChanged);
		this.label75.AutoSize = true;
		this.label75.Location = new System.Drawing.Point(12, 111);
		this.label75.Name = "label75";
		this.label75.Size = new System.Drawing.Size(26, 13);
		this.label75.TabIndex = 10;
		this.label75.Text = "Sat:";
		this.trkBIFore2.Location = new System.Drawing.Point(36, 85);
		this.trkBIFore2.Maximum = 1000;
		this.trkBIFore2.Name = "trkBIFore2";
		this.trkBIFore2.Size = new System.Drawing.Size(85, 45);
		this.trkBIFore2.TabIndex = 8;
		this.trkBIFore2.TickFrequency = 100;
		this.trkBIFore2.Scroll += new System.EventHandler(trkBIFore2_Scroll);
		this.txtBIFore2.Location = new System.Drawing.Point(127, 84);
		this.txtBIFore2.Name = "txtBIFore2";
		this.txtBIFore2.Size = new System.Drawing.Size(35, 20);
		this.txtBIFore2.TabIndex = 9;
		this.txtBIFore2.TextChanged += new System.EventHandler(txtBIFore2_TextChanged);
		this.label76.AutoSize = true;
		this.label76.Location = new System.Drawing.Point(12, 85);
		this.label76.Name = "label76";
		this.label76.Size = new System.Drawing.Size(17, 13);
		this.label76.TabIndex = 7;
		this.label76.Text = "B:";
		this.trkGIFore2.Location = new System.Drawing.Point(36, 60);
		this.trkGIFore2.Maximum = 1000;
		this.trkGIFore2.Name = "trkGIFore2";
		this.trkGIFore2.Size = new System.Drawing.Size(85, 45);
		this.trkGIFore2.TabIndex = 5;
		this.trkGIFore2.TickFrequency = 100;
		this.trkGIFore2.Scroll += new System.EventHandler(trkGIFore2_Scroll);
		this.txtGIFore2.Location = new System.Drawing.Point(127, 59);
		this.txtGIFore2.Name = "txtGIFore2";
		this.txtGIFore2.Size = new System.Drawing.Size(35, 20);
		this.txtGIFore2.TabIndex = 6;
		this.txtGIFore2.TextChanged += new System.EventHandler(txtGIFore2_TextChanged);
		this.label77.AutoSize = true;
		this.label77.Location = new System.Drawing.Point(12, 60);
		this.label77.Name = "label77";
		this.label77.Size = new System.Drawing.Size(18, 13);
		this.label77.TabIndex = 4;
		this.label77.Text = "G:";
		this.trkRIFore2.Location = new System.Drawing.Point(36, 34);
		this.trkRIFore2.Maximum = 1000;
		this.trkRIFore2.Name = "trkRIFore2";
		this.trkRIFore2.Size = new System.Drawing.Size(85, 45);
		this.trkRIFore2.TabIndex = 2;
		this.trkRIFore2.TickFrequency = 100;
		this.trkRIFore2.Scroll += new System.EventHandler(trkRIFore2_Scroll);
		this.txtRIFore2.Location = new System.Drawing.Point(127, 33);
		this.txtRIFore2.Name = "txtRIFore2";
		this.txtRIFore2.Size = new System.Drawing.Size(35, 20);
		this.txtRIFore2.TabIndex = 3;
		this.txtRIFore2.TextChanged += new System.EventHandler(txtRIFore2_TextChanged);
		this.label78.AutoSize = true;
		this.label78.Location = new System.Drawing.Point(12, 34);
		this.label78.Name = "label78";
		this.label78.Size = new System.Drawing.Size(18, 13);
		this.label78.TabIndex = 1;
		this.label78.Text = "R:";
		this.panel14.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel14.Controls.Add(this.txtBBIFore1);
		this.panel14.Controls.Add(this.txtBGIFore1);
		this.panel14.Controls.Add(this.txtBRIFore1);
		this.panel14.Controls.Add(this.trkGammaIFore1);
		this.panel14.Controls.Add(this.txtGammaIFore1);
		this.panel14.Controls.Add(this.label171);
		this.panel14.Controls.Add(this.trkBriteIFore1);
		this.panel14.Controls.Add(this.txtBriteIFore1);
		this.panel14.Controls.Add(this.label172);
		this.panel14.Controls.Add(this.label79);
		this.panel14.Controls.Add(this.trkTintIFore1);
		this.panel14.Controls.Add(this.txtTintIFore1);
		this.panel14.Controls.Add(this.label80);
		this.panel14.Controls.Add(this.trkSatIFore1);
		this.panel14.Controls.Add(this.txtSatIFore1);
		this.panel14.Controls.Add(this.label81);
		this.panel14.Controls.Add(this.trkBIFore1);
		this.panel14.Controls.Add(this.txtBIFore1);
		this.panel14.Controls.Add(this.label82);
		this.panel14.Controls.Add(this.trkGIFore1);
		this.panel14.Controls.Add(this.txtGIFore1);
		this.panel14.Controls.Add(this.label83);
		this.panel14.Controls.Add(this.trkRIFore1);
		this.panel14.Controls.Add(this.txtRIFore1);
		this.panel14.Controls.Add(this.label84);
		this.panel14.Location = new System.Drawing.Point(225, 234);
		this.panel14.Name = "panel14";
		this.panel14.Size = new System.Drawing.Size(213, 220);
		this.panel14.TabIndex = 28;
		this.trkGammaIFore1.Location = new System.Drawing.Point(36, 189);
		this.trkGammaIFore1.Maximum = 1000;
		this.trkGammaIFore1.Minimum = -1000;
		this.trkGammaIFore1.Name = "trkGammaIFore1";
		this.trkGammaIFore1.Size = new System.Drawing.Size(104, 45);
		this.trkGammaIFore1.TabIndex = 27;
		this.trkGammaIFore1.TickFrequency = 200;
		this.trkGammaIFore1.Scroll += new System.EventHandler(trkGammaIFore1_Scroll);
		this.txtGammaIFore1.Location = new System.Drawing.Point(147, 189);
		this.txtGammaIFore1.Name = "txtGammaIFore1";
		this.txtGammaIFore1.Size = new System.Drawing.Size(56, 20);
		this.txtGammaIFore1.TabIndex = 28;
		this.txtGammaIFore1.TextChanged += new System.EventHandler(txtGammaIFore1_TextChanged);
		this.label171.AutoSize = true;
		this.label171.Location = new System.Drawing.Point(12, 189);
		this.label171.Name = "label171";
		this.label171.Size = new System.Drawing.Size(26, 13);
		this.label171.TabIndex = 26;
		this.label171.Text = "Gm:";
		this.trkBriteIFore1.Location = new System.Drawing.Point(36, 163);
		this.trkBriteIFore1.Maximum = 1000;
		this.trkBriteIFore1.Name = "trkBriteIFore1";
		this.trkBriteIFore1.Size = new System.Drawing.Size(104, 45);
		this.trkBriteIFore1.TabIndex = 24;
		this.trkBriteIFore1.TickFrequency = 100;
		this.trkBriteIFore1.Scroll += new System.EventHandler(trkBriteIFore1_Scroll);
		this.txtBriteIFore1.Location = new System.Drawing.Point(147, 163);
		this.txtBriteIFore1.Name = "txtBriteIFore1";
		this.txtBriteIFore1.Size = new System.Drawing.Size(56, 20);
		this.txtBriteIFore1.TabIndex = 25;
		this.txtBriteIFore1.TextChanged += new System.EventHandler(txtBriteIFore1_TextChanged);
		this.label172.AutoSize = true;
		this.label172.Location = new System.Drawing.Point(12, 163);
		this.label172.Name = "label172";
		this.label172.Size = new System.Drawing.Size(25, 13);
		this.label172.TabIndex = 23;
		this.label172.Text = "Brit:";
		this.label79.AutoSize = true;
		this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label79.Location = new System.Drawing.Point(12, 13);
		this.label79.Name = "label79";
		this.label79.Size = new System.Drawing.Size(51, 13);
		this.label79.TabIndex = 16;
		this.label79.Text = "I Fore 1";
		this.trkTintIFore1.Location = new System.Drawing.Point(36, 137);
		this.trkTintIFore1.Maximum = 1000;
		this.trkTintIFore1.Name = "trkTintIFore1";
		this.trkTintIFore1.Size = new System.Drawing.Size(104, 45);
		this.trkTintIFore1.TabIndex = 14;
		this.trkTintIFore1.TickFrequency = 100;
		this.trkTintIFore1.Scroll += new System.EventHandler(trkTintIFore1_Scroll);
		this.txtTintIFore1.Location = new System.Drawing.Point(147, 137);
		this.txtTintIFore1.Name = "txtTintIFore1";
		this.txtTintIFore1.Size = new System.Drawing.Size(56, 20);
		this.txtTintIFore1.TabIndex = 15;
		this.txtTintIFore1.TextChanged += new System.EventHandler(txtTintIFore1_TextChanged);
		this.label80.AutoSize = true;
		this.label80.Location = new System.Drawing.Point(12, 137);
		this.label80.Name = "label80";
		this.label80.Size = new System.Drawing.Size(28, 13);
		this.label80.TabIndex = 13;
		this.label80.Text = "Tint:";
		this.trkSatIFore1.Location = new System.Drawing.Point(36, 111);
		this.trkSatIFore1.Maximum = 1000;
		this.trkSatIFore1.Name = "trkSatIFore1";
		this.trkSatIFore1.Size = new System.Drawing.Size(104, 45);
		this.trkSatIFore1.TabIndex = 11;
		this.trkSatIFore1.TickFrequency = 100;
		this.trkSatIFore1.Scroll += new System.EventHandler(trkSatIFore1_Scroll);
		this.txtSatIFore1.Location = new System.Drawing.Point(147, 111);
		this.txtSatIFore1.Name = "txtSatIFore1";
		this.txtSatIFore1.Size = new System.Drawing.Size(56, 20);
		this.txtSatIFore1.TabIndex = 12;
		this.txtSatIFore1.TextChanged += new System.EventHandler(txtSatIFore1_TextChanged);
		this.label81.AutoSize = true;
		this.label81.Location = new System.Drawing.Point(12, 111);
		this.label81.Name = "label81";
		this.label81.Size = new System.Drawing.Size(26, 13);
		this.label81.TabIndex = 10;
		this.label81.Text = "Sat:";
		this.trkBIFore1.Location = new System.Drawing.Point(36, 85);
		this.trkBIFore1.Maximum = 1000;
		this.trkBIFore1.Name = "trkBIFore1";
		this.trkBIFore1.Size = new System.Drawing.Size(85, 45);
		this.trkBIFore1.TabIndex = 8;
		this.trkBIFore1.TickFrequency = 100;
		this.trkBIFore1.Scroll += new System.EventHandler(trkBIFore1_Scroll);
		this.txtBIFore1.Location = new System.Drawing.Point(127, 85);
		this.txtBIFore1.Name = "txtBIFore1";
		this.txtBIFore1.Size = new System.Drawing.Size(35, 20);
		this.txtBIFore1.TabIndex = 9;
		this.txtBIFore1.TextChanged += new System.EventHandler(txtBIFore1_TextChanged);
		this.label82.AutoSize = true;
		this.label82.Location = new System.Drawing.Point(12, 85);
		this.label82.Name = "label82";
		this.label82.Size = new System.Drawing.Size(17, 13);
		this.label82.TabIndex = 7;
		this.label82.Text = "B:";
		this.trkGIFore1.Location = new System.Drawing.Point(36, 60);
		this.trkGIFore1.Maximum = 1000;
		this.trkGIFore1.Name = "trkGIFore1";
		this.trkGIFore1.Size = new System.Drawing.Size(85, 45);
		this.trkGIFore1.TabIndex = 5;
		this.trkGIFore1.TickFrequency = 100;
		this.trkGIFore1.Scroll += new System.EventHandler(trkGIFore1_Scroll);
		this.txtGIFore1.Location = new System.Drawing.Point(127, 60);
		this.txtGIFore1.Name = "txtGIFore1";
		this.txtGIFore1.Size = new System.Drawing.Size(35, 20);
		this.txtGIFore1.TabIndex = 6;
		this.txtGIFore1.TextChanged += new System.EventHandler(txtGIFore1_TextChanged);
		this.label83.AutoSize = true;
		this.label83.Location = new System.Drawing.Point(12, 60);
		this.label83.Name = "label83";
		this.label83.Size = new System.Drawing.Size(18, 13);
		this.label83.TabIndex = 4;
		this.label83.Text = "G:";
		this.trkRIFore1.Location = new System.Drawing.Point(36, 34);
		this.trkRIFore1.Maximum = 1000;
		this.trkRIFore1.Name = "trkRIFore1";
		this.trkRIFore1.Size = new System.Drawing.Size(85, 45);
		this.trkRIFore1.TabIndex = 2;
		this.trkRIFore1.TickFrequency = 100;
		this.trkRIFore1.Scroll += new System.EventHandler(trkRIFore1_Scroll);
		this.txtRIFore1.Location = new System.Drawing.Point(127, 34);
		this.txtRIFore1.Name = "txtRIFore1";
		this.txtRIFore1.Size = new System.Drawing.Size(35, 20);
		this.txtRIFore1.TabIndex = 3;
		this.txtRIFore1.TextChanged += new System.EventHandler(txtRIFore1_TextChanged);
		this.label84.AutoSize = true;
		this.label84.Location = new System.Drawing.Point(12, 34);
		this.label84.Name = "label84";
		this.label84.Size = new System.Drawing.Size(18, 13);
		this.label84.TabIndex = 1;
		this.label84.Text = "R:";
		this.panel15.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.panel15.Controls.Add(this.txtBBIMid);
		this.panel15.Controls.Add(this.txtBGIMid);
		this.panel15.Controls.Add(this.txtBRIMid);
		this.panel15.Controls.Add(this.trkGammaIMid);
		this.panel15.Controls.Add(this.txtGammaIMid);
		this.panel15.Controls.Add(this.label169);
		this.panel15.Controls.Add(this.trkBriteIMid);
		this.panel15.Controls.Add(this.txtBriteIMid);
		this.panel15.Controls.Add(this.label170);
		this.panel15.Controls.Add(this.label85);
		this.panel15.Controls.Add(this.trkTintIMid);
		this.panel15.Controls.Add(this.txtTintIMid);
		this.panel15.Controls.Add(this.label86);
		this.panel15.Controls.Add(this.trkSatIMid);
		this.panel15.Controls.Add(this.txtSatIMid);
		this.panel15.Controls.Add(this.label87);
		this.panel15.Controls.Add(this.trkBIMid);
		this.panel15.Controls.Add(this.txtBIMid);
		this.panel15.Controls.Add(this.label88);
		this.panel15.Controls.Add(this.trkGIMid);
		this.panel15.Controls.Add(this.txtGIMid);
		this.panel15.Controls.Add(this.label89);
		this.panel15.Controls.Add(this.trkRIMid);
		this.panel15.Controls.Add(this.txtRIMid);
		this.panel15.Controls.Add(this.label90);
		this.panel15.Location = new System.Drawing.Point(6, 234);
		this.panel15.Name = "panel15";
		this.panel15.Size = new System.Drawing.Size(213, 220);
		this.panel15.TabIndex = 29;
		this.trkGammaIMid.Location = new System.Drawing.Point(36, 189);
		this.trkGammaIMid.Maximum = 1000;
		this.trkGammaIMid.Minimum = -1000;
		this.trkGammaIMid.Name = "trkGammaIMid";
		this.trkGammaIMid.Size = new System.Drawing.Size(104, 45);
		this.trkGammaIMid.TabIndex = 27;
		this.trkGammaIMid.TickFrequency = 200;
		this.trkGammaIMid.Scroll += new System.EventHandler(trkGammaIMid_Scroll);
		this.txtGammaIMid.Location = new System.Drawing.Point(147, 189);
		this.txtGammaIMid.Name = "txtGammaIMid";
		this.txtGammaIMid.Size = new System.Drawing.Size(56, 20);
		this.txtGammaIMid.TabIndex = 28;
		this.txtGammaIMid.TextChanged += new System.EventHandler(txtGammaIMid_TextChanged);
		this.label169.AutoSize = true;
		this.label169.Location = new System.Drawing.Point(12, 189);
		this.label169.Name = "label169";
		this.label169.Size = new System.Drawing.Size(26, 13);
		this.label169.TabIndex = 26;
		this.label169.Text = "Gm:";
		this.trkBriteIMid.Location = new System.Drawing.Point(36, 163);
		this.trkBriteIMid.Maximum = 1000;
		this.trkBriteIMid.Name = "trkBriteIMid";
		this.trkBriteIMid.Size = new System.Drawing.Size(104, 45);
		this.trkBriteIMid.TabIndex = 24;
		this.trkBriteIMid.TickFrequency = 100;
		this.trkBriteIMid.Scroll += new System.EventHandler(trkBriteIMid_Scroll);
		this.txtBriteIMid.Location = new System.Drawing.Point(147, 163);
		this.txtBriteIMid.Name = "txtBriteIMid";
		this.txtBriteIMid.Size = new System.Drawing.Size(56, 20);
		this.txtBriteIMid.TabIndex = 25;
		this.txtBriteIMid.TextChanged += new System.EventHandler(txtBriteIMid_TextChanged);
		this.label170.AutoSize = true;
		this.label170.Location = new System.Drawing.Point(12, 163);
		this.label170.Name = "label170";
		this.label170.Size = new System.Drawing.Size(25, 13);
		this.label170.TabIndex = 23;
		this.label170.Text = "Brit:";
		this.label85.AutoSize = true;
		this.label85.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label85.Location = new System.Drawing.Point(12, 13);
		this.label85.Name = "label85";
		this.label85.Size = new System.Drawing.Size(35, 13);
		this.label85.TabIndex = 16;
		this.label85.Text = "I Mid";
		this.trkTintIMid.Location = new System.Drawing.Point(36, 137);
		this.trkTintIMid.Maximum = 1000;
		this.trkTintIMid.Name = "trkTintIMid";
		this.trkTintIMid.Size = new System.Drawing.Size(104, 45);
		this.trkTintIMid.TabIndex = 14;
		this.trkTintIMid.TickFrequency = 100;
		this.trkTintIMid.Scroll += new System.EventHandler(trkTintIMid_Scroll);
		this.txtTintIMid.Location = new System.Drawing.Point(147, 137);
		this.txtTintIMid.Name = "txtTintIMid";
		this.txtTintIMid.Size = new System.Drawing.Size(56, 20);
		this.txtTintIMid.TabIndex = 15;
		this.txtTintIMid.TextChanged += new System.EventHandler(txtTintIMid_TextChanged);
		this.label86.AutoSize = true;
		this.label86.Location = new System.Drawing.Point(12, 137);
		this.label86.Name = "label86";
		this.label86.Size = new System.Drawing.Size(28, 13);
		this.label86.TabIndex = 13;
		this.label86.Text = "Tint:";
		this.trkSatIMid.Location = new System.Drawing.Point(36, 111);
		this.trkSatIMid.Maximum = 1000;
		this.trkSatIMid.Name = "trkSatIMid";
		this.trkSatIMid.Size = new System.Drawing.Size(104, 45);
		this.trkSatIMid.TabIndex = 11;
		this.trkSatIMid.TickFrequency = 100;
		this.trkSatIMid.Scroll += new System.EventHandler(trkSatIMid_Scroll);
		this.txtSatIMid.Location = new System.Drawing.Point(147, 111);
		this.txtSatIMid.Name = "txtSatIMid";
		this.txtSatIMid.Size = new System.Drawing.Size(56, 20);
		this.txtSatIMid.TabIndex = 12;
		this.txtSatIMid.TextChanged += new System.EventHandler(txtSatIMid_TextChanged);
		this.label87.AutoSize = true;
		this.label87.Location = new System.Drawing.Point(12, 111);
		this.label87.Name = "label87";
		this.label87.Size = new System.Drawing.Size(26, 13);
		this.label87.TabIndex = 10;
		this.label87.Text = "Sat:";
		this.trkBIMid.Location = new System.Drawing.Point(36, 85);
		this.trkBIMid.Maximum = 1000;
		this.trkBIMid.Name = "trkBIMid";
		this.trkBIMid.Size = new System.Drawing.Size(85, 45);
		this.trkBIMid.TabIndex = 8;
		this.trkBIMid.TickFrequency = 100;
		this.trkBIMid.Scroll += new System.EventHandler(trkBIMid_Scroll);
		this.txtBIMid.Location = new System.Drawing.Point(127, 85);
		this.txtBIMid.Name = "txtBIMid";
		this.txtBIMid.Size = new System.Drawing.Size(35, 20);
		this.txtBIMid.TabIndex = 9;
		this.txtBIMid.TextChanged += new System.EventHandler(txtBIMid_TextChanged);
		this.label88.AutoSize = true;
		this.label88.Location = new System.Drawing.Point(12, 85);
		this.label88.Name = "label88";
		this.label88.Size = new System.Drawing.Size(17, 13);
		this.label88.TabIndex = 7;
		this.label88.Text = "B:";
		this.trkGIMid.Location = new System.Drawing.Point(36, 60);
		this.trkGIMid.Maximum = 1000;
		this.trkGIMid.Name = "trkGIMid";
		this.trkGIMid.Size = new System.Drawing.Size(85, 45);
		this.trkGIMid.TabIndex = 5;
		this.trkGIMid.TickFrequency = 100;
		this.trkGIMid.Scroll += new System.EventHandler(trkGIMid_Scroll);
		this.txtGIMid.Location = new System.Drawing.Point(127, 60);
		this.txtGIMid.Name = "txtGIMid";
		this.txtGIMid.Size = new System.Drawing.Size(35, 20);
		this.txtGIMid.TabIndex = 6;
		this.txtGIMid.TextChanged += new System.EventHandler(txtGIMid_TextChanged);
		this.label89.AutoSize = true;
		this.label89.Location = new System.Drawing.Point(12, 60);
		this.label89.Name = "label89";
		this.label89.Size = new System.Drawing.Size(18, 13);
		this.label89.TabIndex = 4;
		this.label89.Text = "G:";
		this.trkRIMid.Location = new System.Drawing.Point(36, 34);
		this.trkRIMid.Maximum = 1000;
		this.trkRIMid.Name = "trkRIMid";
		this.trkRIMid.Size = new System.Drawing.Size(85, 45);
		this.trkRIMid.TabIndex = 2;
		this.trkRIMid.TickFrequency = 100;
		this.trkRIMid.Scroll += new System.EventHandler(trkRIMid_Scroll);
		this.txtRIMid.Location = new System.Drawing.Point(127, 34);
		this.txtRIMid.Name = "txtRIMid";
		this.txtRIMid.Size = new System.Drawing.Size(35, 20);
		this.txtRIMid.TabIndex = 3;
		this.txtRIMid.TextChanged += new System.EventHandler(txtRIMid_TextChanged);
		this.label90.AutoSize = true;
		this.label90.Location = new System.Drawing.Point(12, 34);
		this.label90.Name = "label90";
		this.label90.Size = new System.Drawing.Size(18, 13);
		this.label90.TabIndex = 1;
		this.label90.Text = "R:";
		this.panel16.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel16.Controls.Add(this.txtBBIBack1);
		this.panel16.Controls.Add(this.txtBGIBack1);
		this.panel16.Controls.Add(this.txtBRIBack1);
		this.panel16.Controls.Add(this.trkGammaIBack1);
		this.panel16.Controls.Add(this.txtGammaIBack1);
		this.panel16.Controls.Add(this.label167);
		this.panel16.Controls.Add(this.trkBriteIBack1);
		this.panel16.Controls.Add(this.txtBriteIBack1);
		this.panel16.Controls.Add(this.label168);
		this.panel16.Controls.Add(this.label91);
		this.panel16.Controls.Add(this.trkTintIBack1);
		this.panel16.Controls.Add(this.txtTintIBack1);
		this.panel16.Controls.Add(this.label92);
		this.panel16.Controls.Add(this.trkSatIBack1);
		this.panel16.Controls.Add(this.txtSatIBack1);
		this.panel16.Controls.Add(this.label93);
		this.panel16.Controls.Add(this.trkBIBack1);
		this.panel16.Controls.Add(this.txtBIBack1);
		this.panel16.Controls.Add(this.label94);
		this.panel16.Controls.Add(this.trkGIBack1);
		this.panel16.Controls.Add(this.txtGIBack1);
		this.panel16.Controls.Add(this.label95);
		this.panel16.Controls.Add(this.trkRIBack1);
		this.panel16.Controls.Add(this.txtRIBack1);
		this.panel16.Controls.Add(this.label96);
		this.panel16.Location = new System.Drawing.Point(663, 8);
		this.panel16.Name = "panel16";
		this.panel16.Size = new System.Drawing.Size(213, 220);
		this.panel16.TabIndex = 27;
		this.trkGammaIBack1.Location = new System.Drawing.Point(36, 189);
		this.trkGammaIBack1.Maximum = 1000;
		this.trkGammaIBack1.Minimum = -1000;
		this.trkGammaIBack1.Name = "trkGammaIBack1";
		this.trkGammaIBack1.Size = new System.Drawing.Size(104, 45);
		this.trkGammaIBack1.TabIndex = 27;
		this.trkGammaIBack1.TickFrequency = 200;
		this.trkGammaIBack1.Scroll += new System.EventHandler(trkGammaIBack1_Scroll);
		this.txtGammaIBack1.Location = new System.Drawing.Point(147, 189);
		this.txtGammaIBack1.Name = "txtGammaIBack1";
		this.txtGammaIBack1.Size = new System.Drawing.Size(56, 20);
		this.txtGammaIBack1.TabIndex = 28;
		this.txtGammaIBack1.TextChanged += new System.EventHandler(txtGammaIBack1_TextChanged);
		this.label167.AutoSize = true;
		this.label167.Location = new System.Drawing.Point(12, 189);
		this.label167.Name = "label167";
		this.label167.Size = new System.Drawing.Size(26, 13);
		this.label167.TabIndex = 26;
		this.label167.Text = "Gm:";
		this.trkBriteIBack1.Location = new System.Drawing.Point(36, 163);
		this.trkBriteIBack1.Maximum = 1000;
		this.trkBriteIBack1.Name = "trkBriteIBack1";
		this.trkBriteIBack1.Size = new System.Drawing.Size(104, 45);
		this.trkBriteIBack1.TabIndex = 24;
		this.trkBriteIBack1.TickFrequency = 100;
		this.trkBriteIBack1.Scroll += new System.EventHandler(trkBriteIBack1_Scroll);
		this.txtBriteIBack1.Location = new System.Drawing.Point(147, 163);
		this.txtBriteIBack1.Name = "txtBriteIBack1";
		this.txtBriteIBack1.Size = new System.Drawing.Size(56, 20);
		this.txtBriteIBack1.TabIndex = 25;
		this.txtBriteIBack1.TextChanged += new System.EventHandler(txtBriteIBack1_TextChanged);
		this.label168.AutoSize = true;
		this.label168.Location = new System.Drawing.Point(12, 163);
		this.label168.Name = "label168";
		this.label168.Size = new System.Drawing.Size(25, 13);
		this.label168.TabIndex = 23;
		this.label168.Text = "Brit:";
		this.label91.AutoSize = true;
		this.label91.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label91.Location = new System.Drawing.Point(12, 13);
		this.label91.Name = "label91";
		this.label91.Size = new System.Drawing.Size(55, 13);
		this.label91.TabIndex = 16;
		this.label91.Text = "I Back 1";
		this.trkTintIBack1.Location = new System.Drawing.Point(36, 137);
		this.trkTintIBack1.Maximum = 1000;
		this.trkTintIBack1.Name = "trkTintIBack1";
		this.trkTintIBack1.Size = new System.Drawing.Size(104, 45);
		this.trkTintIBack1.TabIndex = 14;
		this.trkTintIBack1.TickFrequency = 100;
		this.trkTintIBack1.Scroll += new System.EventHandler(trkTintIBack1_Scroll);
		this.txtTintIBack1.Location = new System.Drawing.Point(147, 137);
		this.txtTintIBack1.Name = "txtTintIBack1";
		this.txtTintIBack1.Size = new System.Drawing.Size(56, 20);
		this.txtTintIBack1.TabIndex = 15;
		this.txtTintIBack1.TextChanged += new System.EventHandler(txtTintIBack1_TextChanged);
		this.label92.AutoSize = true;
		this.label92.Location = new System.Drawing.Point(12, 137);
		this.label92.Name = "label92";
		this.label92.Size = new System.Drawing.Size(28, 13);
		this.label92.TabIndex = 13;
		this.label92.Text = "Tint:";
		this.trkSatIBack1.Location = new System.Drawing.Point(36, 111);
		this.trkSatIBack1.Maximum = 1000;
		this.trkSatIBack1.Name = "trkSatIBack1";
		this.trkSatIBack1.Size = new System.Drawing.Size(104, 45);
		this.trkSatIBack1.TabIndex = 11;
		this.trkSatIBack1.TickFrequency = 100;
		this.trkSatIBack1.Scroll += new System.EventHandler(trkSatIBack1_Scroll);
		this.txtSatIBack1.Location = new System.Drawing.Point(147, 111);
		this.txtSatIBack1.Name = "txtSatIBack1";
		this.txtSatIBack1.Size = new System.Drawing.Size(56, 20);
		this.txtSatIBack1.TabIndex = 12;
		this.txtSatIBack1.TextChanged += new System.EventHandler(txtSatIBack1_TextChanged);
		this.label93.AutoSize = true;
		this.label93.Location = new System.Drawing.Point(12, 111);
		this.label93.Name = "label93";
		this.label93.Size = new System.Drawing.Size(26, 13);
		this.label93.TabIndex = 10;
		this.label93.Text = "Sat:";
		this.trkBIBack1.Location = new System.Drawing.Point(36, 85);
		this.trkBIBack1.Maximum = 1000;
		this.trkBIBack1.Name = "trkBIBack1";
		this.trkBIBack1.Size = new System.Drawing.Size(85, 45);
		this.trkBIBack1.TabIndex = 8;
		this.trkBIBack1.TickFrequency = 100;
		this.trkBIBack1.Scroll += new System.EventHandler(trkBIBack1_Scroll);
		this.txtBIBack1.Location = new System.Drawing.Point(127, 85);
		this.txtBIBack1.Name = "txtBIBack1";
		this.txtBIBack1.Size = new System.Drawing.Size(35, 20);
		this.txtBIBack1.TabIndex = 9;
		this.txtBIBack1.TextChanged += new System.EventHandler(txtBIBack1_TextChanged);
		this.label94.AutoSize = true;
		this.label94.Location = new System.Drawing.Point(12, 85);
		this.label94.Name = "label94";
		this.label94.Size = new System.Drawing.Size(17, 13);
		this.label94.TabIndex = 7;
		this.label94.Text = "B:";
		this.trkGIBack1.Location = new System.Drawing.Point(36, 60);
		this.trkGIBack1.Maximum = 1000;
		this.trkGIBack1.Name = "trkGIBack1";
		this.trkGIBack1.Size = new System.Drawing.Size(85, 45);
		this.trkGIBack1.TabIndex = 5;
		this.trkGIBack1.TickFrequency = 100;
		this.trkGIBack1.Scroll += new System.EventHandler(trkGIBack1_Scroll);
		this.txtGIBack1.Location = new System.Drawing.Point(127, 60);
		this.txtGIBack1.Name = "txtGIBack1";
		this.txtGIBack1.Size = new System.Drawing.Size(35, 20);
		this.txtGIBack1.TabIndex = 6;
		this.txtGIBack1.TextChanged += new System.EventHandler(txtGIBack1_TextChanged);
		this.label95.AutoSize = true;
		this.label95.Location = new System.Drawing.Point(12, 60);
		this.label95.Name = "label95";
		this.label95.Size = new System.Drawing.Size(18, 13);
		this.label95.TabIndex = 4;
		this.label95.Text = "G:";
		this.trkRIBack1.Location = new System.Drawing.Point(36, 34);
		this.trkRIBack1.Maximum = 1000;
		this.trkRIBack1.Name = "trkRIBack1";
		this.trkRIBack1.Size = new System.Drawing.Size(85, 45);
		this.trkRIBack1.TabIndex = 2;
		this.trkRIBack1.TickFrequency = 100;
		this.trkRIBack1.Scroll += new System.EventHandler(trkRIBack1_Scroll);
		this.txtRIBack1.Location = new System.Drawing.Point(127, 34);
		this.txtRIBack1.Name = "txtRIBack1";
		this.txtRIBack1.Size = new System.Drawing.Size(35, 20);
		this.txtRIBack1.TabIndex = 3;
		this.txtRIBack1.TextChanged += new System.EventHandler(txtRIBack1_TextChanged);
		this.label96.AutoSize = true;
		this.label96.Location = new System.Drawing.Point(12, 34);
		this.label96.Name = "label96";
		this.label96.Size = new System.Drawing.Size(18, 13);
		this.label96.TabIndex = 1;
		this.label96.Text = "R:";
		this.panel17.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel17.Controls.Add(this.txtBBIBack2);
		this.panel17.Controls.Add(this.txtBGIBack2);
		this.panel17.Controls.Add(this.txtBRIBack2);
		this.panel17.Controls.Add(this.trkGammaIBack2);
		this.panel17.Controls.Add(this.txtGammaIBack2);
		this.panel17.Controls.Add(this.label165);
		this.panel17.Controls.Add(this.trkBriteIBack2);
		this.panel17.Controls.Add(this.txtBriteIBack2);
		this.panel17.Controls.Add(this.label166);
		this.panel17.Controls.Add(this.label97);
		this.panel17.Controls.Add(this.trkTintIBack2);
		this.panel17.Controls.Add(this.txtTintIBack2);
		this.panel17.Controls.Add(this.label98);
		this.panel17.Controls.Add(this.trkSatIBack2);
		this.panel17.Controls.Add(this.txtSatIBack2);
		this.panel17.Controls.Add(this.label99);
		this.panel17.Controls.Add(this.trkBIBack2);
		this.panel17.Controls.Add(this.txtBIBack2);
		this.panel17.Controls.Add(this.label100);
		this.panel17.Controls.Add(this.trkGIBack2);
		this.panel17.Controls.Add(this.txtGIBack2);
		this.panel17.Controls.Add(this.label101);
		this.panel17.Controls.Add(this.trkRIBack2);
		this.panel17.Controls.Add(this.txtRIBack2);
		this.panel17.Controls.Add(this.label102);
		this.panel17.Location = new System.Drawing.Point(444, 8);
		this.panel17.Name = "panel17";
		this.panel17.Size = new System.Drawing.Size(213, 220);
		this.panel17.TabIndex = 26;
		this.trkGammaIBack2.Location = new System.Drawing.Point(36, 189);
		this.trkGammaIBack2.Maximum = 1000;
		this.trkGammaIBack2.Minimum = -1000;
		this.trkGammaIBack2.Name = "trkGammaIBack2";
		this.trkGammaIBack2.Size = new System.Drawing.Size(104, 45);
		this.trkGammaIBack2.TabIndex = 27;
		this.trkGammaIBack2.TickFrequency = 200;
		this.trkGammaIBack2.Scroll += new System.EventHandler(trkGammaIBack2_Scroll);
		this.txtGammaIBack2.Location = new System.Drawing.Point(147, 189);
		this.txtGammaIBack2.Name = "txtGammaIBack2";
		this.txtGammaIBack2.Size = new System.Drawing.Size(56, 20);
		this.txtGammaIBack2.TabIndex = 28;
		this.txtGammaIBack2.TextChanged += new System.EventHandler(txtGammaIBack2_TextChanged);
		this.label165.AutoSize = true;
		this.label165.Location = new System.Drawing.Point(12, 189);
		this.label165.Name = "label165";
		this.label165.Size = new System.Drawing.Size(26, 13);
		this.label165.TabIndex = 26;
		this.label165.Text = "Gm:";
		this.trkBriteIBack2.Location = new System.Drawing.Point(36, 163);
		this.trkBriteIBack2.Maximum = 1000;
		this.trkBriteIBack2.Name = "trkBriteIBack2";
		this.trkBriteIBack2.Size = new System.Drawing.Size(104, 45);
		this.trkBriteIBack2.TabIndex = 24;
		this.trkBriteIBack2.TickFrequency = 100;
		this.trkBriteIBack2.Scroll += new System.EventHandler(trkBriteIBack2_Scroll);
		this.txtBriteIBack2.Location = new System.Drawing.Point(147, 163);
		this.txtBriteIBack2.Name = "txtBriteIBack2";
		this.txtBriteIBack2.Size = new System.Drawing.Size(56, 20);
		this.txtBriteIBack2.TabIndex = 25;
		this.txtBriteIBack2.TextChanged += new System.EventHandler(txtBriteIBack2_TextChanged);
		this.label166.AutoSize = true;
		this.label166.Location = new System.Drawing.Point(12, 163);
		this.label166.Name = "label166";
		this.label166.Size = new System.Drawing.Size(25, 13);
		this.label166.TabIndex = 23;
		this.label166.Text = "Brit:";
		this.label97.AutoSize = true;
		this.label97.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label97.Location = new System.Drawing.Point(12, 13);
		this.label97.Name = "label97";
		this.label97.Size = new System.Drawing.Size(55, 13);
		this.label97.TabIndex = 16;
		this.label97.Text = "I Back 2";
		this.trkTintIBack2.Location = new System.Drawing.Point(36, 137);
		this.trkTintIBack2.Maximum = 1000;
		this.trkTintIBack2.Name = "trkTintIBack2";
		this.trkTintIBack2.Size = new System.Drawing.Size(104, 45);
		this.trkTintIBack2.TabIndex = 14;
		this.trkTintIBack2.TickFrequency = 100;
		this.trkTintIBack2.Scroll += new System.EventHandler(trkTintIBack2_Scroll);
		this.txtTintIBack2.Location = new System.Drawing.Point(147, 137);
		this.txtTintIBack2.Name = "txtTintIBack2";
		this.txtTintIBack2.Size = new System.Drawing.Size(56, 20);
		this.txtTintIBack2.TabIndex = 15;
		this.txtTintIBack2.TextChanged += new System.EventHandler(txtTintIBack2_TextChanged);
		this.label98.AutoSize = true;
		this.label98.Location = new System.Drawing.Point(12, 137);
		this.label98.Name = "label98";
		this.label98.Size = new System.Drawing.Size(28, 13);
		this.label98.TabIndex = 13;
		this.label98.Text = "Tint:";
		this.trkSatIBack2.Location = new System.Drawing.Point(36, 111);
		this.trkSatIBack2.Maximum = 1000;
		this.trkSatIBack2.Name = "trkSatIBack2";
		this.trkSatIBack2.Size = new System.Drawing.Size(104, 45);
		this.trkSatIBack2.TabIndex = 11;
		this.trkSatIBack2.TickFrequency = 100;
		this.trkSatIBack2.Scroll += new System.EventHandler(trkSatIBack2_Scroll);
		this.txtSatIBack2.Location = new System.Drawing.Point(147, 111);
		this.txtSatIBack2.Name = "txtSatIBack2";
		this.txtSatIBack2.Size = new System.Drawing.Size(56, 20);
		this.txtSatIBack2.TabIndex = 12;
		this.txtSatIBack2.TextChanged += new System.EventHandler(txtSatIBack2_TextChanged);
		this.label99.AutoSize = true;
		this.label99.Location = new System.Drawing.Point(12, 111);
		this.label99.Name = "label99";
		this.label99.Size = new System.Drawing.Size(26, 13);
		this.label99.TabIndex = 10;
		this.label99.Text = "Sat:";
		this.trkBIBack2.Location = new System.Drawing.Point(36, 85);
		this.trkBIBack2.Maximum = 1000;
		this.trkBIBack2.Name = "trkBIBack2";
		this.trkBIBack2.Size = new System.Drawing.Size(85, 45);
		this.trkBIBack2.TabIndex = 8;
		this.trkBIBack2.TickFrequency = 100;
		this.trkBIBack2.Scroll += new System.EventHandler(trkBIBack2_Scroll);
		this.txtBIBack2.Location = new System.Drawing.Point(127, 85);
		this.txtBIBack2.Name = "txtBIBack2";
		this.txtBIBack2.Size = new System.Drawing.Size(35, 20);
		this.txtBIBack2.TabIndex = 9;
		this.txtBIBack2.TextChanged += new System.EventHandler(txtBIBack2_TextChanged);
		this.label100.AutoSize = true;
		this.label100.Location = new System.Drawing.Point(12, 85);
		this.label100.Name = "label100";
		this.label100.Size = new System.Drawing.Size(17, 13);
		this.label100.TabIndex = 7;
		this.label100.Text = "B:";
		this.trkGIBack2.Location = new System.Drawing.Point(36, 60);
		this.trkGIBack2.Maximum = 1000;
		this.trkGIBack2.Name = "trkGIBack2";
		this.trkGIBack2.Size = new System.Drawing.Size(85, 45);
		this.trkGIBack2.TabIndex = 5;
		this.trkGIBack2.TickFrequency = 100;
		this.trkGIBack2.Scroll += new System.EventHandler(trkGIBack2_Scroll);
		this.txtGIBack2.Location = new System.Drawing.Point(127, 60);
		this.txtGIBack2.Name = "txtGIBack2";
		this.txtGIBack2.Size = new System.Drawing.Size(35, 20);
		this.txtGIBack2.TabIndex = 6;
		this.txtGIBack2.TextChanged += new System.EventHandler(txtGIBack2_TextChanged);
		this.label101.AutoSize = true;
		this.label101.Location = new System.Drawing.Point(12, 60);
		this.label101.Name = "label101";
		this.label101.Size = new System.Drawing.Size(18, 13);
		this.label101.TabIndex = 4;
		this.label101.Text = "G:";
		this.trkRIBack2.Location = new System.Drawing.Point(36, 34);
		this.trkRIBack2.Maximum = 1000;
		this.trkRIBack2.Name = "trkRIBack2";
		this.trkRIBack2.Size = new System.Drawing.Size(85, 45);
		this.trkRIBack2.TabIndex = 2;
		this.trkRIBack2.TickFrequency = 100;
		this.trkRIBack2.Scroll += new System.EventHandler(trkRIBack2_Scroll);
		this.txtRIBack2.Location = new System.Drawing.Point(127, 34);
		this.txtRIBack2.Name = "txtRIBack2";
		this.txtRIBack2.Size = new System.Drawing.Size(35, 20);
		this.txtRIBack2.TabIndex = 3;
		this.txtRIBack2.TextChanged += new System.EventHandler(txtRIBack2_TextChanged);
		this.label102.AutoSize = true;
		this.label102.Location = new System.Drawing.Point(12, 34);
		this.label102.Name = "label102";
		this.label102.Size = new System.Drawing.Size(18, 13);
		this.label102.TabIndex = 1;
		this.label102.Text = "R:";
		this.panel18.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel18.Controls.Add(this.txtBBIBack3);
		this.panel18.Controls.Add(this.txtBGIBack3);
		this.panel18.Controls.Add(this.txtBRIBack3);
		this.panel18.Controls.Add(this.trkGammaIBack3);
		this.panel18.Controls.Add(this.txtGammaIBack3);
		this.panel18.Controls.Add(this.label163);
		this.panel18.Controls.Add(this.trkBriteIBack3);
		this.panel18.Controls.Add(this.txtBriteIBack3);
		this.panel18.Controls.Add(this.label164);
		this.panel18.Controls.Add(this.label103);
		this.panel18.Controls.Add(this.trkTintIBack3);
		this.panel18.Controls.Add(this.txtTintIBack3);
		this.panel18.Controls.Add(this.label104);
		this.panel18.Controls.Add(this.trkSatIBack3);
		this.panel18.Controls.Add(this.txtSatIBack3);
		this.panel18.Controls.Add(this.label105);
		this.panel18.Controls.Add(this.trkBIBack3);
		this.panel18.Controls.Add(this.txtBIBack3);
		this.panel18.Controls.Add(this.label106);
		this.panel18.Controls.Add(this.trkGIBack3);
		this.panel18.Controls.Add(this.txtGIBack3);
		this.panel18.Controls.Add(this.label107);
		this.panel18.Controls.Add(this.trkRIBack3);
		this.panel18.Controls.Add(this.txtRIBack3);
		this.panel18.Controls.Add(this.label108);
		this.panel18.Location = new System.Drawing.Point(225, 8);
		this.panel18.Name = "panel18";
		this.panel18.Size = new System.Drawing.Size(213, 220);
		this.panel18.TabIndex = 25;
		this.trkGammaIBack3.Location = new System.Drawing.Point(36, 189);
		this.trkGammaIBack3.Maximum = 1000;
		this.trkGammaIBack3.Minimum = -1000;
		this.trkGammaIBack3.Name = "trkGammaIBack3";
		this.trkGammaIBack3.Size = new System.Drawing.Size(104, 45);
		this.trkGammaIBack3.TabIndex = 27;
		this.trkGammaIBack3.TickFrequency = 200;
		this.trkGammaIBack3.Scroll += new System.EventHandler(trkGammaIBack3_Scroll);
		this.txtGammaIBack3.Location = new System.Drawing.Point(147, 189);
		this.txtGammaIBack3.Name = "txtGammaIBack3";
		this.txtGammaIBack3.Size = new System.Drawing.Size(56, 20);
		this.txtGammaIBack3.TabIndex = 28;
		this.txtGammaIBack3.TextChanged += new System.EventHandler(txtGammaIBack3_TextChanged);
		this.label163.AutoSize = true;
		this.label163.Location = new System.Drawing.Point(12, 189);
		this.label163.Name = "label163";
		this.label163.Size = new System.Drawing.Size(26, 13);
		this.label163.TabIndex = 26;
		this.label163.Text = "Gm:";
		this.trkBriteIBack3.Location = new System.Drawing.Point(36, 163);
		this.trkBriteIBack3.Maximum = 1000;
		this.trkBriteIBack3.Name = "trkBriteIBack3";
		this.trkBriteIBack3.Size = new System.Drawing.Size(104, 45);
		this.trkBriteIBack3.TabIndex = 24;
		this.trkBriteIBack3.TickFrequency = 100;
		this.trkBriteIBack3.Scroll += new System.EventHandler(trkBriteIBack3_Scroll);
		this.txtBriteIBack3.Location = new System.Drawing.Point(147, 163);
		this.txtBriteIBack3.Name = "txtBriteIBack3";
		this.txtBriteIBack3.Size = new System.Drawing.Size(56, 20);
		this.txtBriteIBack3.TabIndex = 25;
		this.txtBriteIBack3.TextChanged += new System.EventHandler(txtBriteIBack3_TextChanged);
		this.label164.AutoSize = true;
		this.label164.Location = new System.Drawing.Point(12, 163);
		this.label164.Name = "label164";
		this.label164.Size = new System.Drawing.Size(25, 13);
		this.label164.TabIndex = 23;
		this.label164.Text = "Brit:";
		this.label103.AutoSize = true;
		this.label103.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label103.Location = new System.Drawing.Point(12, 13);
		this.label103.Name = "label103";
		this.label103.Size = new System.Drawing.Size(55, 13);
		this.label103.TabIndex = 16;
		this.label103.Text = "I Back 3";
		this.trkTintIBack3.Location = new System.Drawing.Point(36, 137);
		this.trkTintIBack3.Maximum = 1000;
		this.trkTintIBack3.Name = "trkTintIBack3";
		this.trkTintIBack3.Size = new System.Drawing.Size(104, 45);
		this.trkTintIBack3.TabIndex = 14;
		this.trkTintIBack3.TickFrequency = 100;
		this.trkTintIBack3.Scroll += new System.EventHandler(trkTintIBack3_Scroll);
		this.txtTintIBack3.Location = new System.Drawing.Point(147, 137);
		this.txtTintIBack3.Name = "txtTintIBack3";
		this.txtTintIBack3.Size = new System.Drawing.Size(56, 20);
		this.txtTintIBack3.TabIndex = 15;
		this.txtTintIBack3.TextChanged += new System.EventHandler(txtTintIBack3_TextChanged);
		this.label104.AutoSize = true;
		this.label104.Location = new System.Drawing.Point(12, 137);
		this.label104.Name = "label104";
		this.label104.Size = new System.Drawing.Size(28, 13);
		this.label104.TabIndex = 13;
		this.label104.Text = "Tint:";
		this.trkSatIBack3.Location = new System.Drawing.Point(36, 111);
		this.trkSatIBack3.Maximum = 1000;
		this.trkSatIBack3.Name = "trkSatIBack3";
		this.trkSatIBack3.Size = new System.Drawing.Size(104, 45);
		this.trkSatIBack3.TabIndex = 11;
		this.trkSatIBack3.TickFrequency = 100;
		this.trkSatIBack3.Scroll += new System.EventHandler(trkSatIBack3_Scroll);
		this.txtSatIBack3.Location = new System.Drawing.Point(147, 111);
		this.txtSatIBack3.Name = "txtSatIBack3";
		this.txtSatIBack3.Size = new System.Drawing.Size(56, 20);
		this.txtSatIBack3.TabIndex = 12;
		this.txtSatIBack3.TextChanged += new System.EventHandler(txtSatIBack3_TextChanged);
		this.label105.AutoSize = true;
		this.label105.Location = new System.Drawing.Point(12, 111);
		this.label105.Name = "label105";
		this.label105.Size = new System.Drawing.Size(26, 13);
		this.label105.TabIndex = 10;
		this.label105.Text = "Sat:";
		this.trkBIBack3.Location = new System.Drawing.Point(36, 85);
		this.trkBIBack3.Maximum = 1000;
		this.trkBIBack3.Name = "trkBIBack3";
		this.trkBIBack3.Size = new System.Drawing.Size(85, 45);
		this.trkBIBack3.TabIndex = 8;
		this.trkBIBack3.TickFrequency = 100;
		this.trkBIBack3.Scroll += new System.EventHandler(trkBIBack3_Scroll);
		this.txtBIBack3.Location = new System.Drawing.Point(127, 85);
		this.txtBIBack3.Name = "txtBIBack3";
		this.txtBIBack3.Size = new System.Drawing.Size(35, 20);
		this.txtBIBack3.TabIndex = 9;
		this.txtBIBack3.TextChanged += new System.EventHandler(txtBIBack3_TextChanged);
		this.label106.AutoSize = true;
		this.label106.Location = new System.Drawing.Point(12, 85);
		this.label106.Name = "label106";
		this.label106.Size = new System.Drawing.Size(17, 13);
		this.label106.TabIndex = 7;
		this.label106.Text = "B:";
		this.trkGIBack3.Location = new System.Drawing.Point(36, 60);
		this.trkGIBack3.Maximum = 1000;
		this.trkGIBack3.Name = "trkGIBack3";
		this.trkGIBack3.Size = new System.Drawing.Size(85, 45);
		this.trkGIBack3.TabIndex = 5;
		this.trkGIBack3.TickFrequency = 100;
		this.trkGIBack3.Scroll += new System.EventHandler(trkGIBack3_Scroll);
		this.txtGIBack3.Location = new System.Drawing.Point(127, 60);
		this.txtGIBack3.Name = "txtGIBack3";
		this.txtGIBack3.Size = new System.Drawing.Size(35, 20);
		this.txtGIBack3.TabIndex = 6;
		this.txtGIBack3.TextChanged += new System.EventHandler(txtGIBack3_TextChanged);
		this.label107.AutoSize = true;
		this.label107.Location = new System.Drawing.Point(12, 60);
		this.label107.Name = "label107";
		this.label107.Size = new System.Drawing.Size(18, 13);
		this.label107.TabIndex = 4;
		this.label107.Text = "G:";
		this.trkRIBack3.Location = new System.Drawing.Point(36, 34);
		this.trkRIBack3.Maximum = 1000;
		this.trkRIBack3.Name = "trkRIBack3";
		this.trkRIBack3.Size = new System.Drawing.Size(85, 45);
		this.trkRIBack3.TabIndex = 2;
		this.trkRIBack3.TickFrequency = 100;
		this.trkRIBack3.Scroll += new System.EventHandler(trkRIBack3_Scroll);
		this.txtRIBack3.Location = new System.Drawing.Point(127, 34);
		this.txtRIBack3.Name = "txtRIBack3";
		this.txtRIBack3.Size = new System.Drawing.Size(35, 20);
		this.txtRIBack3.TabIndex = 3;
		this.txtRIBack3.TextChanged += new System.EventHandler(txtRIBack3_TextChanged);
		this.label108.AutoSize = true;
		this.label108.Location = new System.Drawing.Point(12, 34);
		this.label108.Name = "label108";
		this.label108.Size = new System.Drawing.Size(18, 13);
		this.label108.TabIndex = 1;
		this.label108.Text = "R:";
		this.panel19.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel19.Controls.Add(this.txtBBIBack4);
		this.panel19.Controls.Add(this.txtBGIBack4);
		this.panel19.Controls.Add(this.txtBRIBack4);
		this.panel19.Controls.Add(this.trkGammaIBack4);
		this.panel19.Controls.Add(this.txtGammaIBack4);
		this.panel19.Controls.Add(this.label162);
		this.panel19.Controls.Add(this.trkBriteIBack4);
		this.panel19.Controls.Add(this.txtBriteIBack4);
		this.panel19.Controls.Add(this.label161);
		this.panel19.Controls.Add(this.label109);
		this.panel19.Controls.Add(this.trkTintIBack4);
		this.panel19.Controls.Add(this.txtTintIBack4);
		this.panel19.Controls.Add(this.label110);
		this.panel19.Controls.Add(this.trkSatIBack4);
		this.panel19.Controls.Add(this.txtSatIBack4);
		this.panel19.Controls.Add(this.label111);
		this.panel19.Controls.Add(this.trkBIBack4);
		this.panel19.Controls.Add(this.txtBIBack4);
		this.panel19.Controls.Add(this.label112);
		this.panel19.Controls.Add(this.trkGIBack4);
		this.panel19.Controls.Add(this.txtGIBack4);
		this.panel19.Controls.Add(this.label113);
		this.panel19.Controls.Add(this.trkRIBack4);
		this.panel19.Controls.Add(this.txtRIBack4);
		this.panel19.Controls.Add(this.label114);
		this.panel19.Location = new System.Drawing.Point(6, 8);
		this.panel19.Name = "panel19";
		this.panel19.Size = new System.Drawing.Size(213, 220);
		this.panel19.TabIndex = 24;
		this.trkGammaIBack4.Location = new System.Drawing.Point(36, 189);
		this.trkGammaIBack4.Maximum = 1000;
		this.trkGammaIBack4.Minimum = -1000;
		this.trkGammaIBack4.Name = "trkGammaIBack4";
		this.trkGammaIBack4.Size = new System.Drawing.Size(104, 45);
		this.trkGammaIBack4.TabIndex = 21;
		this.trkGammaIBack4.TickFrequency = 200;
		this.trkGammaIBack4.Scroll += new System.EventHandler(trkGammaIBack4_Scroll);
		this.txtGammaIBack4.Location = new System.Drawing.Point(147, 189);
		this.txtGammaIBack4.Name = "txtGammaIBack4";
		this.txtGammaIBack4.Size = new System.Drawing.Size(56, 20);
		this.txtGammaIBack4.TabIndex = 22;
		this.txtGammaIBack4.TextChanged += new System.EventHandler(txtGammaIBack4_TextChanged);
		this.label162.AutoSize = true;
		this.label162.Location = new System.Drawing.Point(12, 189);
		this.label162.Name = "label162";
		this.label162.Size = new System.Drawing.Size(26, 13);
		this.label162.TabIndex = 20;
		this.label162.Text = "Gm:";
		this.trkBriteIBack4.Location = new System.Drawing.Point(36, 163);
		this.trkBriteIBack4.Maximum = 1000;
		this.trkBriteIBack4.Name = "trkBriteIBack4";
		this.trkBriteIBack4.Size = new System.Drawing.Size(104, 45);
		this.trkBriteIBack4.TabIndex = 18;
		this.trkBriteIBack4.TickFrequency = 100;
		this.trkBriteIBack4.Scroll += new System.EventHandler(trkBriteIBack4_Scroll);
		this.txtBriteIBack4.Location = new System.Drawing.Point(147, 163);
		this.txtBriteIBack4.Name = "txtBriteIBack4";
		this.txtBriteIBack4.Size = new System.Drawing.Size(56, 20);
		this.txtBriteIBack4.TabIndex = 19;
		this.txtBriteIBack4.TextChanged += new System.EventHandler(txtBriteIBack4_TextChanged);
		this.label161.AutoSize = true;
		this.label161.Location = new System.Drawing.Point(12, 163);
		this.label161.Name = "label161";
		this.label161.Size = new System.Drawing.Size(25, 13);
		this.label161.TabIndex = 17;
		this.label161.Text = "Brit:";
		this.label109.AutoSize = true;
		this.label109.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label109.Location = new System.Drawing.Point(12, 13);
		this.label109.Name = "label109";
		this.label109.Size = new System.Drawing.Size(55, 13);
		this.label109.TabIndex = 16;
		this.label109.Text = "I Back 4";
		this.trkTintIBack4.Location = new System.Drawing.Point(36, 137);
		this.trkTintIBack4.Maximum = 1000;
		this.trkTintIBack4.Name = "trkTintIBack4";
		this.trkTintIBack4.Size = new System.Drawing.Size(104, 45);
		this.trkTintIBack4.TabIndex = 14;
		this.trkTintIBack4.TickFrequency = 100;
		this.trkTintIBack4.Scroll += new System.EventHandler(trkTintIBack4_Scroll);
		this.txtTintIBack4.Location = new System.Drawing.Point(147, 137);
		this.txtTintIBack4.Name = "txtTintIBack4";
		this.txtTintIBack4.Size = new System.Drawing.Size(56, 20);
		this.txtTintIBack4.TabIndex = 15;
		this.txtTintIBack4.TextChanged += new System.EventHandler(txtTintIBack4_TextChanged);
		this.label110.AutoSize = true;
		this.label110.Location = new System.Drawing.Point(12, 137);
		this.label110.Name = "label110";
		this.label110.Size = new System.Drawing.Size(28, 13);
		this.label110.TabIndex = 13;
		this.label110.Text = "Tint:";
		this.trkSatIBack4.Location = new System.Drawing.Point(36, 111);
		this.trkSatIBack4.Maximum = 1000;
		this.trkSatIBack4.Name = "trkSatIBack4";
		this.trkSatIBack4.Size = new System.Drawing.Size(104, 45);
		this.trkSatIBack4.TabIndex = 11;
		this.trkSatIBack4.TickFrequency = 100;
		this.trkSatIBack4.Scroll += new System.EventHandler(trkSatIBack4_Scroll);
		this.txtSatIBack4.Location = new System.Drawing.Point(147, 111);
		this.txtSatIBack4.Name = "txtSatIBack4";
		this.txtSatIBack4.Size = new System.Drawing.Size(56, 20);
		this.txtSatIBack4.TabIndex = 12;
		this.txtSatIBack4.TextChanged += new System.EventHandler(txtSatIBack4_TextChanged);
		this.label111.AutoSize = true;
		this.label111.Location = new System.Drawing.Point(12, 111);
		this.label111.Name = "label111";
		this.label111.Size = new System.Drawing.Size(26, 13);
		this.label111.TabIndex = 10;
		this.label111.Text = "Sat:";
		this.trkBIBack4.Location = new System.Drawing.Point(36, 85);
		this.trkBIBack4.Maximum = 1000;
		this.trkBIBack4.Name = "trkBIBack4";
		this.trkBIBack4.Size = new System.Drawing.Size(85, 45);
		this.trkBIBack4.TabIndex = 8;
		this.trkBIBack4.TickFrequency = 100;
		this.trkBIBack4.Scroll += new System.EventHandler(trkBIBack4_Scroll);
		this.txtBIBack4.Location = new System.Drawing.Point(127, 85);
		this.txtBIBack4.Name = "txtBIBack4";
		this.txtBIBack4.Size = new System.Drawing.Size(35, 20);
		this.txtBIBack4.TabIndex = 9;
		this.txtBIBack4.TextChanged += new System.EventHandler(txtBIBack4_TextChanged);
		this.label112.AutoSize = true;
		this.label112.Location = new System.Drawing.Point(12, 85);
		this.label112.Name = "label112";
		this.label112.Size = new System.Drawing.Size(17, 13);
		this.label112.TabIndex = 7;
		this.label112.Text = "B:";
		this.trkGIBack4.Location = new System.Drawing.Point(36, 60);
		this.trkGIBack4.Maximum = 1000;
		this.trkGIBack4.Name = "trkGIBack4";
		this.trkGIBack4.Size = new System.Drawing.Size(85, 45);
		this.trkGIBack4.TabIndex = 5;
		this.trkGIBack4.TickFrequency = 100;
		this.trkGIBack4.Scroll += new System.EventHandler(trkGIBack4_Scroll);
		this.txtGIBack4.Location = new System.Drawing.Point(127, 60);
		this.txtGIBack4.Name = "txtGIBack4";
		this.txtGIBack4.Size = new System.Drawing.Size(35, 20);
		this.txtGIBack4.TabIndex = 6;
		this.txtGIBack4.TextChanged += new System.EventHandler(txtGIBack4_TextChanged);
		this.label113.AutoSize = true;
		this.label113.Location = new System.Drawing.Point(12, 60);
		this.label113.Name = "label113";
		this.label113.Size = new System.Drawing.Size(18, 13);
		this.label113.TabIndex = 4;
		this.label113.Text = "G:";
		this.trkRIBack4.Location = new System.Drawing.Point(36, 34);
		this.trkRIBack4.Maximum = 1000;
		this.trkRIBack4.Name = "trkRIBack4";
		this.trkRIBack4.Size = new System.Drawing.Size(85, 45);
		this.trkRIBack4.TabIndex = 2;
		this.trkRIBack4.TickFrequency = 100;
		this.trkRIBack4.Scroll += new System.EventHandler(trkRIBack4_Scroll);
		this.txtRIBack4.Location = new System.Drawing.Point(127, 34);
		this.txtRIBack4.Name = "txtRIBack4";
		this.txtRIBack4.Size = new System.Drawing.Size(35, 20);
		this.txtRIBack4.TabIndex = 3;
		this.txtRIBack4.TextChanged += new System.EventHandler(txtRIBack4_TextChanged);
		this.label114.AutoSize = true;
		this.label114.Location = new System.Drawing.Point(12, 34);
		this.label114.Name = "label114";
		this.label114.Size = new System.Drawing.Size(18, 13);
		this.label114.TabIndex = 1;
		this.label114.Text = "R:";
		this.trktB.Location = new System.Drawing.Point(36, 92);
		this.trktB.Maximum = 2000;
		this.trktB.Name = "trktB";
		this.trktB.Size = new System.Drawing.Size(104, 45);
		this.trktB.TabIndex = 40;
		this.trktB.TickFrequency = 200;
		this.trktB.Scroll += new System.EventHandler(trktB_Scroll);
		this.txttB.Location = new System.Drawing.Point(147, 92);
		this.txttB.Name = "txttB";
		this.txttB.Size = new System.Drawing.Size(56, 20);
		this.txttB.TabIndex = 41;
		this.txttB.TextChanged += new System.EventHandler(txttB_TextChanged);
		this.label115.AutoSize = true;
		this.label115.Location = new System.Drawing.Point(12, 92);
		this.label115.Name = "label115";
		this.label115.Size = new System.Drawing.Size(20, 13);
		this.label115.TabIndex = 39;
		this.label115.Text = "tB:";
		this.trktG.Location = new System.Drawing.Point(36, 67);
		this.trktG.Maximum = 2000;
		this.trktG.Name = "trktG";
		this.trktG.Size = new System.Drawing.Size(104, 45);
		this.trktG.TabIndex = 37;
		this.trktG.TickFrequency = 200;
		this.trktG.Scroll += new System.EventHandler(trktG_Scroll);
		this.txttG.Location = new System.Drawing.Point(147, 67);
		this.txttG.Name = "txttG";
		this.txttG.Size = new System.Drawing.Size(56, 20);
		this.txttG.TabIndex = 38;
		this.txttG.TextChanged += new System.EventHandler(txttG_TextChanged);
		this.label116.AutoSize = true;
		this.label116.Location = new System.Drawing.Point(12, 67);
		this.label116.Name = "label116";
		this.label116.Size = new System.Drawing.Size(21, 13);
		this.label116.TabIndex = 36;
		this.label116.Text = "tG:";
		this.trktR.Location = new System.Drawing.Point(36, 41);
		this.trktR.Maximum = 2000;
		this.trktR.Name = "trktR";
		this.trktR.Size = new System.Drawing.Size(104, 45);
		this.trktR.TabIndex = 34;
		this.trktR.TickFrequency = 200;
		this.trktR.Scroll += new System.EventHandler(trktR_Scroll);
		this.txttR.Location = new System.Drawing.Point(147, 41);
		this.txttR.Name = "txttR";
		this.txttR.Size = new System.Drawing.Size(56, 20);
		this.txttR.TabIndex = 35;
		this.txttR.TextChanged += new System.EventHandler(txttR_TextChanged);
		this.label117.AutoSize = true;
		this.label117.Location = new System.Drawing.Point(12, 41);
		this.label117.Name = "label117";
		this.label117.Size = new System.Drawing.Size(21, 13);
		this.label117.TabIndex = 33;
		this.label117.Text = "tR:";
		this.trkbB.Location = new System.Drawing.Point(36, 187);
		this.trkbB.Maximum = 2000;
		this.trkbB.Name = "trkbB";
		this.trkbB.Size = new System.Drawing.Size(104, 45);
		this.trkbB.TabIndex = 49;
		this.trkbB.TickFrequency = 200;
		this.trkbB.Scroll += new System.EventHandler(trkbB_Scroll);
		this.txtbB.Location = new System.Drawing.Point(147, 187);
		this.txtbB.Name = "txtbB";
		this.txtbB.Size = new System.Drawing.Size(56, 20);
		this.txtbB.TabIndex = 50;
		this.txtbB.TextChanged += new System.EventHandler(txtbB_TextChanged);
		this.label118.AutoSize = true;
		this.label118.Location = new System.Drawing.Point(12, 187);
		this.label118.Name = "label118";
		this.label118.Size = new System.Drawing.Size(23, 13);
		this.label118.TabIndex = 48;
		this.label118.Text = "bB:";
		this.trkbG.Location = new System.Drawing.Point(36, 162);
		this.trkbG.Maximum = 2000;
		this.trkbG.Name = "trkbG";
		this.trkbG.Size = new System.Drawing.Size(104, 45);
		this.trkbG.TabIndex = 46;
		this.trkbG.TickFrequency = 200;
		this.trkbG.Scroll += new System.EventHandler(trkbG_Scroll);
		this.txtbG.Location = new System.Drawing.Point(147, 162);
		this.txtbG.Name = "txtbG";
		this.txtbG.Size = new System.Drawing.Size(56, 20);
		this.txtbG.TabIndex = 47;
		this.txtbG.TextChanged += new System.EventHandler(txtbG_TextChanged);
		this.label119.AutoSize = true;
		this.label119.Location = new System.Drawing.Point(12, 162);
		this.label119.Name = "label119";
		this.label119.Size = new System.Drawing.Size(24, 13);
		this.label119.TabIndex = 45;
		this.label119.Text = "bG:";
		this.trkbR.Location = new System.Drawing.Point(36, 136);
		this.trkbR.Maximum = 2000;
		this.trkbR.Name = "trkbR";
		this.trkbR.Size = new System.Drawing.Size(104, 45);
		this.trkbR.TabIndex = 43;
		this.trkbR.TickFrequency = 200;
		this.trkbR.Scroll += new System.EventHandler(trkbR_Scroll);
		this.txtbR.Location = new System.Drawing.Point(147, 136);
		this.txtbR.Name = "txtbR";
		this.txtbR.Size = new System.Drawing.Size(56, 20);
		this.txtbR.TabIndex = 44;
		this.txtbR.TextChanged += new System.EventHandler(txtbR_TextChanged);
		this.label120.AutoSize = true;
		this.label120.Location = new System.Drawing.Point(12, 136);
		this.label120.Name = "label120";
		this.label120.Size = new System.Drawing.Size(24, 13);
		this.label120.TabIndex = 42;
		this.label120.Text = "bR:";
		this.trkbgB.Location = new System.Drawing.Point(38, 91);
		this.trkbgB.Maximum = 1000;
		this.trkbgB.Name = "trkbgB";
		this.trkbgB.Size = new System.Drawing.Size(104, 45);
		this.trkbgB.TabIndex = 58;
		this.trkbgB.TickFrequency = 100;
		this.trkbgB.Scroll += new System.EventHandler(trkbgB_Scroll);
		this.txtbgB.Location = new System.Drawing.Point(149, 91);
		this.txtbgB.Name = "txtbgB";
		this.txtbgB.Size = new System.Drawing.Size(56, 20);
		this.txtbgB.TabIndex = 59;
		this.txtbgB.TextChanged += new System.EventHandler(txtbgB_TextChanged);
		this.label121.AutoSize = true;
		this.label121.Location = new System.Drawing.Point(12, 91);
		this.label121.Name = "label121";
		this.label121.Size = new System.Drawing.Size(17, 13);
		this.label121.TabIndex = 57;
		this.label121.Text = "B:";
		this.trkbgG.Location = new System.Drawing.Point(38, 66);
		this.trkbgG.Maximum = 1000;
		this.trkbgG.Name = "trkbgG";
		this.trkbgG.Size = new System.Drawing.Size(104, 45);
		this.trkbgG.TabIndex = 55;
		this.trkbgG.TickFrequency = 100;
		this.trkbgG.Scroll += new System.EventHandler(trkbgG_Scroll);
		this.txtbgG.Location = new System.Drawing.Point(149, 66);
		this.txtbgG.Name = "txtbgG";
		this.txtbgG.Size = new System.Drawing.Size(56, 20);
		this.txtbgG.TabIndex = 56;
		this.txtbgG.TextChanged += new System.EventHandler(txtbgG_TextChanged);
		this.label122.AutoSize = true;
		this.label122.Location = new System.Drawing.Point(12, 66);
		this.label122.Name = "label122";
		this.label122.Size = new System.Drawing.Size(18, 13);
		this.label122.TabIndex = 54;
		this.label122.Text = "G:";
		this.trkbgR.Location = new System.Drawing.Point(38, 40);
		this.trkbgR.Maximum = 1000;
		this.trkbgR.Name = "trkbgR";
		this.trkbgR.Size = new System.Drawing.Size(104, 45);
		this.trkbgR.TabIndex = 52;
		this.trkbgR.TickFrequency = 100;
		this.trkbgR.Scroll += new System.EventHandler(trkbgR_Scroll);
		this.txtbgR.Location = new System.Drawing.Point(149, 40);
		this.txtbgR.Name = "txtbgR";
		this.txtbgR.Size = new System.Drawing.Size(56, 20);
		this.txtbgR.TabIndex = 53;
		this.txtbgR.TextChanged += new System.EventHandler(txtbgR_TextChanged);
		this.label123.AutoSize = true;
		this.label123.Location = new System.Drawing.Point(12, 40);
		this.label123.Name = "label123";
		this.label123.Size = new System.Drawing.Size(18, 13);
		this.label123.TabIndex = 51;
		this.label123.Text = "R:";
		this.trkburnB.Location = new System.Drawing.Point(38, 89);
		this.trkburnB.Maximum = 1000;
		this.trkburnB.Minimum = -3000;
		this.trkburnB.Name = "trkburnB";
		this.trkburnB.Size = new System.Drawing.Size(104, 45);
		this.trkburnB.TabIndex = 67;
		this.trkburnB.TickFrequency = 400;
		this.trkburnB.Scroll += new System.EventHandler(trkburnB_Scroll);
		this.txtburnB.Location = new System.Drawing.Point(149, 89);
		this.txtburnB.Name = "txtburnB";
		this.txtburnB.Size = new System.Drawing.Size(56, 20);
		this.txtburnB.TabIndex = 68;
		this.txtburnB.TextChanged += new System.EventHandler(txtburnB_TextChanged);
		this.trkburnG.Location = new System.Drawing.Point(38, 64);
		this.trkburnG.Maximum = 1000;
		this.trkburnG.Minimum = -3000;
		this.trkburnG.Name = "trkburnG";
		this.trkburnG.Size = new System.Drawing.Size(104, 45);
		this.trkburnG.TabIndex = 64;
		this.trkburnG.TickFrequency = 400;
		this.trkburnG.Scroll += new System.EventHandler(trkburnG_Scroll);
		this.txtburnG.Location = new System.Drawing.Point(149, 64);
		this.txtburnG.Name = "txtburnG";
		this.txtburnG.Size = new System.Drawing.Size(56, 20);
		this.txtburnG.TabIndex = 65;
		this.txtburnG.TextChanged += new System.EventHandler(txtburnG_TextChanged);
		this.trkburnR.Location = new System.Drawing.Point(38, 38);
		this.trkburnR.Maximum = 1000;
		this.trkburnR.Minimum = -3000;
		this.trkburnR.Name = "trkburnR";
		this.trkburnR.Size = new System.Drawing.Size(104, 45);
		this.trkburnR.TabIndex = 61;
		this.trkburnR.TickFrequency = 400;
		this.trkburnR.Scroll += new System.EventHandler(trkburnR_Scroll);
		this.txtburnR.Location = new System.Drawing.Point(149, 38);
		this.txtburnR.Name = "txtburnR";
		this.txtburnR.Size = new System.Drawing.Size(56, 20);
		this.txtburnR.TabIndex = 62;
		this.txtburnR.TextChanged += new System.EventHandler(txtburnR_TextChanged);
		this.lstLayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[1] { this.columnHeader1 });
		this.lstLayers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
		this.lstLayers.LabelEdit = true;
		this.lstLayers.Location = new System.Drawing.Point(4, 27);
		this.lstLayers.MultiSelect = false;
		this.lstLayers.Name = "lstLayers";
		this.lstLayers.Size = new System.Drawing.Size(233, 706);
		this.lstLayers.TabIndex = 69;
		this.lstLayers.UseCompatibleStateImageBehavior = false;
		this.lstLayers.View = System.Windows.Forms.View.Details;
		this.lstLayers.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(lstLayers_AfterLabelEdit);
		this.lstLayers.SelectedIndexChanged += new System.EventHandler(lstLayers_SelectedIndexChanged);
		this.lstLayers.MouseClick += new System.Windows.Forms.MouseEventHandler(lstLayers_MouseClick);
		this.lstLayers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(lstLayers_MouseDoubleClick);
		this.lstLayers.MouseUp += new System.Windows.Forms.MouseEventHandler(lstLayers_MouseUp);
		this.columnHeader1.Text = "Layer";
		this.chkIndoors.AutoSize = true;
		this.chkIndoors.Location = new System.Drawing.Point(142, 15);
		this.chkIndoors.Name = "chkIndoors";
		this.chkIndoors.Size = new System.Drawing.Size(61, 17);
		this.chkIndoors.TabIndex = 70;
		this.chkIndoors.Text = "Indoors";
		this.chkIndoors.UseVisualStyleBackColor = true;
		this.chkIndoors.CheckedChanged += new System.EventHandler(chkIndoors_CheckedChanged);
		this.trkBrite.Location = new System.Drawing.Point(265, 43);
		this.trkBrite.Maximum = 2000;
		this.trkBrite.Minimum = -1000;
		this.trkBrite.Name = "trkBrite";
		this.trkBrite.Size = new System.Drawing.Size(101, 45);
		this.trkBrite.TabIndex = 75;
		this.trkBrite.TickFrequency = 200;
		this.trkBrite.Scroll += new System.EventHandler(trkBrite_Scroll);
		this.txtBrite.Location = new System.Drawing.Point(366, 43);
		this.txtBrite.Name = "txtBrite";
		this.txtBrite.Size = new System.Drawing.Size(56, 20);
		this.txtBrite.TabIndex = 76;
		this.txtBrite.TextChanged += new System.EventHandler(txtBrite_TextChanged);
		this.label127.AutoSize = true;
		this.label127.Location = new System.Drawing.Point(216, 43);
		this.label127.Name = "label127";
		this.label127.Size = new System.Drawing.Size(31, 13);
		this.label127.TabIndex = 74;
		this.label127.Text = "Brite:";
		this.trkGamma.Location = new System.Drawing.Point(63, 43);
		this.trkGamma.Maximum = 1000;
		this.trkGamma.Minimum = -1000;
		this.trkGamma.Name = "trkGamma";
		this.trkGamma.Size = new System.Drawing.Size(80, 45);
		this.trkGamma.TabIndex = 72;
		this.trkGamma.TickFrequency = 200;
		this.trkGamma.Scroll += new System.EventHandler(trkGamma_Scroll);
		this.txtGamma.Location = new System.Drawing.Point(149, 43);
		this.txtGamma.Name = "txtGamma";
		this.txtGamma.Size = new System.Drawing.Size(56, 20);
		this.txtGamma.TabIndex = 73;
		this.txtGamma.TextChanged += new System.EventHandler(txtGamma_TextChanged);
		this.label128.AutoSize = true;
		this.label128.Location = new System.Drawing.Point(14, 43);
		this.label128.Name = "label128";
		this.label128.Size = new System.Drawing.Size(46, 13);
		this.label128.TabIndex = 71;
		this.label128.Text = "Gamma:";
		this.trkBloomBase.Location = new System.Drawing.Point(57, 67);
		this.trkBloomBase.Maximum = 2000;
		this.trkBloomBase.Name = "trkBloomBase";
		this.trkBloomBase.Size = new System.Drawing.Size(104, 45);
		this.trkBloomBase.TabIndex = 81;
		this.trkBloomBase.TickFrequency = 200;
		this.trkBloomBase.Scroll += new System.EventHandler(trkBloomBase_Scroll);
		this.txtBloomBase.Location = new System.Drawing.Point(164, 67);
		this.txtBloomBase.Name = "txtBloomBase";
		this.txtBloomBase.Size = new System.Drawing.Size(56, 20);
		this.txtBloomBase.TabIndex = 82;
		this.txtBloomBase.TextChanged += new System.EventHandler(txtBloomBase_TextChanged);
		this.label129.AutoSize = true;
		this.label129.Location = new System.Drawing.Point(14, 67);
		this.label129.Name = "label129";
		this.label129.Size = new System.Drawing.Size(34, 13);
		this.label129.TabIndex = 80;
		this.label129.Text = "Base:";
		this.trkBloomThresh.Location = new System.Drawing.Point(57, 41);
		this.trkBloomThresh.Maximum = 1000;
		this.trkBloomThresh.Name = "trkBloomThresh";
		this.trkBloomThresh.Size = new System.Drawing.Size(104, 45);
		this.trkBloomThresh.TabIndex = 78;
		this.trkBloomThresh.TickFrequency = 100;
		this.trkBloomThresh.Scroll += new System.EventHandler(trkBloomThresh_Scroll);
		this.txtBloomThresh.Location = new System.Drawing.Point(164, 41);
		this.txtBloomThresh.Name = "txtBloomThresh";
		this.txtBloomThresh.Size = new System.Drawing.Size(56, 20);
		this.txtBloomThresh.TabIndex = 79;
		this.txtBloomThresh.TextChanged += new System.EventHandler(txtBloomThresh_TextChanged);
		this.label130.AutoSize = true;
		this.label130.Location = new System.Drawing.Point(14, 41);
		this.label130.Name = "label130";
		this.label130.Size = new System.Drawing.Size(43, 13);
		this.label130.TabIndex = 77;
		this.label130.Text = "Thresh:";
		this.trkBloomSat.Location = new System.Drawing.Point(57, 119);
		this.trkBloomSat.Maximum = 2000;
		this.trkBloomSat.Name = "trkBloomSat";
		this.trkBloomSat.Size = new System.Drawing.Size(104, 45);
		this.trkBloomSat.TabIndex = 87;
		this.trkBloomSat.TickFrequency = 200;
		this.trkBloomSat.Scroll += new System.EventHandler(trkBloomSat_Scroll);
		this.txtBloomSat.Location = new System.Drawing.Point(164, 119);
		this.txtBloomSat.Name = "txtBloomSat";
		this.txtBloomSat.Size = new System.Drawing.Size(56, 20);
		this.txtBloomSat.TabIndex = 88;
		this.txtBloomSat.TextChanged += new System.EventHandler(txtBloomSat_TextChanged);
		this.label131.AutoSize = true;
		this.label131.Location = new System.Drawing.Point(14, 119);
		this.label131.Name = "label131";
		this.label131.Size = new System.Drawing.Size(26, 13);
		this.label131.TabIndex = 86;
		this.label131.Text = "Sat:";
		this.trkBloomIntensity.Location = new System.Drawing.Point(57, 93);
		this.trkBloomIntensity.Maximum = 3000;
		this.trkBloomIntensity.Name = "trkBloomIntensity";
		this.trkBloomIntensity.Size = new System.Drawing.Size(104, 45);
		this.trkBloomIntensity.TabIndex = 84;
		this.trkBloomIntensity.TickFrequency = 300;
		this.trkBloomIntensity.Scroll += new System.EventHandler(trkBloomIntensity_Scroll);
		this.txtBloomIntensity.Location = new System.Drawing.Point(164, 93);
		this.txtBloomIntensity.Name = "txtBloomIntensity";
		this.txtBloomIntensity.Size = new System.Drawing.Size(56, 20);
		this.txtBloomIntensity.TabIndex = 85;
		this.txtBloomIntensity.TextChanged += new System.EventHandler(txtBloomIntensity_TextChanged);
		this.label132.AutoSize = true;
		this.label132.Location = new System.Drawing.Point(14, 93);
		this.label132.Name = "label132";
		this.label132.Size = new System.Drawing.Size(47, 13);
		this.label132.TabIndex = 83;
		this.label132.Text = "Intensty:";
		this.trkBloomFloor.Location = new System.Drawing.Point(57, 145);
		this.trkBloomFloor.Maximum = 1000;
		this.trkBloomFloor.Name = "trkBloomFloor";
		this.trkBloomFloor.Size = new System.Drawing.Size(104, 45);
		this.trkBloomFloor.TabIndex = 90;
		this.trkBloomFloor.TickFrequency = 100;
		this.trkBloomFloor.Scroll += new System.EventHandler(trkBloomFloor_Scroll);
		this.txtBloomFloor.Location = new System.Drawing.Point(164, 145);
		this.txtBloomFloor.Name = "txtBloomFloor";
		this.txtBloomFloor.Size = new System.Drawing.Size(56, 20);
		this.txtBloomFloor.TabIndex = 91;
		this.txtBloomFloor.TextChanged += new System.EventHandler(txtBloomFloor_TextChanged);
		this.label133.AutoSize = true;
		this.label133.Location = new System.Drawing.Point(14, 145);
		this.label133.Name = "label133";
		this.label133.Size = new System.Drawing.Size(33, 13);
		this.label133.TabIndex = 89;
		this.label133.Text = "Floor:";
		this.trkDarkBlur.Location = new System.Drawing.Point(57, 142);
		this.trkDarkBlur.Maximum = 1000;
		this.trkDarkBlur.Name = "trkDarkBlur";
		this.trkDarkBlur.Size = new System.Drawing.Size(104, 45);
		this.trkDarkBlur.TabIndex = 105;
		this.trkDarkBlur.TickFrequency = 100;
		this.trkDarkBlur.Scroll += new System.EventHandler(trkDarkBlur_Scroll);
		this.txtDarkBlur.Location = new System.Drawing.Point(164, 142);
		this.txtDarkBlur.Name = "txtDarkBlur";
		this.txtDarkBlur.Size = new System.Drawing.Size(56, 20);
		this.txtDarkBlur.TabIndex = 106;
		this.txtDarkBlur.TextChanged += new System.EventHandler(txtDarkBlur_TextChanged);
		this.label134.AutoSize = true;
		this.label134.Location = new System.Drawing.Point(14, 142);
		this.label134.Name = "label134";
		this.label134.Size = new System.Drawing.Size(44, 13);
		this.label134.TabIndex = 104;
		this.label134.Text = "Drkblur:";
		this.trkLightDesat.Location = new System.Drawing.Point(57, 116);
		this.trkLightDesat.Maximum = 1000;
		this.trkLightDesat.Name = "trkLightDesat";
		this.trkLightDesat.Size = new System.Drawing.Size(104, 45);
		this.trkLightDesat.TabIndex = 102;
		this.trkLightDesat.TickFrequency = 100;
		this.trkLightDesat.Scroll += new System.EventHandler(trkLightDesat_Scroll);
		this.txtLightDesat.Location = new System.Drawing.Point(164, 116);
		this.txtLightDesat.Name = "txtLightDesat";
		this.txtLightDesat.Size = new System.Drawing.Size(56, 20);
		this.txtLightDesat.TabIndex = 103;
		this.txtLightDesat.TextChanged += new System.EventHandler(txtLightDesat_TextChanged);
		this.label135.AutoSize = true;
		this.label135.Location = new System.Drawing.Point(14, 116);
		this.label135.Name = "label135";
		this.label135.Size = new System.Drawing.Size(38, 13);
		this.label135.TabIndex = 101;
		this.label135.Text = "Desat:";
		this.trkLightRed.Location = new System.Drawing.Point(57, 90);
		this.trkLightRed.Maximum = 1000;
		this.trkLightRed.Name = "trkLightRed";
		this.trkLightRed.Size = new System.Drawing.Size(104, 45);
		this.trkLightRed.TabIndex = 99;
		this.trkLightRed.TickFrequency = 100;
		this.trkLightRed.Scroll += new System.EventHandler(trkLightRed_Scroll);
		this.txtLightRed.Location = new System.Drawing.Point(164, 90);
		this.txtLightRed.Name = "txtLightRed";
		this.txtLightRed.Size = new System.Drawing.Size(56, 20);
		this.txtLightRed.TabIndex = 100;
		this.txtLightRed.TextChanged += new System.EventHandler(txtLightRed_TextChanged);
		this.label136.AutoSize = true;
		this.label136.Location = new System.Drawing.Point(14, 90);
		this.label136.Name = "label136";
		this.label136.Size = new System.Drawing.Size(30, 13);
		this.label136.TabIndex = 98;
		this.label136.Text = "Red:";
		this.trkLightBlue.Location = new System.Drawing.Point(57, 64);
		this.trkLightBlue.Maximum = 3000;
		this.trkLightBlue.Name = "trkLightBlue";
		this.trkLightBlue.Size = new System.Drawing.Size(104, 45);
		this.trkLightBlue.TabIndex = 96;
		this.trkLightBlue.TickFrequency = 300;
		this.trkLightBlue.Scroll += new System.EventHandler(trkLightBlue_Scroll);
		this.txtLightBlue.Location = new System.Drawing.Point(164, 64);
		this.txtLightBlue.Name = "txtLightBlue";
		this.txtLightBlue.Size = new System.Drawing.Size(56, 20);
		this.txtLightBlue.TabIndex = 97;
		this.txtLightBlue.TextChanged += new System.EventHandler(txtLightBlue_TextChanged);
		this.label137.AutoSize = true;
		this.label137.Location = new System.Drawing.Point(14, 64);
		this.label137.Name = "label137";
		this.label137.Size = new System.Drawing.Size(31, 13);
		this.label137.TabIndex = 95;
		this.label137.Text = "Blue:";
		this.trkLightThresh.Location = new System.Drawing.Point(57, 38);
		this.trkLightThresh.Maximum = 1000;
		this.trkLightThresh.Name = "trkLightThresh";
		this.trkLightThresh.Size = new System.Drawing.Size(104, 45);
		this.trkLightThresh.TabIndex = 93;
		this.trkLightThresh.TickFrequency = 100;
		this.trkLightThresh.Scroll += new System.EventHandler(trkLightThresh_Scroll);
		this.txtLightThresh.Location = new System.Drawing.Point(164, 38);
		this.txtLightThresh.Name = "txtLightThresh";
		this.txtLightThresh.Size = new System.Drawing.Size(56, 20);
		this.txtLightThresh.TabIndex = 94;
		this.txtLightThresh.TextChanged += new System.EventHandler(txtLightThresh_TextChanged);
		this.label138.AutoSize = true;
		this.label138.Location = new System.Drawing.Point(14, 38);
		this.label138.Name = "label138";
		this.label138.Size = new System.Drawing.Size(43, 13);
		this.label138.TabIndex = 92;
		this.label138.Text = "Thresh:";
		this.panel20.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel20.Controls.Add(this.trkbB);
		this.panel20.Controls.Add(this.trkbG);
		this.panel20.Controls.Add(this.trkbR);
		this.panel20.Controls.Add(this.trktB);
		this.panel20.Controls.Add(this.trktG);
		this.panel20.Controls.Add(this.label139);
		this.panel20.Controls.Add(this.label117);
		this.panel20.Controls.Add(this.txttR);
		this.panel20.Controls.Add(this.trktR);
		this.panel20.Controls.Add(this.label116);
		this.panel20.Controls.Add(this.txttG);
		this.panel20.Controls.Add(this.label115);
		this.panel20.Controls.Add(this.txttB);
		this.panel20.Controls.Add(this.label120);
		this.panel20.Controls.Add(this.txtbR);
		this.panel20.Controls.Add(this.label119);
		this.panel20.Controls.Add(this.txtbG);
		this.panel20.Controls.Add(this.label118);
		this.panel20.Controls.Add(this.txtbB);
		this.panel20.Location = new System.Drawing.Point(245, 361);
		this.panel20.Name = "panel20";
		this.panel20.Size = new System.Drawing.Size(213, 220);
		this.panel20.TabIndex = 25;
		this.label139.AutoSize = true;
		this.label139.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label139.Location = new System.Drawing.Point(12, 13);
		this.label139.Name = "label139";
		this.label139.Size = new System.Drawing.Size(33, 13);
		this.label139.TabIndex = 16;
		this.label139.Text = "RGB";
		this.panel21.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel21.Controls.Add(this.trkbgB);
		this.panel21.Controls.Add(this.trkbgG);
		this.panel21.Controls.Add(this.label140);
		this.panel21.Controls.Add(this.txtbgR);
		this.panel21.Controls.Add(this.label123);
		this.panel21.Controls.Add(this.trkbgR);
		this.panel21.Controls.Add(this.label122);
		this.panel21.Controls.Add(this.txtbgG);
		this.panel21.Controls.Add(this.label121);
		this.panel21.Controls.Add(this.txtbgB);
		this.panel21.Location = new System.Drawing.Point(245, 85);
		this.panel21.Name = "panel21";
		this.panel21.Size = new System.Drawing.Size(213, 130);
		this.panel21.TabIndex = 51;
		this.label140.AutoSize = true;
		this.label140.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label140.Location = new System.Drawing.Point(12, 13);
		this.label140.Name = "label140";
		this.label140.Size = new System.Drawing.Size(75, 13);
		this.label140.TabIndex = 16;
		this.label140.Text = "Background";
		this.panel22.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel22.Controls.Add(this.trkburnB);
		this.panel22.Controls.Add(this.trkburnG);
		this.panel22.Controls.Add(this.label124);
		this.panel22.Controls.Add(this.label125);
		this.panel22.Controls.Add(this.label126);
		this.panel22.Controls.Add(this.label141);
		this.panel22.Controls.Add(this.txtburnR);
		this.panel22.Controls.Add(this.trkburnR);
		this.panel22.Controls.Add(this.txtburnG);
		this.panel22.Controls.Add(this.txtburnB);
		this.panel22.Location = new System.Drawing.Point(245, 221);
		this.panel22.Name = "panel22";
		this.panel22.Size = new System.Drawing.Size(213, 130);
		this.panel22.TabIndex = 60;
		this.label124.AutoSize = true;
		this.label124.Location = new System.Drawing.Point(12, 41);
		this.label124.Name = "label124";
		this.label124.Size = new System.Drawing.Size(18, 13);
		this.label124.TabIndex = 69;
		this.label124.Text = "R:";
		this.label125.AutoSize = true;
		this.label125.Location = new System.Drawing.Point(12, 67);
		this.label125.Name = "label125";
		this.label125.Size = new System.Drawing.Size(18, 13);
		this.label125.TabIndex = 70;
		this.label125.Text = "G:";
		this.label126.AutoSize = true;
		this.label126.Location = new System.Drawing.Point(12, 92);
		this.label126.Name = "label126";
		this.label126.Size = new System.Drawing.Size(17, 13);
		this.label126.TabIndex = 71;
		this.label126.Text = "B:";
		this.label141.AutoSize = true;
		this.label141.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label141.Location = new System.Drawing.Point(12, 13);
		this.label141.Name = "label141";
		this.label141.Size = new System.Drawing.Size(33, 13);
		this.label141.TabIndex = 16;
		this.label141.Text = "Burn";
		this.panel23.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel23.Controls.Add(this.trkBloomDesatBase);
		this.panel23.Controls.Add(this.label245);
		this.panel23.Controls.Add(this.txtBloomDesatBase);
		this.panel23.Controls.Add(this.trkBloomFloor);
		this.panel23.Controls.Add(this.trkBloomSat);
		this.panel23.Controls.Add(this.trkBloomIntensity);
		this.panel23.Controls.Add(this.trkBloomBase);
		this.panel23.Controls.Add(this.label145);
		this.panel23.Controls.Add(this.label130);
		this.panel23.Controls.Add(this.txtBloomThresh);
		this.panel23.Controls.Add(this.trkBloomThresh);
		this.panel23.Controls.Add(this.label129);
		this.panel23.Controls.Add(this.txtBloomBase);
		this.panel23.Controls.Add(this.label132);
		this.panel23.Controls.Add(this.txtBloomIntensity);
		this.panel23.Controls.Add(this.label131);
		this.panel23.Controls.Add(this.txtBloomSat);
		this.panel23.Controls.Add(this.label133);
		this.panel23.Controls.Add(this.txtBloomFloor);
		this.panel23.Location = new System.Drawing.Point(6, 350);
		this.panel23.Name = "panel23";
		this.panel23.Size = new System.Drawing.Size(233, 231);
		this.panel23.TabIndex = 72;
		this.trkBloomDesatBase.Location = new System.Drawing.Point(57, 171);
		this.trkBloomDesatBase.Maximum = 2000;
		this.trkBloomDesatBase.Name = "trkBloomDesatBase";
		this.trkBloomDesatBase.Size = new System.Drawing.Size(104, 45);
		this.trkBloomDesatBase.TabIndex = 93;
		this.trkBloomDesatBase.TickFrequency = 100;
		this.trkBloomDesatBase.Scroll += new System.EventHandler(trkBloomDesatBase_Scroll);
		this.label245.AutoSize = true;
		this.label245.Location = new System.Drawing.Point(14, 171);
		this.label245.Name = "label245";
		this.label245.Size = new System.Drawing.Size(43, 13);
		this.label245.TabIndex = 92;
		this.label245.Text = "Extract:";
		this.txtBloomDesatBase.Location = new System.Drawing.Point(164, 171);
		this.txtBloomDesatBase.Name = "txtBloomDesatBase";
		this.txtBloomDesatBase.Size = new System.Drawing.Size(56, 20);
		this.txtBloomDesatBase.TabIndex = 94;
		this.txtBloomDesatBase.TextChanged += new System.EventHandler(txtBloomDesatBase_TextChanged);
		this.label145.AutoSize = true;
		this.label145.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label145.Location = new System.Drawing.Point(12, 13);
		this.label145.Name = "label145";
		this.label145.Size = new System.Drawing.Size(41, 13);
		this.label145.TabIndex = 16;
		this.label145.Text = "Bloom";
		this.panel24.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel24.Controls.Add(this.trkLightFac);
		this.panel24.Controls.Add(this.trkLightMap);
		this.panel24.Controls.Add(this.txtLightFac);
		this.panel24.Controls.Add(this.label144);
		this.panel24.Controls.Add(this.txtLightMap);
		this.panel24.Controls.Add(this.label146);
		this.panel24.Controls.Add(this.trkDarkBlur);
		this.panel24.Controls.Add(this.trkLightDesat);
		this.panel24.Controls.Add(this.trkLightRed);
		this.panel24.Controls.Add(this.trkLightBlue);
		this.panel24.Controls.Add(this.label142);
		this.panel24.Controls.Add(this.label138);
		this.panel24.Controls.Add(this.txtLightThresh);
		this.panel24.Controls.Add(this.trkLightThresh);
		this.panel24.Controls.Add(this.label137);
		this.panel24.Controls.Add(this.txtLightBlue);
		this.panel24.Controls.Add(this.txtDarkBlur);
		this.panel24.Controls.Add(this.label134);
		this.panel24.Controls.Add(this.label136);
		this.panel24.Controls.Add(this.txtLightRed);
		this.panel24.Controls.Add(this.txtLightDesat);
		this.panel24.Controls.Add(this.label135);
		this.panel24.Location = new System.Drawing.Point(6, 85);
		this.panel24.Name = "panel24";
		this.panel24.Size = new System.Drawing.Size(233, 257);
		this.panel24.TabIndex = 92;
		this.trkLightFac.Location = new System.Drawing.Point(57, 201);
		this.trkLightFac.Maximum = 2000;
		this.trkLightFac.Name = "trkLightFac";
		this.trkLightFac.Size = new System.Drawing.Size(104, 45);
		this.trkLightFac.TabIndex = 111;
		this.trkLightFac.TickFrequency = 200;
		this.trkLightFac.Scroll += new System.EventHandler(trkLightFac_Scroll);
		this.trkLightMap.Location = new System.Drawing.Point(57, 175);
		this.trkLightMap.Maximum = 1000;
		this.trkLightMap.Name = "trkLightMap";
		this.trkLightMap.Size = new System.Drawing.Size(104, 45);
		this.trkLightMap.TabIndex = 108;
		this.trkLightMap.TickFrequency = 100;
		this.trkLightMap.Scroll += new System.EventHandler(trkLightMap_Scroll);
		this.txtLightFac.Location = new System.Drawing.Point(164, 201);
		this.txtLightFac.Name = "txtLightFac";
		this.txtLightFac.Size = new System.Drawing.Size(56, 20);
		this.txtLightFac.TabIndex = 112;
		this.txtLightFac.TextChanged += new System.EventHandler(txtLightFac_TextChanged);
		this.label144.AutoSize = true;
		this.label144.Location = new System.Drawing.Point(14, 201);
		this.label144.Name = "label144";
		this.label144.Size = new System.Drawing.Size(28, 13);
		this.label144.TabIndex = 110;
		this.label144.Text = "Fac:";
		this.txtLightMap.Location = new System.Drawing.Point(164, 175);
		this.txtLightMap.Name = "txtLightMap";
		this.txtLightMap.Size = new System.Drawing.Size(56, 20);
		this.txtLightMap.TabIndex = 109;
		this.txtLightMap.TextChanged += new System.EventHandler(txtLightMap_TextChanged);
		this.label146.AutoSize = true;
		this.label146.Location = new System.Drawing.Point(14, 175);
		this.label146.Name = "label146";
		this.label146.Size = new System.Drawing.Size(31, 13);
		this.label146.TabIndex = 107;
		this.label146.Text = "Map:";
		this.label142.AutoSize = true;
		this.label142.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label142.Location = new System.Drawing.Point(12, 13);
		this.label142.Name = "label142";
		this.label142.Size = new System.Drawing.Size(35, 13);
		this.label142.TabIndex = 16;
		this.label142.Text = "Light";
		this.panel25.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel25.Controls.Add(this.trkBrite);
		this.panel25.Controls.Add(this.txtGamma);
		this.panel25.Controls.Add(this.txtBrite);
		this.panel25.Controls.Add(this.txtBaseSat);
		this.panel25.Controls.Add(this.trkBaseSat);
		this.panel25.Controls.Add(this.label147);
		this.panel25.Controls.Add(this.label143);
		this.panel25.Controls.Add(this.label128);
		this.panel25.Controls.Add(this.trkGamma);
		this.panel25.Controls.Add(this.chkIndoors);
		this.panel25.Controls.Add(this.label127);
		this.panel25.Location = new System.Drawing.Point(6, 8);
		this.panel25.Name = "panel25";
		this.panel25.Size = new System.Drawing.Size(452, 71);
		this.panel25.TabIndex = 60;
		this.txtBaseSat.Location = new System.Drawing.Point(366, 13);
		this.txtBaseSat.Name = "txtBaseSat";
		this.txtBaseSat.Size = new System.Drawing.Size(56, 20);
		this.txtBaseSat.TabIndex = 79;
		this.txtBaseSat.TextChanged += new System.EventHandler(txtBaseSat_TextChanged);
		this.trkBaseSat.Location = new System.Drawing.Point(265, 13);
		this.trkBaseSat.Maximum = 1000;
		this.trkBaseSat.Name = "trkBaseSat";
		this.trkBaseSat.Size = new System.Drawing.Size(101, 45);
		this.trkBaseSat.TabIndex = 78;
		this.trkBaseSat.TickFrequency = 100;
		this.trkBaseSat.Scroll += new System.EventHandler(trkBaseSat_Scroll);
		this.label147.AutoSize = true;
		this.label147.Location = new System.Drawing.Point(216, 13);
		this.label147.Name = "label147";
		this.label147.Size = new System.Drawing.Size(50, 13);
		this.label147.TabIndex = 77;
		this.label147.Text = "BaseSat:";
		this.label143.AutoSize = true;
		this.label143.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label143.Location = new System.Drawing.Point(12, 13);
		this.label143.Name = "label143";
		this.label143.Size = new System.Drawing.Size(75, 13);
		this.label143.TabIndex = 16;
		this.label143.Text = "Background";
		this.panel26.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel26.Controls.Add(this.trkLeavesAlpha);
		this.panel26.Controls.Add(this.label152);
		this.panel26.Controls.Add(this.txtLeavesAlpha);
		this.panel26.Controls.Add(this.trkRainAlpha);
		this.panel26.Controls.Add(this.trkSnowAlpha);
		this.panel26.Controls.Add(this.label148);
		this.panel26.Controls.Add(this.label149);
		this.panel26.Controls.Add(this.label150);
		this.panel26.Controls.Add(this.label151);
		this.panel26.Controls.Add(this.txtDotsAlpha);
		this.panel26.Controls.Add(this.trkDotsAlpha);
		this.panel26.Controls.Add(this.txtSnowAlpha);
		this.panel26.Controls.Add(this.txtRainAlpha);
		this.panel26.Location = new System.Drawing.Point(464, 7);
		this.panel26.Name = "panel26";
		this.panel26.Size = new System.Drawing.Size(213, 161);
		this.panel26.TabIndex = 72;
		this.trkLeavesAlpha.Location = new System.Drawing.Point(53, 115);
		this.trkLeavesAlpha.Maximum = 2000;
		this.trkLeavesAlpha.Name = "trkLeavesAlpha";
		this.trkLeavesAlpha.Size = new System.Drawing.Size(93, 45);
		this.trkLeavesAlpha.TabIndex = 72;
		this.trkLeavesAlpha.TickFrequency = 200;
		this.trkLeavesAlpha.Scroll += new System.EventHandler(trkLeavesAlpha_Scroll);
		this.label152.AutoSize = true;
		this.label152.Location = new System.Drawing.Point(12, 118);
		this.label152.Name = "label152";
		this.label152.Size = new System.Drawing.Size(45, 13);
		this.label152.TabIndex = 74;
		this.label152.Text = "Leaves:";
		this.txtLeavesAlpha.Location = new System.Drawing.Point(149, 115);
		this.txtLeavesAlpha.Name = "txtLeavesAlpha";
		this.txtLeavesAlpha.Size = new System.Drawing.Size(56, 20);
		this.txtLeavesAlpha.TabIndex = 73;
		this.txtLeavesAlpha.TextChanged += new System.EventHandler(txtLeavesAlpha_TextChanged);
		this.trkRainAlpha.Location = new System.Drawing.Point(53, 89);
		this.trkRainAlpha.Maximum = 2000;
		this.trkRainAlpha.Name = "trkRainAlpha";
		this.trkRainAlpha.Size = new System.Drawing.Size(93, 45);
		this.trkRainAlpha.TabIndex = 67;
		this.trkRainAlpha.TickFrequency = 200;
		this.trkRainAlpha.Scroll += new System.EventHandler(trkRainAlpha_Scroll);
		this.trkSnowAlpha.Location = new System.Drawing.Point(53, 64);
		this.trkSnowAlpha.Maximum = 2000;
		this.trkSnowAlpha.Name = "trkSnowAlpha";
		this.trkSnowAlpha.Size = new System.Drawing.Size(93, 45);
		this.trkSnowAlpha.TabIndex = 64;
		this.trkSnowAlpha.TickFrequency = 200;
		this.trkSnowAlpha.Scroll += new System.EventHandler(trkSnowAlpha_Scroll);
		this.label148.AutoSize = true;
		this.label148.Location = new System.Drawing.Point(12, 41);
		this.label148.Name = "label148";
		this.label148.Size = new System.Drawing.Size(32, 13);
		this.label148.TabIndex = 69;
		this.label148.Text = "Dots:";
		this.label149.AutoSize = true;
		this.label149.Location = new System.Drawing.Point(12, 67);
		this.label149.Name = "label149";
		this.label149.Size = new System.Drawing.Size(37, 13);
		this.label149.TabIndex = 70;
		this.label149.Text = "Snow:";
		this.label150.AutoSize = true;
		this.label150.Location = new System.Drawing.Point(12, 92);
		this.label150.Name = "label150";
		this.label150.Size = new System.Drawing.Size(32, 13);
		this.label150.TabIndex = 71;
		this.label150.Text = "Rain:";
		this.label151.AutoSize = true;
		this.label151.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label151.Location = new System.Drawing.Point(12, 13);
		this.label151.Name = "label151";
		this.label151.Size = new System.Drawing.Size(56, 13);
		this.label151.TabIndex = 16;
		this.label151.Text = "Particles";
		this.txtDotsAlpha.Location = new System.Drawing.Point(149, 38);
		this.txtDotsAlpha.Name = "txtDotsAlpha";
		this.txtDotsAlpha.Size = new System.Drawing.Size(56, 20);
		this.txtDotsAlpha.TabIndex = 62;
		this.txtDotsAlpha.TextChanged += new System.EventHandler(txtDotsAlpha_TextChanged);
		this.trkDotsAlpha.Location = new System.Drawing.Point(53, 38);
		this.trkDotsAlpha.Maximum = 2000;
		this.trkDotsAlpha.Name = "trkDotsAlpha";
		this.trkDotsAlpha.Size = new System.Drawing.Size(93, 45);
		this.trkDotsAlpha.TabIndex = 61;
		this.trkDotsAlpha.TickFrequency = 200;
		this.trkDotsAlpha.Scroll += new System.EventHandler(trkDotsAlpha_Scroll);
		this.txtSnowAlpha.Location = new System.Drawing.Point(149, 64);
		this.txtSnowAlpha.Name = "txtSnowAlpha";
		this.txtSnowAlpha.Size = new System.Drawing.Size(56, 20);
		this.txtSnowAlpha.TabIndex = 65;
		this.txtSnowAlpha.TextChanged += new System.EventHandler(txtSnowAlpha_TextChanged);
		this.txtRainAlpha.Location = new System.Drawing.Point(149, 89);
		this.txtRainAlpha.Name = "txtRainAlpha";
		this.txtRainAlpha.Size = new System.Drawing.Size(56, 20);
		this.txtRainAlpha.TabIndex = 68;
		this.txtRainAlpha.TextChanged += new System.EventHandler(txtRainAlpha_TextChanged);
		this.panel27.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel27.Controls.Add(this.trkBloodSat);
		this.panel27.Controls.Add(this.trkBloodAlpha);
		this.panel27.Controls.Add(this.label153);
		this.panel27.Controls.Add(this.txtBloodAlpha);
		this.panel27.Controls.Add(this.label154);
		this.panel27.Controls.Add(this.label155);
		this.panel27.Controls.Add(this.txtBloodSat);
		this.panel27.Location = new System.Drawing.Point(464, 173);
		this.panel27.Name = "panel27";
		this.panel27.Size = new System.Drawing.Size(213, 120);
		this.panel27.TabIndex = 60;
		this.trkBloodSat.Location = new System.Drawing.Point(49, 66);
		this.trkBloodSat.Maximum = 1000;
		this.trkBloodSat.Name = "trkBloodSat";
		this.trkBloodSat.Size = new System.Drawing.Size(98, 45);
		this.trkBloodSat.TabIndex = 55;
		this.trkBloodSat.TickFrequency = 100;
		this.trkBloodSat.Scroll += new System.EventHandler(trkBloodSat_Scroll);
		this.trkBloodAlpha.Location = new System.Drawing.Point(49, 40);
		this.trkBloodAlpha.Maximum = 1000;
		this.trkBloodAlpha.Name = "trkBloodAlpha";
		this.trkBloodAlpha.Size = new System.Drawing.Size(98, 45);
		this.trkBloodAlpha.TabIndex = 52;
		this.trkBloodAlpha.TickFrequency = 100;
		this.trkBloodAlpha.Scroll += new System.EventHandler(trkBloodAlpha_Scroll);
		this.label153.AutoSize = true;
		this.label153.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label153.Location = new System.Drawing.Point(12, 13);
		this.label153.Name = "label153";
		this.label153.Size = new System.Drawing.Size(39, 13);
		this.label153.TabIndex = 16;
		this.label153.Text = "Blood";
		this.txtBloodAlpha.Location = new System.Drawing.Point(149, 40);
		this.txtBloodAlpha.Name = "txtBloodAlpha";
		this.txtBloodAlpha.Size = new System.Drawing.Size(56, 20);
		this.txtBloodAlpha.TabIndex = 53;
		this.txtBloodAlpha.TextChanged += new System.EventHandler(txtBloodAlpha_TextChanged);
		this.label154.AutoSize = true;
		this.label154.Location = new System.Drawing.Point(12, 40);
		this.label154.Name = "label154";
		this.label154.Size = new System.Drawing.Size(37, 13);
		this.label154.TabIndex = 51;
		this.label154.Text = "Alpha:";
		this.label155.AutoSize = true;
		this.label155.Location = new System.Drawing.Point(12, 66);
		this.label155.Name = "label155";
		this.label155.Size = new System.Drawing.Size(26, 13);
		this.label155.TabIndex = 54;
		this.label155.Text = "Sat:";
		this.txtBloodSat.Location = new System.Drawing.Point(149, 66);
		this.txtBloodSat.Name = "txtBloodSat";
		this.txtBloodSat.Size = new System.Drawing.Size(56, 20);
		this.txtBloodSat.TabIndex = 56;
		this.txtBloodSat.TextChanged += new System.EventHandler(txtBloodSat_TextChanged);
		this.panel28.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel28.Controls.Add(this.trkpA);
		this.panel28.Controls.Add(this.label160);
		this.panel28.Controls.Add(this.txtpA);
		this.panel28.Controls.Add(this.trkpB);
		this.panel28.Controls.Add(this.trkpG);
		this.panel28.Controls.Add(this.label156);
		this.panel28.Controls.Add(this.label157);
		this.panel28.Controls.Add(this.label158);
		this.panel28.Controls.Add(this.label159);
		this.panel28.Controls.Add(this.txtpR);
		this.panel28.Controls.Add(this.trkpR);
		this.panel28.Controls.Add(this.txtpG);
		this.panel28.Controls.Add(this.txtpB);
		this.panel28.Location = new System.Drawing.Point(464, 368);
		this.panel28.Name = "panel28";
		this.panel28.Size = new System.Drawing.Size(234, 144);
		this.panel28.TabIndex = 72;
		this.trkpA.Location = new System.Drawing.Point(38, 115);
		this.trkpA.Maximum = 1000;
		this.trkpA.Name = "trkpA";
		this.trkpA.Size = new System.Drawing.Size(123, 45);
		this.trkpA.TabIndex = 72;
		this.trkpA.TickFrequency = 100;
		this.trkpA.Scroll += new System.EventHandler(trkpA_Scroll);
		this.label160.AutoSize = true;
		this.label160.Location = new System.Drawing.Point(12, 118);
		this.label160.Name = "label160";
		this.label160.Size = new System.Drawing.Size(17, 13);
		this.label160.TabIndex = 74;
		this.label160.Text = "A:";
		this.txtpA.Location = new System.Drawing.Point(164, 115);
		this.txtpA.Name = "txtpA";
		this.txtpA.Size = new System.Drawing.Size(56, 20);
		this.txtpA.TabIndex = 73;
		this.txtpA.TextChanged += new System.EventHandler(txtpA_TextChanged);
		this.trkpB.Location = new System.Drawing.Point(38, 89);
		this.trkpB.Maximum = 1000;
		this.trkpB.Name = "trkpB";
		this.trkpB.Size = new System.Drawing.Size(123, 45);
		this.trkpB.TabIndex = 67;
		this.trkpB.TickFrequency = 100;
		this.trkpB.Scroll += new System.EventHandler(trkpB_Scroll);
		this.trkpG.Location = new System.Drawing.Point(38, 64);
		this.trkpG.Maximum = 1000;
		this.trkpG.Name = "trkpG";
		this.trkpG.Size = new System.Drawing.Size(123, 45);
		this.trkpG.TabIndex = 64;
		this.trkpG.TickFrequency = 100;
		this.trkpG.Scroll += new System.EventHandler(trkpG_Scroll);
		this.label156.AutoSize = true;
		this.label156.Location = new System.Drawing.Point(12, 41);
		this.label156.Name = "label156";
		this.label156.Size = new System.Drawing.Size(18, 13);
		this.label156.TabIndex = 69;
		this.label156.Text = "R:";
		this.label157.AutoSize = true;
		this.label157.Location = new System.Drawing.Point(12, 67);
		this.label157.Name = "label157";
		this.label157.Size = new System.Drawing.Size(18, 13);
		this.label157.TabIndex = 70;
		this.label157.Text = "G:";
		this.label158.AutoSize = true;
		this.label158.Location = new System.Drawing.Point(12, 92);
		this.label158.Name = "label158";
		this.label158.Size = new System.Drawing.Size(17, 13);
		this.label158.TabIndex = 71;
		this.label158.Text = "B:";
		this.label159.AutoSize = true;
		this.label159.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label159.Location = new System.Drawing.Point(12, 13);
		this.label159.Name = "label159";
		this.label159.Size = new System.Drawing.Size(67, 13);
		this.label159.TabIndex = 16;
		this.label159.Text = "Parchment";
		this.txtpR.Location = new System.Drawing.Point(164, 38);
		this.txtpR.Name = "txtpR";
		this.txtpR.Size = new System.Drawing.Size(56, 20);
		this.txtpR.TabIndex = 62;
		this.txtpR.TextChanged += new System.EventHandler(txtpR_TextChanged);
		this.trkpR.Location = new System.Drawing.Point(38, 38);
		this.trkpR.Maximum = 1000;
		this.trkpR.Name = "trkpR";
		this.trkpR.Size = new System.Drawing.Size(123, 45);
		this.trkpR.TabIndex = 61;
		this.trkpR.TickFrequency = 100;
		this.trkpR.Scroll += new System.EventHandler(trkpR_Scroll);
		this.txtpG.Location = new System.Drawing.Point(164, 64);
		this.txtpG.Name = "txtpG";
		this.txtpG.Size = new System.Drawing.Size(56, 20);
		this.txtpG.TabIndex = 65;
		this.txtpG.TextChanged += new System.EventHandler(txtpG_TextChanged);
		this.txtpB.Location = new System.Drawing.Point(164, 89);
		this.txtpB.Name = "txtpB";
		this.txtpB.Size = new System.Drawing.Size(56, 20);
		this.txtpB.TabIndex = 68;
		this.txtpB.TextChanged += new System.EventHandler(txtpB_TextChanged);
		this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.fileToolStripMenuItem, this.toolsToolStripMenuItem });
		this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Size = new System.Drawing.Size(1128, 24);
		this.menuStrip1.TabIndex = 93;
		this.menuStrip1.Text = "menuStrip1";
		this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(menuStrip1_ItemClicked);
		this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.openToolStripMenuItem, this.toolStripSeparator1, this.saveToolStripMenuItem, this.saveAsToolStripMenuItem });
		this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
		this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
		this.fileToolStripMenuItem.Text = "File";
		this.openToolStripMenuItem.Name = "openToolStripMenuItem";
		this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
		this.openToolStripMenuItem.Text = "Open...";
		this.openToolStripMenuItem.Click += new System.EventHandler(openToolStripMenuItem_Click);
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
		this.saveToolStripMenuItem.Enabled = false;
		this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
		this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
		this.saveToolStripMenuItem.Text = "Save";
		this.saveToolStripMenuItem.Click += new System.EventHandler(saveToolStripMenuItem_Click);
		this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
		this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
		this.saveAsToolStripMenuItem.Text = "Save As...";
		this.saveAsToolStripMenuItem.Click += new System.EventHandler(saveAsToolStripMenuItem_Click);
		this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.interpolateParallaxToolStripMenuItem });
		this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
		this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
		this.toolsToolStripMenuItem.Text = "Tools";
		this.interpolateParallaxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.midInclusiveToolStripMenuItem, this.midExclusiveToolStripMenuItem });
		this.interpolateParallaxToolStripMenuItem.Name = "interpolateParallaxToolStripMenuItem";
		this.interpolateParallaxToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
		this.interpolateParallaxToolStripMenuItem.Text = "Interpolate Parallax";
		this.midInclusiveToolStripMenuItem.Name = "midInclusiveToolStripMenuItem";
		this.midInclusiveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.I | System.Windows.Forms.Keys.Control;
		this.midInclusiveToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
		this.midInclusiveToolStripMenuItem.Text = "Include Mid Layers";
		this.midInclusiveToolStripMenuItem.Click += new System.EventHandler(midInclusiveToolStripMenuItem_Click);
		this.midExclusiveToolStripMenuItem.Name = "midExclusiveToolStripMenuItem";
		this.midExclusiveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.E | System.Windows.Forms.Keys.Control;
		this.midExclusiveToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
		this.midExclusiveToolStripMenuItem.Text = "Exclude Mid Layers";
		this.midExclusiveToolStripMenuItem.Click += new System.EventHandler(midExclusiveToolStripMenuItem_Click);
		this.panel29.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel29.Controls.Add(this.trkRainSkewAdjust0);
		this.panel29.Controls.Add(this.label199);
		this.panel29.Controls.Add(this.txtRainSkewAdjust0);
		this.panel29.Controls.Add(this.trkRainSkewBase0);
		this.panel29.Controls.Add(this.trkRainAlpha0);
		this.panel29.Controls.Add(this.label200);
		this.panel29.Controls.Add(this.label201);
		this.panel29.Controls.Add(this.label202);
		this.panel29.Controls.Add(this.label203);
		this.panel29.Controls.Add(this.txtRainStretch0);
		this.panel29.Controls.Add(this.trkRainStretch0);
		this.panel29.Controls.Add(this.txtRainAlpha0);
		this.panel29.Controls.Add(this.txtRainSkewBase0);
		this.panel29.Location = new System.Drawing.Point(6, 8);
		this.panel29.Name = "panel29";
		this.panel29.Size = new System.Drawing.Size(234, 156);
		this.panel29.TabIndex = 75;
		this.trkRainSkewAdjust0.Location = new System.Drawing.Point(55, 115);
		this.trkRainSkewAdjust0.Maximum = 1000;
		this.trkRainSkewAdjust0.Name = "trkRainSkewAdjust0";
		this.trkRainSkewAdjust0.Size = new System.Drawing.Size(106, 45);
		this.trkRainSkewAdjust0.TabIndex = 72;
		this.trkRainSkewAdjust0.TickFrequency = 100;
		this.trkRainSkewAdjust0.Scroll += new System.EventHandler(trkRainSkewAdjust0_Scroll);
		this.label199.AutoSize = true;
		this.label199.Location = new System.Drawing.Point(12, 118);
		this.label199.Name = "label199";
		this.label199.Size = new System.Drawing.Size(46, 13);
		this.label199.TabIndex = 74;
		this.label199.Text = "SkwAdj:";
		this.txtRainSkewAdjust0.Location = new System.Drawing.Point(164, 115);
		this.txtRainSkewAdjust0.Name = "txtRainSkewAdjust0";
		this.txtRainSkewAdjust0.Size = new System.Drawing.Size(56, 20);
		this.txtRainSkewAdjust0.TabIndex = 73;
		this.txtRainSkewAdjust0.TextChanged += new System.EventHandler(txtRainSkewAdjust0_TextChanged);
		this.trkRainSkewBase0.Location = new System.Drawing.Point(55, 89);
		this.trkRainSkewBase0.Maximum = 1000;
		this.trkRainSkewBase0.Name = "trkRainSkewBase0";
		this.trkRainSkewBase0.Size = new System.Drawing.Size(106, 45);
		this.trkRainSkewBase0.TabIndex = 67;
		this.trkRainSkewBase0.TickFrequency = 100;
		this.trkRainSkewBase0.Scroll += new System.EventHandler(trkRainSkewBase0_Scroll);
		this.trkRainAlpha0.Location = new System.Drawing.Point(55, 64);
		this.trkRainAlpha0.Maximum = 1000;
		this.trkRainAlpha0.Name = "trkRainAlpha0";
		this.trkRainAlpha0.Size = new System.Drawing.Size(106, 45);
		this.trkRainAlpha0.TabIndex = 64;
		this.trkRainAlpha0.TickFrequency = 100;
		this.trkRainAlpha0.Scroll += new System.EventHandler(trkRainAlpha0_Scroll);
		this.label200.AutoSize = true;
		this.label200.Location = new System.Drawing.Point(12, 41);
		this.label200.Name = "label200";
		this.label200.Size = new System.Drawing.Size(44, 13);
		this.label200.TabIndex = 69;
		this.label200.Text = "Stretch:";
		this.label201.AutoSize = true;
		this.label201.Location = new System.Drawing.Point(12, 67);
		this.label201.Name = "label201";
		this.label201.Size = new System.Drawing.Size(37, 13);
		this.label201.TabIndex = 70;
		this.label201.Text = "Alpha:";
		this.label202.AutoSize = true;
		this.label202.Location = new System.Drawing.Point(12, 92);
		this.label202.Name = "label202";
		this.label202.Size = new System.Drawing.Size(43, 13);
		this.label202.TabIndex = 71;
		this.label202.Text = "SkwBs:";
		this.label203.AutoSize = true;
		this.label203.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label203.Location = new System.Drawing.Point(12, 13);
		this.label203.Name = "label203";
		this.label203.Size = new System.Drawing.Size(44, 13);
		this.label203.TabIndex = 16;
		this.label203.Text = "Rain 0";
		this.txtRainStretch0.Location = new System.Drawing.Point(164, 38);
		this.txtRainStretch0.Name = "txtRainStretch0";
		this.txtRainStretch0.Size = new System.Drawing.Size(56, 20);
		this.txtRainStretch0.TabIndex = 62;
		this.txtRainStretch0.TextChanged += new System.EventHandler(txtRainStretch0_TextChanged);
		this.trkRainStretch0.Location = new System.Drawing.Point(55, 38);
		this.trkRainStretch0.Maximum = 1000;
		this.trkRainStretch0.Name = "trkRainStretch0";
		this.trkRainStretch0.Size = new System.Drawing.Size(106, 45);
		this.trkRainStretch0.TabIndex = 61;
		this.trkRainStretch0.TickFrequency = 100;
		this.trkRainStretch0.Scroll += new System.EventHandler(trkRainStretch0_Scroll);
		this.txtRainAlpha0.Location = new System.Drawing.Point(164, 64);
		this.txtRainAlpha0.Name = "txtRainAlpha0";
		this.txtRainAlpha0.Size = new System.Drawing.Size(56, 20);
		this.txtRainAlpha0.TabIndex = 65;
		this.txtRainAlpha0.TextChanged += new System.EventHandler(txtRainAlpha0_TextChanged);
		this.txtRainSkewBase0.Location = new System.Drawing.Point(164, 89);
		this.txtRainSkewBase0.Name = "txtRainSkewBase0";
		this.txtRainSkewBase0.Size = new System.Drawing.Size(56, 20);
		this.txtRainSkewBase0.TabIndex = 68;
		this.txtRainSkewBase0.TextChanged += new System.EventHandler(txtRainSkewBase0_TextChanged);
		this.panel30.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel30.Controls.Add(this.trkRainSkewAdjust1);
		this.panel30.Controls.Add(this.label204);
		this.panel30.Controls.Add(this.txtRainSkewAdjust1);
		this.panel30.Controls.Add(this.trkRainSkewBase1);
		this.panel30.Controls.Add(this.trkRainAlpha1);
		this.panel30.Controls.Add(this.label205);
		this.panel30.Controls.Add(this.label206);
		this.panel30.Controls.Add(this.label207);
		this.panel30.Controls.Add(this.label208);
		this.panel30.Controls.Add(this.txtRainStretch1);
		this.panel30.Controls.Add(this.trkRainStretch1);
		this.panel30.Controls.Add(this.txtRainAlpha1);
		this.panel30.Controls.Add(this.txtRainSkewBase1);
		this.panel30.Location = new System.Drawing.Point(6, 170);
		this.panel30.Name = "panel30";
		this.panel30.Size = new System.Drawing.Size(234, 156);
		this.panel30.TabIndex = 76;
		this.trkRainSkewAdjust1.Location = new System.Drawing.Point(55, 115);
		this.trkRainSkewAdjust1.Maximum = 1000;
		this.trkRainSkewAdjust1.Name = "trkRainSkewAdjust1";
		this.trkRainSkewAdjust1.Size = new System.Drawing.Size(106, 45);
		this.trkRainSkewAdjust1.TabIndex = 72;
		this.trkRainSkewAdjust1.TickFrequency = 100;
		this.trkRainSkewAdjust1.Scroll += new System.EventHandler(trkRainSkewAdjust1_Scroll);
		this.label204.AutoSize = true;
		this.label204.Location = new System.Drawing.Point(12, 118);
		this.label204.Name = "label204";
		this.label204.Size = new System.Drawing.Size(46, 13);
		this.label204.TabIndex = 74;
		this.label204.Text = "SkwAdj:";
		this.txtRainSkewAdjust1.Location = new System.Drawing.Point(164, 115);
		this.txtRainSkewAdjust1.Name = "txtRainSkewAdjust1";
		this.txtRainSkewAdjust1.Size = new System.Drawing.Size(56, 20);
		this.txtRainSkewAdjust1.TabIndex = 73;
		this.txtRainSkewAdjust1.TextChanged += new System.EventHandler(txtRainSkewAdjust1_TextChanged);
		this.trkRainSkewBase1.Location = new System.Drawing.Point(55, 89);
		this.trkRainSkewBase1.Maximum = 1000;
		this.trkRainSkewBase1.Name = "trkRainSkewBase1";
		this.trkRainSkewBase1.Size = new System.Drawing.Size(106, 45);
		this.trkRainSkewBase1.TabIndex = 67;
		this.trkRainSkewBase1.TickFrequency = 100;
		this.trkRainSkewBase1.Scroll += new System.EventHandler(trkRainSkewBase1_Scroll);
		this.trkRainAlpha1.Location = new System.Drawing.Point(55, 64);
		this.trkRainAlpha1.Maximum = 1000;
		this.trkRainAlpha1.Name = "trkRainAlpha1";
		this.trkRainAlpha1.Size = new System.Drawing.Size(106, 45);
		this.trkRainAlpha1.TabIndex = 64;
		this.trkRainAlpha1.TickFrequency = 100;
		this.trkRainAlpha1.Scroll += new System.EventHandler(trkRainAlpha1_Scroll);
		this.label205.AutoSize = true;
		this.label205.Location = new System.Drawing.Point(12, 41);
		this.label205.Name = "label205";
		this.label205.Size = new System.Drawing.Size(44, 13);
		this.label205.TabIndex = 69;
		this.label205.Text = "Stretch:";
		this.label206.AutoSize = true;
		this.label206.Location = new System.Drawing.Point(12, 67);
		this.label206.Name = "label206";
		this.label206.Size = new System.Drawing.Size(37, 13);
		this.label206.TabIndex = 70;
		this.label206.Text = "Alpha:";
		this.label207.AutoSize = true;
		this.label207.Location = new System.Drawing.Point(12, 92);
		this.label207.Name = "label207";
		this.label207.Size = new System.Drawing.Size(43, 13);
		this.label207.TabIndex = 71;
		this.label207.Text = "SkwBs:";
		this.label208.AutoSize = true;
		this.label208.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label208.Location = new System.Drawing.Point(12, 13);
		this.label208.Name = "label208";
		this.label208.Size = new System.Drawing.Size(44, 13);
		this.label208.TabIndex = 16;
		this.label208.Text = "Rain 1";
		this.txtRainStretch1.Location = new System.Drawing.Point(164, 38);
		this.txtRainStretch1.Name = "txtRainStretch1";
		this.txtRainStretch1.Size = new System.Drawing.Size(56, 20);
		this.txtRainStretch1.TabIndex = 62;
		this.txtRainStretch1.TextChanged += new System.EventHandler(txtRainStretch1_TextChanged);
		this.trkRainStretch1.Location = new System.Drawing.Point(55, 38);
		this.trkRainStretch1.Maximum = 1000;
		this.trkRainStretch1.Name = "trkRainStretch1";
		this.trkRainStretch1.Size = new System.Drawing.Size(106, 45);
		this.trkRainStretch1.TabIndex = 61;
		this.trkRainStretch1.TickFrequency = 100;
		this.trkRainStretch1.Scroll += new System.EventHandler(trkRainStretch1_Scroll);
		this.txtRainAlpha1.Location = new System.Drawing.Point(164, 64);
		this.txtRainAlpha1.Name = "txtRainAlpha1";
		this.txtRainAlpha1.Size = new System.Drawing.Size(56, 20);
		this.txtRainAlpha1.TabIndex = 65;
		this.txtRainAlpha1.TextChanged += new System.EventHandler(txtRainAlpha1_TextChanged);
		this.txtRainSkewBase1.Location = new System.Drawing.Point(164, 89);
		this.txtRainSkewBase1.Name = "txtRainSkewBase1";
		this.txtRainSkewBase1.Size = new System.Drawing.Size(56, 20);
		this.txtRainSkewBase1.TabIndex = 68;
		this.txtRainSkewBase1.TextChanged += new System.EventHandler(txtRainSkewBase1_TextChanged);
		this.panel31.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel31.Controls.Add(this.trkRainB0);
		this.panel31.Controls.Add(this.trkRainG0);
		this.panel31.Controls.Add(this.label210);
		this.panel31.Controls.Add(this.label211);
		this.panel31.Controls.Add(this.label212);
		this.panel31.Controls.Add(this.label213);
		this.panel31.Controls.Add(this.txtRainR0);
		this.panel31.Controls.Add(this.trkRainR0);
		this.panel31.Controls.Add(this.txtRainG0);
		this.panel31.Controls.Add(this.txtRainB0);
		this.panel31.Location = new System.Drawing.Point(6, 332);
		this.panel31.Name = "panel31";
		this.panel31.Size = new System.Drawing.Size(234, 126);
		this.panel31.TabIndex = 77;
		this.trkRainB0.Location = new System.Drawing.Point(35, 89);
		this.trkRainB0.Maximum = 1000;
		this.trkRainB0.Minimum = -1000;
		this.trkRainB0.Name = "trkRainB0";
		this.trkRainB0.Size = new System.Drawing.Size(126, 45);
		this.trkRainB0.TabIndex = 67;
		this.trkRainB0.TickFrequency = 100;
		this.trkRainB0.Scroll += new System.EventHandler(trkRainB0_Scroll);
		this.trkRainG0.Location = new System.Drawing.Point(35, 64);
		this.trkRainG0.Maximum = 1000;
		this.trkRainG0.Minimum = -1000;
		this.trkRainG0.Name = "trkRainG0";
		this.trkRainG0.Size = new System.Drawing.Size(126, 45);
		this.trkRainG0.TabIndex = 64;
		this.trkRainG0.TickFrequency = 100;
		this.trkRainG0.Scroll += new System.EventHandler(trkRainG0_Scroll);
		this.label210.AutoSize = true;
		this.label210.Location = new System.Drawing.Point(12, 41);
		this.label210.Name = "label210";
		this.label210.Size = new System.Drawing.Size(18, 13);
		this.label210.TabIndex = 69;
		this.label210.Text = "R:";
		this.label211.AutoSize = true;
		this.label211.Location = new System.Drawing.Point(12, 67);
		this.label211.Name = "label211";
		this.label211.Size = new System.Drawing.Size(18, 13);
		this.label211.TabIndex = 70;
		this.label211.Text = "G:";
		this.label212.AutoSize = true;
		this.label212.Location = new System.Drawing.Point(12, 92);
		this.label212.Name = "label212";
		this.label212.Size = new System.Drawing.Size(17, 13);
		this.label212.TabIndex = 71;
		this.label212.Text = "B:";
		this.label213.AutoSize = true;
		this.label213.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label213.Location = new System.Drawing.Point(12, 13);
		this.label213.Name = "label213";
		this.label213.Size = new System.Drawing.Size(77, 13);
		this.label213.TabIndex = 16;
		this.label213.Text = "Rain Color 0";
		this.txtRainR0.Location = new System.Drawing.Point(164, 38);
		this.txtRainR0.Name = "txtRainR0";
		this.txtRainR0.Size = new System.Drawing.Size(56, 20);
		this.txtRainR0.TabIndex = 62;
		this.txtRainR0.TextChanged += new System.EventHandler(txtRainR0_TextChanged);
		this.trkRainR0.Location = new System.Drawing.Point(35, 38);
		this.trkRainR0.Maximum = 1000;
		this.trkRainR0.Minimum = -1000;
		this.trkRainR0.Name = "trkRainR0";
		this.trkRainR0.Size = new System.Drawing.Size(126, 45);
		this.trkRainR0.TabIndex = 61;
		this.trkRainR0.TickFrequency = 100;
		this.trkRainR0.Scroll += new System.EventHandler(trkRainR0_Scroll);
		this.txtRainG0.Location = new System.Drawing.Point(164, 64);
		this.txtRainG0.Name = "txtRainG0";
		this.txtRainG0.Size = new System.Drawing.Size(56, 20);
		this.txtRainG0.TabIndex = 65;
		this.txtRainG0.TextChanged += new System.EventHandler(txtRainG0_TextChanged);
		this.txtRainB0.Location = new System.Drawing.Point(164, 89);
		this.txtRainB0.Name = "txtRainB0";
		this.txtRainB0.Size = new System.Drawing.Size(56, 20);
		this.txtRainB0.TabIndex = 68;
		this.txtRainB0.TextChanged += new System.EventHandler(txtRainB0_TextChanged);
		this.tbPanels.Controls.Add(this.tabPage1);
		this.tbPanels.Controls.Add(this.tabPage2);
		this.tbPanels.Controls.Add(this.tabPage3);
		this.tbPanels.Controls.Add(this.tabPage4);
		this.tbPanels.Location = new System.Drawing.Point(243, 27);
		this.tbPanels.Name = "tbPanels";
		this.tbPanels.SelectedIndex = 0;
		this.tbPanels.Size = new System.Drawing.Size(887, 710);
		this.tbPanels.TabIndex = 94;
		this.tabPage1.Controls.Add(this.panel19);
		this.tabPage1.Controls.Add(this.panel18);
		this.tabPage1.Controls.Add(this.panel17);
		this.tabPage1.Controls.Add(this.panel16);
		this.tabPage1.Controls.Add(this.panel15);
		this.tabPage1.Controls.Add(this.panel14);
		this.tabPage1.Controls.Add(this.panel13);
		this.tabPage1.Controls.Add(this.panel12);
		this.tabPage1.Location = new System.Drawing.Point(4, 22);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage1.Size = new System.Drawing.Size(879, 684);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "Indoors";
		this.tabPage1.UseVisualStyleBackColor = true;
		this.tabPage2.Controls.Add(this.panel39);
		this.tabPage2.Controls.Add(this.panel1);
		this.tabPage2.Controls.Add(this.panel2);
		this.tabPage2.Controls.Add(this.panel3);
		this.tabPage2.Controls.Add(this.panel4);
		this.tabPage2.Controls.Add(this.panel5);
		this.tabPage2.Controls.Add(this.panel6);
		this.tabPage2.Controls.Add(this.panel7);
		this.tabPage2.Controls.Add(this.panel8);
		this.tabPage2.Controls.Add(this.panel9);
		this.tabPage2.Controls.Add(this.panel10);
		this.tabPage2.Controls.Add(this.panel11);
		this.tabPage2.Location = new System.Drawing.Point(4, 22);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage2.Size = new System.Drawing.Size(879, 684);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "Outdoors";
		this.tabPage2.UseVisualStyleBackColor = true;
		this.panel39.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel39.Controls.Add(this.txtBBBG);
		this.panel39.Controls.Add(this.txtBGBG);
		this.panel39.Controls.Add(this.txtBRBG);
		this.panel39.Controls.Add(this.trkGammaBG);
		this.panel39.Controls.Add(this.txtGammaBG);
		this.panel39.Controls.Add(this.label250);
		this.panel39.Controls.Add(this.trkBriteBG);
		this.panel39.Controls.Add(this.txtBriteBG);
		this.panel39.Controls.Add(this.label251);
		this.panel39.Controls.Add(this.label252);
		this.panel39.Controls.Add(this.trkTintBG);
		this.panel39.Controls.Add(this.txtTintBG);
		this.panel39.Controls.Add(this.label253);
		this.panel39.Controls.Add(this.trkSatBG);
		this.panel39.Controls.Add(this.txtSatBG);
		this.panel39.Controls.Add(this.label254);
		this.panel39.Controls.Add(this.trkBBG);
		this.panel39.Controls.Add(this.txtBBG);
		this.panel39.Controls.Add(this.label255);
		this.panel39.Controls.Add(this.trkGBG);
		this.panel39.Controls.Add(this.txtGBG);
		this.panel39.Controls.Add(this.label256);
		this.panel39.Controls.Add(this.trkRBG);
		this.panel39.Controls.Add(this.txtRBG);
		this.panel39.Controls.Add(this.label257);
		this.panel39.Location = new System.Drawing.Point(6, 8);
		this.panel39.Name = "panel39";
		this.panel39.Size = new System.Drawing.Size(213, 220);
		this.panel39.TabIndex = 29;
		this.trkGammaBG.Location = new System.Drawing.Point(36, 189);
		this.trkGammaBG.Maximum = 1000;
		this.trkGammaBG.Minimum = -1000;
		this.trkGammaBG.Name = "trkGammaBG";
		this.trkGammaBG.Size = new System.Drawing.Size(104, 45);
		this.trkGammaBG.TabIndex = 27;
		this.trkGammaBG.TickFrequency = 200;
		this.trkGammaBG.Scroll += new System.EventHandler(trkGammaBG_Scroll);
		this.txtGammaBG.Location = new System.Drawing.Point(147, 189);
		this.txtGammaBG.Name = "txtGammaBG";
		this.txtGammaBG.Size = new System.Drawing.Size(56, 20);
		this.txtGammaBG.TabIndex = 28;
		this.txtGammaBG.TextChanged += new System.EventHandler(txtGammaBG_TextChanged);
		this.label250.AutoSize = true;
		this.label250.Location = new System.Drawing.Point(12, 189);
		this.label250.Name = "label250";
		this.label250.Size = new System.Drawing.Size(26, 13);
		this.label250.TabIndex = 26;
		this.label250.Text = "Gm:";
		this.trkBriteBG.Location = new System.Drawing.Point(36, 163);
		this.trkBriteBG.Maximum = 1000;
		this.trkBriteBG.Name = "trkBriteBG";
		this.trkBriteBG.Size = new System.Drawing.Size(104, 45);
		this.trkBriteBG.TabIndex = 24;
		this.trkBriteBG.TickFrequency = 100;
		this.trkBriteBG.Scroll += new System.EventHandler(trkBriteBG_Scroll);
		this.txtBriteBG.Location = new System.Drawing.Point(147, 163);
		this.txtBriteBG.Name = "txtBriteBG";
		this.txtBriteBG.Size = new System.Drawing.Size(56, 20);
		this.txtBriteBG.TabIndex = 25;
		this.txtBriteBG.TextChanged += new System.EventHandler(txtBriteBG_TextChanged);
		this.label251.AutoSize = true;
		this.label251.Location = new System.Drawing.Point(12, 163);
		this.label251.Name = "label251";
		this.label251.Size = new System.Drawing.Size(25, 13);
		this.label251.TabIndex = 23;
		this.label251.Text = "Brit:";
		this.label252.AutoSize = true;
		this.label252.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label252.Location = new System.Drawing.Point(12, 13);
		this.label252.Name = "label252";
		this.label252.Size = new System.Drawing.Size(24, 13);
		this.label252.TabIndex = 16;
		this.label252.Text = "BG";
		this.label252.Click += new System.EventHandler(label252_Click);
		this.trkTintBG.Location = new System.Drawing.Point(36, 137);
		this.trkTintBG.Maximum = 1000;
		this.trkTintBG.Name = "trkTintBG";
		this.trkTintBG.Size = new System.Drawing.Size(104, 45);
		this.trkTintBG.TabIndex = 14;
		this.trkTintBG.TickFrequency = 100;
		this.trkTintBG.Scroll += new System.EventHandler(trkTintBG_Scroll);
		this.txtTintBG.Location = new System.Drawing.Point(147, 137);
		this.txtTintBG.Name = "txtTintBG";
		this.txtTintBG.Size = new System.Drawing.Size(56, 20);
		this.txtTintBG.TabIndex = 15;
		this.txtTintBG.TextChanged += new System.EventHandler(txtTintBG_TextChanged);
		this.label253.AutoSize = true;
		this.label253.Location = new System.Drawing.Point(12, 137);
		this.label253.Name = "label253";
		this.label253.Size = new System.Drawing.Size(28, 13);
		this.label253.TabIndex = 13;
		this.label253.Text = "Tint:";
		this.trkSatBG.Location = new System.Drawing.Point(36, 111);
		this.trkSatBG.Maximum = 1000;
		this.trkSatBG.Name = "trkSatBG";
		this.trkSatBG.Size = new System.Drawing.Size(104, 45);
		this.trkSatBG.TabIndex = 11;
		this.trkSatBG.TickFrequency = 100;
		this.trkSatBG.Scroll += new System.EventHandler(trkSatBG_Scroll);
		this.txtSatBG.Location = new System.Drawing.Point(147, 111);
		this.txtSatBG.Name = "txtSatBG";
		this.txtSatBG.Size = new System.Drawing.Size(56, 20);
		this.txtSatBG.TabIndex = 12;
		this.txtSatBG.TextChanged += new System.EventHandler(txtSatBG_TextChanged);
		this.label254.AutoSize = true;
		this.label254.Location = new System.Drawing.Point(12, 111);
		this.label254.Name = "label254";
		this.label254.Size = new System.Drawing.Size(26, 13);
		this.label254.TabIndex = 10;
		this.label254.Text = "Sat:";
		this.trkBBG.Location = new System.Drawing.Point(36, 85);
		this.trkBBG.Maximum = 1000;
		this.trkBBG.Name = "trkBBG";
		this.trkBBG.Size = new System.Drawing.Size(85, 45);
		this.trkBBG.TabIndex = 8;
		this.trkBBG.TickFrequency = 100;
		this.trkBBG.Scroll += new System.EventHandler(trkBBG_Scroll);
		this.txtBBG.Location = new System.Drawing.Point(127, 85);
		this.txtBBG.Name = "txtBBG";
		this.txtBBG.Size = new System.Drawing.Size(35, 20);
		this.txtBBG.TabIndex = 9;
		this.txtBBG.TextChanged += new System.EventHandler(txtBBG_TextChanged);
		this.label255.AutoSize = true;
		this.label255.Location = new System.Drawing.Point(12, 85);
		this.label255.Name = "label255";
		this.label255.Size = new System.Drawing.Size(17, 13);
		this.label255.TabIndex = 7;
		this.label255.Text = "B:";
		this.trkGBG.Location = new System.Drawing.Point(36, 60);
		this.trkGBG.Maximum = 1000;
		this.trkGBG.Name = "trkGBG";
		this.trkGBG.Size = new System.Drawing.Size(85, 45);
		this.trkGBG.TabIndex = 5;
		this.trkGBG.TickFrequency = 100;
		this.trkGBG.Scroll += new System.EventHandler(trkGBG_Scroll);
		this.txtGBG.Location = new System.Drawing.Point(127, 60);
		this.txtGBG.Name = "txtGBG";
		this.txtGBG.Size = new System.Drawing.Size(35, 20);
		this.txtGBG.TabIndex = 6;
		this.txtGBG.TextChanged += new System.EventHandler(txtGBG_TextChanged);
		this.label256.AutoSize = true;
		this.label256.Location = new System.Drawing.Point(12, 60);
		this.label256.Name = "label256";
		this.label256.Size = new System.Drawing.Size(18, 13);
		this.label256.TabIndex = 4;
		this.label256.Text = "G:";
		this.trkRBG.Location = new System.Drawing.Point(36, 34);
		this.trkRBG.Maximum = 1000;
		this.trkRBG.Name = "trkRBG";
		this.trkRBG.Size = new System.Drawing.Size(85, 45);
		this.trkRBG.TabIndex = 2;
		this.trkRBG.TickFrequency = 100;
		this.trkRBG.Scroll += new System.EventHandler(trkRBG_Scroll);
		this.txtRBG.Location = new System.Drawing.Point(127, 34);
		this.txtRBG.Name = "txtRBG";
		this.txtRBG.Size = new System.Drawing.Size(35, 20);
		this.txtRBG.TabIndex = 3;
		this.txtRBG.TextChanged += new System.EventHandler(txtRBG_TextChanged);
		this.label257.AutoSize = true;
		this.label257.Location = new System.Drawing.Point(12, 34);
		this.label257.Name = "label257";
		this.label257.Size = new System.Drawing.Size(18, 13);
		this.label257.TabIndex = 1;
		this.label257.Text = "R:";
		this.tabPage3.Controls.Add(this.panel38);
		this.tabPage3.Controls.Add(this.panel37);
		this.tabPage3.Controls.Add(this.panel36);
		this.tabPage3.Controls.Add(this.panel35);
		this.tabPage3.Controls.Add(this.panel34);
		this.tabPage3.Controls.Add(this.panel33);
		this.tabPage3.Controls.Add(this.panel32);
		this.tabPage3.Controls.Add(this.panel29);
		this.tabPage3.Controls.Add(this.panel31);
		this.tabPage3.Controls.Add(this.panel30);
		this.tabPage3.Location = new System.Drawing.Point(4, 22);
		this.tabPage3.Name = "tabPage3";
		this.tabPage3.Size = new System.Drawing.Size(879, 684);
		this.tabPage3.TabIndex = 2;
		this.tabPage3.Text = "Rain";
		this.tabPage3.UseVisualStyleBackColor = true;
		this.panel38.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel38.Controls.Add(this.label249);
		this.panel38.Controls.Add(this.txtRainGamma3);
		this.panel38.Controls.Add(this.trkRainGamma3);
		this.panel38.Controls.Add(this.label248);
		this.panel38.Controls.Add(this.txtRainGamma2);
		this.panel38.Controls.Add(this.trkRainGamma2);
		this.panel38.Controls.Add(this.label247);
		this.panel38.Controls.Add(this.txtRainGamma1);
		this.panel38.Controls.Add(this.trkRainGamma1);
		this.panel38.Controls.Add(this.label246);
		this.panel38.Location = new System.Drawing.Point(486, 332);
		this.panel38.Name = "panel38";
		this.panel38.Size = new System.Drawing.Size(234, 134);
		this.panel38.TabIndex = 102;
		this.label249.AutoSize = true;
		this.label249.Location = new System.Drawing.Point(13, 96);
		this.label249.Name = "label249";
		this.label249.Size = new System.Drawing.Size(16, 13);
		this.label249.TabIndex = 78;
		this.label249.Text = "3:";
		this.txtRainGamma3.Location = new System.Drawing.Point(165, 93);
		this.txtRainGamma3.Name = "txtRainGamma3";
		this.txtRainGamma3.Size = new System.Drawing.Size(56, 20);
		this.txtRainGamma3.TabIndex = 77;
		this.txtRainGamma3.TextChanged += new System.EventHandler(textBox2_TextChanged);
		this.trkRainGamma3.Location = new System.Drawing.Point(36, 93);
		this.trkRainGamma3.Maximum = 1000;
		this.trkRainGamma3.Minimum = -1000;
		this.trkRainGamma3.Name = "trkRainGamma3";
		this.trkRainGamma3.Size = new System.Drawing.Size(126, 45);
		this.trkRainGamma3.TabIndex = 76;
		this.trkRainGamma3.TickFrequency = 100;
		this.trkRainGamma3.Scroll += new System.EventHandler(trkRainGamma3_Scroll);
		this.label248.AutoSize = true;
		this.label248.Location = new System.Drawing.Point(13, 70);
		this.label248.Name = "label248";
		this.label248.Size = new System.Drawing.Size(16, 13);
		this.label248.TabIndex = 75;
		this.label248.Text = "2:";
		this.txtRainGamma2.Location = new System.Drawing.Point(165, 67);
		this.txtRainGamma2.Name = "txtRainGamma2";
		this.txtRainGamma2.Size = new System.Drawing.Size(56, 20);
		this.txtRainGamma2.TabIndex = 74;
		this.txtRainGamma2.TextChanged += new System.EventHandler(txtRainGamma2_TextChanged);
		this.trkRainGamma2.Location = new System.Drawing.Point(36, 67);
		this.trkRainGamma2.Maximum = 1000;
		this.trkRainGamma2.Minimum = -1000;
		this.trkRainGamma2.Name = "trkRainGamma2";
		this.trkRainGamma2.Size = new System.Drawing.Size(126, 45);
		this.trkRainGamma2.TabIndex = 73;
		this.trkRainGamma2.TickFrequency = 100;
		this.trkRainGamma2.Scroll += new System.EventHandler(trkRainGamma2_Scroll);
		this.label247.AutoSize = true;
		this.label247.Location = new System.Drawing.Point(13, 44);
		this.label247.Name = "label247";
		this.label247.Size = new System.Drawing.Size(16, 13);
		this.label247.TabIndex = 72;
		this.label247.Text = "1:";
		this.txtRainGamma1.Location = new System.Drawing.Point(165, 41);
		this.txtRainGamma1.Name = "txtRainGamma1";
		this.txtRainGamma1.Size = new System.Drawing.Size(56, 20);
		this.txtRainGamma1.TabIndex = 71;
		this.txtRainGamma1.TextChanged += new System.EventHandler(txtRainGamma1_TextChanged);
		this.trkRainGamma1.Location = new System.Drawing.Point(36, 41);
		this.trkRainGamma1.Maximum = 1000;
		this.trkRainGamma1.Minimum = -1000;
		this.trkRainGamma1.Name = "trkRainGamma1";
		this.trkRainGamma1.Size = new System.Drawing.Size(126, 45);
		this.trkRainGamma1.TabIndex = 70;
		this.trkRainGamma1.TickFrequency = 100;
		this.trkRainGamma1.Scroll += new System.EventHandler(trkRainGamma1_Scroll);
		this.label246.AutoSize = true;
		this.label246.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label246.Location = new System.Drawing.Point(12, 13);
		this.label246.Name = "label246";
		this.label246.Size = new System.Drawing.Size(78, 13);
		this.label246.TabIndex = 17;
		this.label246.Text = "Rain Gamma";
		this.panel37.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel37.Controls.Add(this.trkRefractRainB);
		this.panel37.Controls.Add(this.trkRefractRainG);
		this.panel37.Controls.Add(this.label242);
		this.panel37.Controls.Add(this.label243);
		this.panel37.Controls.Add(this.label244);
		this.panel37.Controls.Add(this.txtRefractRainR);
		this.panel37.Controls.Add(this.trkRefractRainR);
		this.panel37.Controls.Add(this.txtRefractRainG);
		this.panel37.Controls.Add(this.txtRefractRainB);
		this.panel37.Controls.Add(this.label241);
		this.panel37.Controls.Add(this.txtRefractRainGlow);
		this.panel37.Controls.Add(this.trkRefractRainGlow);
		this.panel37.Controls.Add(this.label240);
		this.panel37.Controls.Add(this.txtRefractRainGlimmer);
		this.panel37.Controls.Add(this.trkRefractRainGlimmer);
		this.panel37.Controls.Add(this.label239);
		this.panel37.Controls.Add(this.txtRefractRainDark);
		this.panel37.Controls.Add(this.trkRefractRainDark);
		this.panel37.Controls.Add(this.label237);
		this.panel37.Controls.Add(this.label238);
		this.panel37.Controls.Add(this.txtRefractRainBrite);
		this.panel37.Controls.Add(this.trkRefractRainBrite);
		this.panel37.Location = new System.Drawing.Point(6, 464);
		this.panel37.Name = "panel37";
		this.panel37.Size = new System.Drawing.Size(474, 176);
		this.panel37.TabIndex = 101;
		this.trkRefractRainB.Location = new System.Drawing.Point(276, 93);
		this.trkRefractRainB.Maximum = 1000;
		this.trkRefractRainB.Minimum = -1000;
		this.trkRefractRainB.Name = "trkRefractRainB";
		this.trkRefractRainB.Size = new System.Drawing.Size(126, 45);
		this.trkRefractRainB.TabIndex = 118;
		this.trkRefractRainB.TickFrequency = 100;
		this.trkRefractRainB.Scroll += new System.EventHandler(trkRefractRainB_Scroll);
		this.trkRefractRainG.Location = new System.Drawing.Point(276, 68);
		this.trkRefractRainG.Maximum = 1000;
		this.trkRefractRainG.Minimum = -1000;
		this.trkRefractRainG.Name = "trkRefractRainG";
		this.trkRefractRainG.Size = new System.Drawing.Size(126, 45);
		this.trkRefractRainG.TabIndex = 116;
		this.trkRefractRainG.TickFrequency = 100;
		this.trkRefractRainG.Scroll += new System.EventHandler(trkRefractRainG_Scroll);
		this.label242.AutoSize = true;
		this.label242.Location = new System.Drawing.Point(253, 45);
		this.label242.Name = "label242";
		this.label242.Size = new System.Drawing.Size(18, 13);
		this.label242.TabIndex = 120;
		this.label242.Text = "R:";
		this.label243.AutoSize = true;
		this.label243.Location = new System.Drawing.Point(253, 71);
		this.label243.Name = "label243";
		this.label243.Size = new System.Drawing.Size(18, 13);
		this.label243.TabIndex = 121;
		this.label243.Text = "G:";
		this.label244.AutoSize = true;
		this.label244.Location = new System.Drawing.Point(253, 96);
		this.label244.Name = "label244";
		this.label244.Size = new System.Drawing.Size(17, 13);
		this.label244.TabIndex = 122;
		this.label244.Text = "B:";
		this.txtRefractRainR.Location = new System.Drawing.Point(405, 42);
		this.txtRefractRainR.Name = "txtRefractRainR";
		this.txtRefractRainR.Size = new System.Drawing.Size(56, 20);
		this.txtRefractRainR.TabIndex = 115;
		this.txtRefractRainR.TextChanged += new System.EventHandler(txtRefractRainR_TextChanged);
		this.trkRefractRainR.Location = new System.Drawing.Point(276, 42);
		this.trkRefractRainR.Maximum = 1000;
		this.trkRefractRainR.Minimum = -1000;
		this.trkRefractRainR.Name = "trkRefractRainR";
		this.trkRefractRainR.Size = new System.Drawing.Size(126, 45);
		this.trkRefractRainR.TabIndex = 114;
		this.trkRefractRainR.TickFrequency = 100;
		this.trkRefractRainR.Scroll += new System.EventHandler(trkRefractRainR_Scroll);
		this.txtRefractRainG.Location = new System.Drawing.Point(405, 68);
		this.txtRefractRainG.Name = "txtRefractRainG";
		this.txtRefractRainG.Size = new System.Drawing.Size(56, 20);
		this.txtRefractRainG.TabIndex = 117;
		this.txtRefractRainG.TextChanged += new System.EventHandler(txtRefractRainG_TextChanged);
		this.txtRefractRainB.Location = new System.Drawing.Point(405, 93);
		this.txtRefractRainB.Name = "txtRefractRainB";
		this.txtRefractRainB.Size = new System.Drawing.Size(56, 20);
		this.txtRefractRainB.TabIndex = 119;
		this.txtRefractRainB.TextChanged += new System.EventHandler(txtRefractRainB_TextChanged);
		this.label241.AutoSize = true;
		this.label241.Location = new System.Drawing.Point(12, 138);
		this.label241.Name = "label241";
		this.label241.Size = new System.Drawing.Size(34, 13);
		this.label241.TabIndex = 113;
		this.label241.Text = "Glow:";
		this.txtRefractRainGlow.Location = new System.Drawing.Point(178, 135);
		this.txtRefractRainGlow.Name = "txtRefractRainGlow";
		this.txtRefractRainGlow.Size = new System.Drawing.Size(56, 20);
		this.txtRefractRainGlow.TabIndex = 112;
		this.txtRefractRainGlow.TextChanged += new System.EventHandler(txtRefractRainGlow_TextChanged);
		this.trkRefractRainGlow.Location = new System.Drawing.Point(69, 135);
		this.trkRefractRainGlow.Maximum = 1000;
		this.trkRefractRainGlow.Name = "trkRefractRainGlow";
		this.trkRefractRainGlow.Size = new System.Drawing.Size(106, 45);
		this.trkRefractRainGlow.TabIndex = 111;
		this.trkRefractRainGlow.TickFrequency = 100;
		this.trkRefractRainGlow.Scroll += new System.EventHandler(trkRefractRainGlow_Scroll);
		this.label240.AutoSize = true;
		this.label240.Location = new System.Drawing.Point(12, 107);
		this.label240.Name = "label240";
		this.label240.Size = new System.Drawing.Size(47, 13);
		this.label240.TabIndex = 110;
		this.label240.Text = "Glimmer:";
		this.txtRefractRainGlimmer.Location = new System.Drawing.Point(178, 104);
		this.txtRefractRainGlimmer.Name = "txtRefractRainGlimmer";
		this.txtRefractRainGlimmer.Size = new System.Drawing.Size(56, 20);
		this.txtRefractRainGlimmer.TabIndex = 109;
		this.txtRefractRainGlimmer.TextChanged += new System.EventHandler(txtRefractRainGlimmer_TextChanged);
		this.trkRefractRainGlimmer.Location = new System.Drawing.Point(69, 104);
		this.trkRefractRainGlimmer.Maximum = 1000;
		this.trkRefractRainGlimmer.Name = "trkRefractRainGlimmer";
		this.trkRefractRainGlimmer.Size = new System.Drawing.Size(106, 45);
		this.trkRefractRainGlimmer.TabIndex = 108;
		this.trkRefractRainGlimmer.TickFrequency = 100;
		this.trkRefractRainGlimmer.Scroll += new System.EventHandler(trkRefractRainGlimmer_Scroll);
		this.label239.AutoSize = true;
		this.label239.Location = new System.Drawing.Point(12, 76);
		this.label239.Name = "label239";
		this.label239.Size = new System.Drawing.Size(33, 13);
		this.label239.TabIndex = 107;
		this.label239.Text = "Dark:";
		this.txtRefractRainDark.Location = new System.Drawing.Point(178, 73);
		this.txtRefractRainDark.Name = "txtRefractRainDark";
		this.txtRefractRainDark.Size = new System.Drawing.Size(56, 20);
		this.txtRefractRainDark.TabIndex = 106;
		this.txtRefractRainDark.TextChanged += new System.EventHandler(txtRefractRainDark_TextChanged);
		this.trkRefractRainDark.Location = new System.Drawing.Point(69, 73);
		this.trkRefractRainDark.Maximum = 1000;
		this.trkRefractRainDark.Name = "trkRefractRainDark";
		this.trkRefractRainDark.Size = new System.Drawing.Size(106, 45);
		this.trkRefractRainDark.TabIndex = 105;
		this.trkRefractRainDark.TickFrequency = 100;
		this.trkRefractRainDark.Scroll += new System.EventHandler(trkRefractRainDark_Scroll);
		this.label237.AutoSize = true;
		this.label237.Location = new System.Drawing.Point(12, 45);
		this.label237.Name = "label237";
		this.label237.Size = new System.Drawing.Size(31, 13);
		this.label237.TabIndex = 104;
		this.label237.Text = "Brite:";
		this.label238.AutoSize = true;
		this.label238.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label238.Location = new System.Drawing.Point(12, 17);
		this.label238.Name = "label238";
		this.label238.Size = new System.Drawing.Size(79, 13);
		this.label238.TabIndex = 101;
		this.label238.Text = "Refract Rain";
		this.txtRefractRainBrite.Location = new System.Drawing.Point(178, 42);
		this.txtRefractRainBrite.Name = "txtRefractRainBrite";
		this.txtRefractRainBrite.Size = new System.Drawing.Size(56, 20);
		this.txtRefractRainBrite.TabIndex = 103;
		this.txtRefractRainBrite.TextChanged += new System.EventHandler(txtRefractRainBrite_TextChanged);
		this.trkRefractRainBrite.Location = new System.Drawing.Point(69, 42);
		this.trkRefractRainBrite.Maximum = 1000;
		this.trkRefractRainBrite.Name = "trkRefractRainBrite";
		this.trkRefractRainBrite.Size = new System.Drawing.Size(106, 45);
		this.trkRefractRainBrite.TabIndex = 102;
		this.trkRefractRainBrite.TickFrequency = 100;
		this.trkRefractRainBrite.Scroll += new System.EventHandler(trkRefractRainBrite_Scroll);
		this.panel36.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel36.Controls.Add(this.trkRainSkewAdjust5);
		this.panel36.Controls.Add(this.label232);
		this.panel36.Controls.Add(this.txtRainSkewAdjust5);
		this.panel36.Controls.Add(this.trkRainSkewBase5);
		this.panel36.Controls.Add(this.trkRainAlpha5);
		this.panel36.Controls.Add(this.label233);
		this.panel36.Controls.Add(this.label234);
		this.panel36.Controls.Add(this.label235);
		this.panel36.Controls.Add(this.label236);
		this.panel36.Controls.Add(this.txtRainStretch5);
		this.panel36.Controls.Add(this.trkRainStretch5);
		this.panel36.Controls.Add(this.txtRainAlpha5);
		this.panel36.Controls.Add(this.txtRainSkewBase5);
		this.panel36.Location = new System.Drawing.Point(486, 170);
		this.panel36.Name = "panel36";
		this.panel36.Size = new System.Drawing.Size(234, 156);
		this.panel36.TabIndex = 78;
		this.trkRainSkewAdjust5.Location = new System.Drawing.Point(55, 115);
		this.trkRainSkewAdjust5.Maximum = 1000;
		this.trkRainSkewAdjust5.Name = "trkRainSkewAdjust5";
		this.trkRainSkewAdjust5.Size = new System.Drawing.Size(106, 45);
		this.trkRainSkewAdjust5.TabIndex = 72;
		this.trkRainSkewAdjust5.TickFrequency = 100;
		this.trkRainSkewAdjust5.Scroll += new System.EventHandler(trkRainSkewAdjust5_Scroll);
		this.label232.AutoSize = true;
		this.label232.Location = new System.Drawing.Point(12, 118);
		this.label232.Name = "label232";
		this.label232.Size = new System.Drawing.Size(46, 13);
		this.label232.TabIndex = 74;
		this.label232.Text = "SkwAdj:";
		this.txtRainSkewAdjust5.Location = new System.Drawing.Point(164, 115);
		this.txtRainSkewAdjust5.Name = "txtRainSkewAdjust5";
		this.txtRainSkewAdjust5.Size = new System.Drawing.Size(56, 20);
		this.txtRainSkewAdjust5.TabIndex = 73;
		this.txtRainSkewAdjust5.TextChanged += new System.EventHandler(txtRainSkewAdjust5_TextChanged);
		this.trkRainSkewBase5.Location = new System.Drawing.Point(55, 89);
		this.trkRainSkewBase5.Maximum = 1000;
		this.trkRainSkewBase5.Name = "trkRainSkewBase5";
		this.trkRainSkewBase5.Size = new System.Drawing.Size(106, 45);
		this.trkRainSkewBase5.TabIndex = 67;
		this.trkRainSkewBase5.TickFrequency = 100;
		this.trkRainSkewBase5.Scroll += new System.EventHandler(trkRainSkewBase5_Scroll);
		this.trkRainAlpha5.Location = new System.Drawing.Point(55, 64);
		this.trkRainAlpha5.Maximum = 1000;
		this.trkRainAlpha5.Name = "trkRainAlpha5";
		this.trkRainAlpha5.Size = new System.Drawing.Size(106, 45);
		this.trkRainAlpha5.TabIndex = 64;
		this.trkRainAlpha5.TickFrequency = 100;
		this.trkRainAlpha5.Scroll += new System.EventHandler(trkRainAlpha5_Scroll);
		this.label233.AutoSize = true;
		this.label233.Location = new System.Drawing.Point(12, 41);
		this.label233.Name = "label233";
		this.label233.Size = new System.Drawing.Size(44, 13);
		this.label233.TabIndex = 69;
		this.label233.Text = "Stretch:";
		this.label234.AutoSize = true;
		this.label234.Location = new System.Drawing.Point(12, 67);
		this.label234.Name = "label234";
		this.label234.Size = new System.Drawing.Size(37, 13);
		this.label234.TabIndex = 70;
		this.label234.Text = "Alpha:";
		this.label235.AutoSize = true;
		this.label235.Location = new System.Drawing.Point(12, 92);
		this.label235.Name = "label235";
		this.label235.Size = new System.Drawing.Size(43, 13);
		this.label235.TabIndex = 71;
		this.label235.Text = "SkwBs:";
		this.label236.AutoSize = true;
		this.label236.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label236.Location = new System.Drawing.Point(12, 13);
		this.label236.Name = "label236";
		this.label236.Size = new System.Drawing.Size(44, 13);
		this.label236.TabIndex = 16;
		this.label236.Text = "Rain 5";
		this.txtRainStretch5.Location = new System.Drawing.Point(164, 38);
		this.txtRainStretch5.Name = "txtRainStretch5";
		this.txtRainStretch5.Size = new System.Drawing.Size(56, 20);
		this.txtRainStretch5.TabIndex = 62;
		this.txtRainStretch5.TextChanged += new System.EventHandler(txtRainStretch5_TextChanged);
		this.trkRainStretch5.Location = new System.Drawing.Point(55, 38);
		this.trkRainStretch5.Maximum = 1000;
		this.trkRainStretch5.Name = "trkRainStretch5";
		this.trkRainStretch5.Size = new System.Drawing.Size(106, 45);
		this.trkRainStretch5.TabIndex = 61;
		this.trkRainStretch5.TickFrequency = 100;
		this.trkRainStretch5.Scroll += new System.EventHandler(trkRainStretch5_Scroll);
		this.txtRainAlpha5.Location = new System.Drawing.Point(164, 64);
		this.txtRainAlpha5.Name = "txtRainAlpha5";
		this.txtRainAlpha5.Size = new System.Drawing.Size(56, 20);
		this.txtRainAlpha5.TabIndex = 65;
		this.txtRainAlpha5.TextChanged += new System.EventHandler(txtRainAlpha5_TextChanged);
		this.txtRainSkewBase5.Location = new System.Drawing.Point(164, 89);
		this.txtRainSkewBase5.Name = "txtRainSkewBase5";
		this.txtRainSkewBase5.Size = new System.Drawing.Size(56, 20);
		this.txtRainSkewBase5.TabIndex = 68;
		this.txtRainSkewBase5.TextChanged += new System.EventHandler(txtRainSkewBase5_TextChanged);
		this.panel35.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel35.Controls.Add(this.trkRainSkewAdjust4);
		this.panel35.Controls.Add(this.label227);
		this.panel35.Controls.Add(this.txtRainSkewAdjust4);
		this.panel35.Controls.Add(this.trkRainSkewBase4);
		this.panel35.Controls.Add(this.trkRainAlpha4);
		this.panel35.Controls.Add(this.label228);
		this.panel35.Controls.Add(this.label229);
		this.panel35.Controls.Add(this.label230);
		this.panel35.Controls.Add(this.label231);
		this.panel35.Controls.Add(this.txtRainStretch4);
		this.panel35.Controls.Add(this.trkRainStretch4);
		this.panel35.Controls.Add(this.txtRainAlpha4);
		this.panel35.Controls.Add(this.txtRainSkewBase4);
		this.panel35.Location = new System.Drawing.Point(486, 8);
		this.panel35.Name = "panel35";
		this.panel35.Size = new System.Drawing.Size(234, 156);
		this.panel35.TabIndex = 77;
		this.trkRainSkewAdjust4.Location = new System.Drawing.Point(55, 115);
		this.trkRainSkewAdjust4.Maximum = 1000;
		this.trkRainSkewAdjust4.Name = "trkRainSkewAdjust4";
		this.trkRainSkewAdjust4.Size = new System.Drawing.Size(106, 45);
		this.trkRainSkewAdjust4.TabIndex = 72;
		this.trkRainSkewAdjust4.TickFrequency = 100;
		this.trkRainSkewAdjust4.Scroll += new System.EventHandler(trkRainSkewAdjust4_Scroll);
		this.label227.AutoSize = true;
		this.label227.Location = new System.Drawing.Point(12, 118);
		this.label227.Name = "label227";
		this.label227.Size = new System.Drawing.Size(46, 13);
		this.label227.TabIndex = 74;
		this.label227.Text = "SkwAdj:";
		this.txtRainSkewAdjust4.Location = new System.Drawing.Point(164, 115);
		this.txtRainSkewAdjust4.Name = "txtRainSkewAdjust4";
		this.txtRainSkewAdjust4.Size = new System.Drawing.Size(56, 20);
		this.txtRainSkewAdjust4.TabIndex = 73;
		this.txtRainSkewAdjust4.TextChanged += new System.EventHandler(txtRainSkewAdjust4_TextChanged);
		this.trkRainSkewBase4.Location = new System.Drawing.Point(55, 89);
		this.trkRainSkewBase4.Maximum = 1000;
		this.trkRainSkewBase4.Name = "trkRainSkewBase4";
		this.trkRainSkewBase4.Size = new System.Drawing.Size(106, 45);
		this.trkRainSkewBase4.TabIndex = 67;
		this.trkRainSkewBase4.TickFrequency = 100;
		this.trkRainSkewBase4.Scroll += new System.EventHandler(trkRainSkewBase4_Scroll);
		this.trkRainAlpha4.Location = new System.Drawing.Point(55, 64);
		this.trkRainAlpha4.Maximum = 1000;
		this.trkRainAlpha4.Name = "trkRainAlpha4";
		this.trkRainAlpha4.Size = new System.Drawing.Size(106, 45);
		this.trkRainAlpha4.TabIndex = 64;
		this.trkRainAlpha4.TickFrequency = 100;
		this.trkRainAlpha4.Scroll += new System.EventHandler(trkRainAlpha4_Scroll);
		this.label228.AutoSize = true;
		this.label228.Location = new System.Drawing.Point(12, 41);
		this.label228.Name = "label228";
		this.label228.Size = new System.Drawing.Size(44, 13);
		this.label228.TabIndex = 69;
		this.label228.Text = "Stretch:";
		this.label229.AutoSize = true;
		this.label229.Location = new System.Drawing.Point(12, 67);
		this.label229.Name = "label229";
		this.label229.Size = new System.Drawing.Size(37, 13);
		this.label229.TabIndex = 70;
		this.label229.Text = "Alpha:";
		this.label230.AutoSize = true;
		this.label230.Location = new System.Drawing.Point(12, 92);
		this.label230.Name = "label230";
		this.label230.Size = new System.Drawing.Size(43, 13);
		this.label230.TabIndex = 71;
		this.label230.Text = "SkwBs:";
		this.label231.AutoSize = true;
		this.label231.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label231.Location = new System.Drawing.Point(12, 13);
		this.label231.Name = "label231";
		this.label231.Size = new System.Drawing.Size(44, 13);
		this.label231.TabIndex = 16;
		this.label231.Text = "Rain 4";
		this.txtRainStretch4.Location = new System.Drawing.Point(164, 38);
		this.txtRainStretch4.Name = "txtRainStretch4";
		this.txtRainStretch4.Size = new System.Drawing.Size(56, 20);
		this.txtRainStretch4.TabIndex = 62;
		this.txtRainStretch4.TextChanged += new System.EventHandler(txtRainStretch4_TextChanged);
		this.trkRainStretch4.Location = new System.Drawing.Point(55, 38);
		this.trkRainStretch4.Maximum = 1000;
		this.trkRainStretch4.Name = "trkRainStretch4";
		this.trkRainStretch4.Size = new System.Drawing.Size(106, 45);
		this.trkRainStretch4.TabIndex = 61;
		this.trkRainStretch4.TickFrequency = 100;
		this.trkRainStretch4.Scroll += new System.EventHandler(trkRainStretch4_Scroll);
		this.txtRainAlpha4.Location = new System.Drawing.Point(164, 64);
		this.txtRainAlpha4.Name = "txtRainAlpha4";
		this.txtRainAlpha4.Size = new System.Drawing.Size(56, 20);
		this.txtRainAlpha4.TabIndex = 65;
		this.txtRainAlpha4.TextChanged += new System.EventHandler(txtRainAlpha4_TextChanged);
		this.txtRainSkewBase4.Location = new System.Drawing.Point(164, 89);
		this.txtRainSkewBase4.Name = "txtRainSkewBase4";
		this.txtRainSkewBase4.Size = new System.Drawing.Size(56, 20);
		this.txtRainSkewBase4.TabIndex = 68;
		this.txtRainSkewBase4.TextChanged += new System.EventHandler(txtRainSkewBase4_TextChanged);
		this.panel34.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel34.Controls.Add(this.trkRainB1);
		this.panel34.Controls.Add(this.trkRainG1);
		this.panel34.Controls.Add(this.label223);
		this.panel34.Controls.Add(this.label224);
		this.panel34.Controls.Add(this.label225);
		this.panel34.Controls.Add(this.label226);
		this.panel34.Controls.Add(this.txtRainR1);
		this.panel34.Controls.Add(this.trkRainR1);
		this.panel34.Controls.Add(this.txtRainG1);
		this.panel34.Controls.Add(this.txtRainB1);
		this.panel34.Location = new System.Drawing.Point(246, 332);
		this.panel34.Name = "panel34";
		this.panel34.Size = new System.Drawing.Size(234, 126);
		this.panel34.TabIndex = 78;
		this.trkRainB1.Location = new System.Drawing.Point(35, 89);
		this.trkRainB1.Maximum = 1000;
		this.trkRainB1.Minimum = -1000;
		this.trkRainB1.Name = "trkRainB1";
		this.trkRainB1.Size = new System.Drawing.Size(126, 45);
		this.trkRainB1.TabIndex = 67;
		this.trkRainB1.TickFrequency = 100;
		this.trkRainB1.Scroll += new System.EventHandler(trkRainB1_Scroll);
		this.trkRainG1.Location = new System.Drawing.Point(35, 64);
		this.trkRainG1.Maximum = 1000;
		this.trkRainG1.Minimum = -1000;
		this.trkRainG1.Name = "trkRainG1";
		this.trkRainG1.Size = new System.Drawing.Size(126, 45);
		this.trkRainG1.TabIndex = 64;
		this.trkRainG1.TickFrequency = 100;
		this.trkRainG1.Scroll += new System.EventHandler(trkRainG1_Scroll);
		this.label223.AutoSize = true;
		this.label223.Location = new System.Drawing.Point(12, 41);
		this.label223.Name = "label223";
		this.label223.Size = new System.Drawing.Size(18, 13);
		this.label223.TabIndex = 69;
		this.label223.Text = "R:";
		this.label224.AutoSize = true;
		this.label224.Location = new System.Drawing.Point(12, 67);
		this.label224.Name = "label224";
		this.label224.Size = new System.Drawing.Size(18, 13);
		this.label224.TabIndex = 70;
		this.label224.Text = "G:";
		this.label225.AutoSize = true;
		this.label225.Location = new System.Drawing.Point(12, 92);
		this.label225.Name = "label225";
		this.label225.Size = new System.Drawing.Size(17, 13);
		this.label225.TabIndex = 71;
		this.label225.Text = "B:";
		this.label226.AutoSize = true;
		this.label226.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label226.Location = new System.Drawing.Point(12, 13);
		this.label226.Name = "label226";
		this.label226.Size = new System.Drawing.Size(77, 13);
		this.label226.TabIndex = 16;
		this.label226.Text = "Rain Color 1";
		this.txtRainR1.Location = new System.Drawing.Point(164, 38);
		this.txtRainR1.Name = "txtRainR1";
		this.txtRainR1.Size = new System.Drawing.Size(56, 20);
		this.txtRainR1.TabIndex = 62;
		this.txtRainR1.TextChanged += new System.EventHandler(txtRainR1_TextChanged);
		this.trkRainR1.Location = new System.Drawing.Point(35, 38);
		this.trkRainR1.Maximum = 1000;
		this.trkRainR1.Minimum = -1000;
		this.trkRainR1.Name = "trkRainR1";
		this.trkRainR1.Size = new System.Drawing.Size(126, 45);
		this.trkRainR1.TabIndex = 61;
		this.trkRainR1.TickFrequency = 100;
		this.trkRainR1.Scroll += new System.EventHandler(trkRainR1_Scroll);
		this.txtRainG1.Location = new System.Drawing.Point(164, 64);
		this.txtRainG1.Name = "txtRainG1";
		this.txtRainG1.Size = new System.Drawing.Size(56, 20);
		this.txtRainG1.TabIndex = 65;
		this.txtRainG1.TextChanged += new System.EventHandler(txtRainG1_TextChanged);
		this.txtRainB1.Location = new System.Drawing.Point(164, 89);
		this.txtRainB1.Name = "txtRainB1";
		this.txtRainB1.Size = new System.Drawing.Size(56, 20);
		this.txtRainB1.TabIndex = 68;
		this.txtRainB1.TextChanged += new System.EventHandler(txtRainB1_TextChanged);
		this.panel33.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel33.Controls.Add(this.trkRainSkewAdjust3);
		this.panel33.Controls.Add(this.label218);
		this.panel33.Controls.Add(this.txtRainSkewAdjust3);
		this.panel33.Controls.Add(this.trkRainSkewBase3);
		this.panel33.Controls.Add(this.trkRainAlpha3);
		this.panel33.Controls.Add(this.label219);
		this.panel33.Controls.Add(this.label220);
		this.panel33.Controls.Add(this.label221);
		this.panel33.Controls.Add(this.label222);
		this.panel33.Controls.Add(this.txtRainStretch3);
		this.panel33.Controls.Add(this.trkRainStretch3);
		this.panel33.Controls.Add(this.txtRainAlpha3);
		this.panel33.Controls.Add(this.txtRainSkewBase3);
		this.panel33.Location = new System.Drawing.Point(246, 170);
		this.panel33.Name = "panel33";
		this.panel33.Size = new System.Drawing.Size(234, 156);
		this.panel33.TabIndex = 77;
		this.trkRainSkewAdjust3.Location = new System.Drawing.Point(55, 115);
		this.trkRainSkewAdjust3.Maximum = 1000;
		this.trkRainSkewAdjust3.Name = "trkRainSkewAdjust3";
		this.trkRainSkewAdjust3.Size = new System.Drawing.Size(106, 45);
		this.trkRainSkewAdjust3.TabIndex = 72;
		this.trkRainSkewAdjust3.TickFrequency = 100;
		this.trkRainSkewAdjust3.Scroll += new System.EventHandler(trkRainSkewAdjust3_Scroll);
		this.label218.AutoSize = true;
		this.label218.Location = new System.Drawing.Point(12, 118);
		this.label218.Name = "label218";
		this.label218.Size = new System.Drawing.Size(46, 13);
		this.label218.TabIndex = 74;
		this.label218.Text = "SkwAdj:";
		this.txtRainSkewAdjust3.Location = new System.Drawing.Point(164, 115);
		this.txtRainSkewAdjust3.Name = "txtRainSkewAdjust3";
		this.txtRainSkewAdjust3.Size = new System.Drawing.Size(56, 20);
		this.txtRainSkewAdjust3.TabIndex = 73;
		this.txtRainSkewAdjust3.TextChanged += new System.EventHandler(txtRainSkewAdjust3_TextChanged);
		this.trkRainSkewBase3.Location = new System.Drawing.Point(55, 89);
		this.trkRainSkewBase3.Maximum = 1000;
		this.trkRainSkewBase3.Name = "trkRainSkewBase3";
		this.trkRainSkewBase3.Size = new System.Drawing.Size(106, 45);
		this.trkRainSkewBase3.TabIndex = 67;
		this.trkRainSkewBase3.TickFrequency = 100;
		this.trkRainSkewBase3.Scroll += new System.EventHandler(trkRainSkewBase3_Scroll);
		this.trkRainAlpha3.Location = new System.Drawing.Point(55, 64);
		this.trkRainAlpha3.Maximum = 1000;
		this.trkRainAlpha3.Name = "trkRainAlpha3";
		this.trkRainAlpha3.Size = new System.Drawing.Size(106, 45);
		this.trkRainAlpha3.TabIndex = 64;
		this.trkRainAlpha3.TickFrequency = 100;
		this.trkRainAlpha3.Scroll += new System.EventHandler(trkRainAlpha3_Scroll);
		this.label219.AutoSize = true;
		this.label219.Location = new System.Drawing.Point(12, 41);
		this.label219.Name = "label219";
		this.label219.Size = new System.Drawing.Size(44, 13);
		this.label219.TabIndex = 69;
		this.label219.Text = "Stretch:";
		this.label220.AutoSize = true;
		this.label220.Location = new System.Drawing.Point(12, 67);
		this.label220.Name = "label220";
		this.label220.Size = new System.Drawing.Size(37, 13);
		this.label220.TabIndex = 70;
		this.label220.Text = "Alpha:";
		this.label221.AutoSize = true;
		this.label221.Location = new System.Drawing.Point(12, 92);
		this.label221.Name = "label221";
		this.label221.Size = new System.Drawing.Size(43, 13);
		this.label221.TabIndex = 71;
		this.label221.Text = "SkwBs:";
		this.label222.AutoSize = true;
		this.label222.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label222.Location = new System.Drawing.Point(12, 13);
		this.label222.Name = "label222";
		this.label222.Size = new System.Drawing.Size(44, 13);
		this.label222.TabIndex = 16;
		this.label222.Text = "Rain 3";
		this.txtRainStretch3.Location = new System.Drawing.Point(164, 38);
		this.txtRainStretch3.Name = "txtRainStretch3";
		this.txtRainStretch3.Size = new System.Drawing.Size(56, 20);
		this.txtRainStretch3.TabIndex = 62;
		this.txtRainStretch3.TextChanged += new System.EventHandler(txtRainStretch3_TextChanged);
		this.trkRainStretch3.Location = new System.Drawing.Point(55, 38);
		this.trkRainStretch3.Maximum = 1000;
		this.trkRainStretch3.Name = "trkRainStretch3";
		this.trkRainStretch3.Size = new System.Drawing.Size(106, 45);
		this.trkRainStretch3.TabIndex = 61;
		this.trkRainStretch3.TickFrequency = 100;
		this.trkRainStretch3.Scroll += new System.EventHandler(trkRainStretch3_Scroll);
		this.txtRainAlpha3.Location = new System.Drawing.Point(164, 64);
		this.txtRainAlpha3.Name = "txtRainAlpha3";
		this.txtRainAlpha3.Size = new System.Drawing.Size(56, 20);
		this.txtRainAlpha3.TabIndex = 65;
		this.txtRainAlpha3.TextChanged += new System.EventHandler(txtRainAlpha3_TextChanged);
		this.txtRainSkewBase3.Location = new System.Drawing.Point(164, 89);
		this.txtRainSkewBase3.Name = "txtRainSkewBase3";
		this.txtRainSkewBase3.Size = new System.Drawing.Size(56, 20);
		this.txtRainSkewBase3.TabIndex = 68;
		this.txtRainSkewBase3.TextChanged += new System.EventHandler(txtRainSkewBase3_TextChanged);
		this.panel32.BackColor = System.Drawing.SystemColors.ControlLight;
		this.panel32.Controls.Add(this.trkRainSkewAdjust2);
		this.panel32.Controls.Add(this.label209);
		this.panel32.Controls.Add(this.txtRainSkewAdjust2);
		this.panel32.Controls.Add(this.trkRainSkewBase2);
		this.panel32.Controls.Add(this.trkRainAlpha2);
		this.panel32.Controls.Add(this.label214);
		this.panel32.Controls.Add(this.label215);
		this.panel32.Controls.Add(this.label216);
		this.panel32.Controls.Add(this.label217);
		this.panel32.Controls.Add(this.txtRainStretch2);
		this.panel32.Controls.Add(this.trkRainStretch2);
		this.panel32.Controls.Add(this.txtRainAlpha2);
		this.panel32.Controls.Add(this.txtRainSkewBase2);
		this.panel32.Location = new System.Drawing.Point(246, 8);
		this.panel32.Name = "panel32";
		this.panel32.Size = new System.Drawing.Size(234, 156);
		this.panel32.TabIndex = 76;
		this.trkRainSkewAdjust2.Location = new System.Drawing.Point(55, 115);
		this.trkRainSkewAdjust2.Maximum = 1000;
		this.trkRainSkewAdjust2.Name = "trkRainSkewAdjust2";
		this.trkRainSkewAdjust2.Size = new System.Drawing.Size(106, 45);
		this.trkRainSkewAdjust2.TabIndex = 72;
		this.trkRainSkewAdjust2.TickFrequency = 100;
		this.trkRainSkewAdjust2.Scroll += new System.EventHandler(trkRainSkewAdjust2_Scroll);
		this.label209.AutoSize = true;
		this.label209.Location = new System.Drawing.Point(12, 118);
		this.label209.Name = "label209";
		this.label209.Size = new System.Drawing.Size(46, 13);
		this.label209.TabIndex = 74;
		this.label209.Text = "SkwAdj:";
		this.txtRainSkewAdjust2.Location = new System.Drawing.Point(164, 115);
		this.txtRainSkewAdjust2.Name = "txtRainSkewAdjust2";
		this.txtRainSkewAdjust2.Size = new System.Drawing.Size(56, 20);
		this.txtRainSkewAdjust2.TabIndex = 73;
		this.txtRainSkewAdjust2.TextChanged += new System.EventHandler(txtRainSkewAdjust2_TextChanged);
		this.trkRainSkewBase2.Location = new System.Drawing.Point(55, 89);
		this.trkRainSkewBase2.Maximum = 1000;
		this.trkRainSkewBase2.Name = "trkRainSkewBase2";
		this.trkRainSkewBase2.Size = new System.Drawing.Size(106, 45);
		this.trkRainSkewBase2.TabIndex = 67;
		this.trkRainSkewBase2.TickFrequency = 100;
		this.trkRainSkewBase2.Scroll += new System.EventHandler(trkRainSkewBase2_Scroll);
		this.trkRainAlpha2.Location = new System.Drawing.Point(55, 64);
		this.trkRainAlpha2.Maximum = 1000;
		this.trkRainAlpha2.Name = "trkRainAlpha2";
		this.trkRainAlpha2.Size = new System.Drawing.Size(106, 45);
		this.trkRainAlpha2.TabIndex = 64;
		this.trkRainAlpha2.TickFrequency = 100;
		this.trkRainAlpha2.Scroll += new System.EventHandler(trkRainAlpha2_Scroll);
		this.label214.AutoSize = true;
		this.label214.Location = new System.Drawing.Point(12, 41);
		this.label214.Name = "label214";
		this.label214.Size = new System.Drawing.Size(44, 13);
		this.label214.TabIndex = 69;
		this.label214.Text = "Stretch:";
		this.label215.AutoSize = true;
		this.label215.Location = new System.Drawing.Point(12, 67);
		this.label215.Name = "label215";
		this.label215.Size = new System.Drawing.Size(37, 13);
		this.label215.TabIndex = 70;
		this.label215.Text = "Alpha:";
		this.label216.AutoSize = true;
		this.label216.Location = new System.Drawing.Point(12, 92);
		this.label216.Name = "label216";
		this.label216.Size = new System.Drawing.Size(43, 13);
		this.label216.TabIndex = 71;
		this.label216.Text = "SkwBs:";
		this.label217.AutoSize = true;
		this.label217.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label217.Location = new System.Drawing.Point(12, 13);
		this.label217.Name = "label217";
		this.label217.Size = new System.Drawing.Size(44, 13);
		this.label217.TabIndex = 16;
		this.label217.Text = "Rain 2";
		this.txtRainStretch2.Location = new System.Drawing.Point(164, 38);
		this.txtRainStretch2.Name = "txtRainStretch2";
		this.txtRainStretch2.Size = new System.Drawing.Size(56, 20);
		this.txtRainStretch2.TabIndex = 62;
		this.txtRainStretch2.TextChanged += new System.EventHandler(txtRainStretch2_TextChanged);
		this.trkRainStretch2.Location = new System.Drawing.Point(55, 38);
		this.trkRainStretch2.Maximum = 1000;
		this.trkRainStretch2.Name = "trkRainStretch2";
		this.trkRainStretch2.Size = new System.Drawing.Size(106, 45);
		this.trkRainStretch2.TabIndex = 61;
		this.trkRainStretch2.TickFrequency = 100;
		this.trkRainStretch2.Scroll += new System.EventHandler(trkRainStretch2_Scroll);
		this.txtRainAlpha2.Location = new System.Drawing.Point(164, 64);
		this.txtRainAlpha2.Name = "txtRainAlpha2";
		this.txtRainAlpha2.Size = new System.Drawing.Size(56, 20);
		this.txtRainAlpha2.TabIndex = 65;
		this.txtRainAlpha2.TextChanged += new System.EventHandler(txtRainAlpha2_TextChanged);
		this.txtRainSkewBase2.Location = new System.Drawing.Point(164, 89);
		this.txtRainSkewBase2.Name = "txtRainSkewBase2";
		this.txtRainSkewBase2.Size = new System.Drawing.Size(56, 20);
		this.txtRainSkewBase2.TabIndex = 68;
		this.txtRainSkewBase2.TextChanged += new System.EventHandler(txtRainSkewBase2_TextChanged);
		this.tabPage4.Controls.Add(this.chkNoMusic);
		this.tabPage4.Controls.Add(this.chkNoGravestones);
		this.tabPage4.Controls.Add(this.chkSanctuary);
		this.tabPage4.Controls.Add(this.chkLightning);
		this.tabPage4.Controls.Add(this.chkSndLightRain);
		this.tabPage4.Controls.Add(this.chkSndStorm);
		this.tabPage4.Controls.Add(this.chkSndRain);
		this.tabPage4.Controls.Add(this.chkSndRainIn);
		this.tabPage4.Controls.Add(this.chkSndDungeon);
		this.tabPage4.Controls.Add(this.chkSndDrips);
		this.tabPage4.Controls.Add(this.chkSndCreak);
		this.tabPage4.Controls.Add(this.chkSndChains);
		this.tabPage4.Controls.Add(this.chkSndCaveDrips);
		this.tabPage4.Controls.Add(this.chkSndCave);
		this.tabPage4.Controls.Add(this.chkSndBugs);
		this.tabPage4.Controls.Add(this.chkStarry);
		this.tabPage4.Controls.Add(this.panel25);
		this.tabPage4.Controls.Add(this.panel27);
		this.tabPage4.Controls.Add(this.panel28);
		this.tabPage4.Controls.Add(this.panel26);
		this.tabPage4.Controls.Add(this.panel24);
		this.tabPage4.Controls.Add(this.panel20);
		this.tabPage4.Controls.Add(this.panel22);
		this.tabPage4.Controls.Add(this.panel21);
		this.tabPage4.Controls.Add(this.panel23);
		this.tabPage4.Location = new System.Drawing.Point(4, 22);
		this.tabPage4.Name = "tabPage4";
		this.tabPage4.Size = new System.Drawing.Size(879, 684);
		this.tabPage4.TabIndex = 3;
		this.tabPage4.Text = "General";
		this.tabPage4.UseVisualStyleBackColor = true;
		this.chkNoMusic.AutoSize = true;
		this.chkNoMusic.Location = new System.Drawing.Point(464, 345);
		this.chkNoMusic.Name = "chkNoMusic";
		this.chkNoMusic.Size = new System.Drawing.Size(71, 17);
		this.chkNoMusic.TabIndex = 108;
		this.chkNoMusic.Text = "No Music";
		this.chkNoMusic.UseVisualStyleBackColor = true;
		this.chkNoMusic.CheckedChanged += new System.EventHandler(chkNoMusic_CheckedChanged);
		this.chkNoGravestones.AutoSize = true;
		this.chkNoGravestones.Location = new System.Drawing.Point(464, 322);
		this.chkNoGravestones.Name = "chkNoGravestones";
		this.chkNoGravestones.Size = new System.Drawing.Size(103, 17);
		this.chkNoGravestones.TabIndex = 107;
		this.chkNoGravestones.Text = "No Gravestones";
		this.chkNoGravestones.UseVisualStyleBackColor = true;
		this.chkNoGravestones.CheckedChanged += new System.EventHandler(chkNoGravestones_CheckedChanged);
		this.chkSanctuary.AutoSize = true;
		this.chkSanctuary.Location = new System.Drawing.Point(464, 299);
		this.chkSanctuary.Name = "chkSanctuary";
		this.chkSanctuary.Size = new System.Drawing.Size(74, 17);
		this.chkSanctuary.TabIndex = 106;
		this.chkSanctuary.Text = "Sanctuary";
		this.chkSanctuary.UseVisualStyleBackColor = true;
		this.chkSanctuary.CheckedChanged += new System.EventHandler(chkSanctuary_CheckedChanged);
		this.chkLightning.AutoSize = true;
		this.chkLightning.Location = new System.Drawing.Point(742, 8);
		this.chkLightning.Name = "chkLightning";
		this.chkLightning.Size = new System.Drawing.Size(69, 17);
		this.chkLightning.TabIndex = 105;
		this.chkLightning.Text = "Lightning";
		this.chkLightning.UseVisualStyleBackColor = true;
		this.chkLightning.CheckedChanged += new System.EventHandler(chkLightning_CheckedChanged);
		this.chkSndLightRain.AutoSize = true;
		this.chkSndLightRain.Location = new System.Drawing.Point(683, 206);
		this.chkSndLightRain.Name = "chkSndLightRain";
		this.chkSndLightRain.Size = new System.Drawing.Size(96, 17);
		this.chkSndLightRain.TabIndex = 104;
		this.chkSndLightRain.Text = "Snd Light Rain";
		this.chkSndLightRain.UseVisualStyleBackColor = true;
		this.chkSndLightRain.CheckedChanged += new System.EventHandler(chkSndLightRain_CheckedChanged);
		this.chkSndStorm.AutoSize = true;
		this.chkSndStorm.Location = new System.Drawing.Point(683, 275);
		this.chkSndStorm.Name = "chkSndStorm";
		this.chkSndStorm.Size = new System.Drawing.Size(75, 17);
		this.chkSndStorm.TabIndex = 103;
		this.chkSndStorm.Text = "Snd Storm";
		this.chkSndStorm.UseVisualStyleBackColor = true;
		this.chkSndStorm.CheckedChanged += new System.EventHandler(chkSndStorm_CheckedChanged);
		this.chkSndRain.AutoSize = true;
		this.chkSndRain.Location = new System.Drawing.Point(683, 252);
		this.chkSndRain.Name = "chkSndRain";
		this.chkSndRain.Size = new System.Drawing.Size(70, 17);
		this.chkSndRain.TabIndex = 102;
		this.chkSndRain.Text = "Snd Rain";
		this.chkSndRain.UseVisualStyleBackColor = true;
		this.chkSndRain.CheckedChanged += new System.EventHandler(chkSndRain_CheckedChanged);
		this.chkSndRainIn.AutoSize = true;
		this.chkSndRainIn.Location = new System.Drawing.Point(683, 229);
		this.chkSndRainIn.Name = "chkSndRainIn";
		this.chkSndRainIn.Size = new System.Drawing.Size(82, 17);
		this.chkSndRainIn.TabIndex = 101;
		this.chkSndRainIn.Text = "Snd Rain In";
		this.chkSndRainIn.UseVisualStyleBackColor = true;
		this.chkSndRainIn.CheckedChanged += new System.EventHandler(chkSndRainIn_CheckedChanged);
		this.chkSndDungeon.AutoSize = true;
		this.chkSndDungeon.Location = new System.Drawing.Point(683, 183);
		this.chkSndDungeon.Name = "chkSndDungeon";
		this.chkSndDungeon.Size = new System.Drawing.Size(92, 17);
		this.chkSndDungeon.TabIndex = 100;
		this.chkSndDungeon.Text = "Snd Dungeon";
		this.chkSndDungeon.UseVisualStyleBackColor = true;
		this.chkSndDungeon.CheckedChanged += new System.EventHandler(chkSndDungeon_CheckedChanged);
		this.chkSndDrips.AutoSize = true;
		this.chkSndDrips.Location = new System.Drawing.Point(683, 160);
		this.chkSndDrips.Name = "chkSndDrips";
		this.chkSndDrips.Size = new System.Drawing.Size(72, 17);
		this.chkSndDrips.TabIndex = 99;
		this.chkSndDrips.Text = "Snd Drips";
		this.chkSndDrips.UseVisualStyleBackColor = true;
		this.chkSndDrips.CheckedChanged += new System.EventHandler(chkSndDrips_CheckedChanged);
		this.chkSndCreak.AutoSize = true;
		this.chkSndCreak.Location = new System.Drawing.Point(683, 137);
		this.chkSndCreak.Name = "chkSndCreak";
		this.chkSndCreak.Size = new System.Drawing.Size(76, 17);
		this.chkSndCreak.TabIndex = 98;
		this.chkSndCreak.Text = "Snd Creak";
		this.chkSndCreak.UseVisualStyleBackColor = true;
		this.chkSndCreak.CheckedChanged += new System.EventHandler(chkSndCreak_CheckedChanged);
		this.chkSndChains.AutoSize = true;
		this.chkSndChains.Location = new System.Drawing.Point(683, 114);
		this.chkSndChains.Name = "chkSndChains";
		this.chkSndChains.Size = new System.Drawing.Size(80, 17);
		this.chkSndChains.TabIndex = 97;
		this.chkSndChains.Text = "Snd Chains";
		this.chkSndChains.UseVisualStyleBackColor = true;
		this.chkSndChains.CheckedChanged += new System.EventHandler(chkSndChains_CheckedChanged);
		this.chkSndCaveDrips.AutoSize = true;
		this.chkSndCaveDrips.Location = new System.Drawing.Point(683, 91);
		this.chkSndCaveDrips.Name = "chkSndCaveDrips";
		this.chkSndCaveDrips.Size = new System.Drawing.Size(100, 17);
		this.chkSndCaveDrips.TabIndex = 96;
		this.chkSndCaveDrips.Text = "Snd Cave Drips";
		this.chkSndCaveDrips.UseVisualStyleBackColor = true;
		this.chkSndCaveDrips.CheckedChanged += new System.EventHandler(chkSndCaveDrips_CheckedChanged);
		this.chkSndCave.AutoSize = true;
		this.chkSndCave.Location = new System.Drawing.Point(683, 68);
		this.chkSndCave.Name = "chkSndCave";
		this.chkSndCave.Size = new System.Drawing.Size(73, 17);
		this.chkSndCave.TabIndex = 95;
		this.chkSndCave.Text = "Snd Cave";
		this.chkSndCave.UseVisualStyleBackColor = true;
		this.chkSndCave.CheckedChanged += new System.EventHandler(chkSndCave_CheckedChanged);
		this.chkSndBugs.AutoSize = true;
		this.chkSndBugs.Location = new System.Drawing.Point(683, 45);
		this.chkSndBugs.Name = "chkSndBugs";
		this.chkSndBugs.Size = new System.Drawing.Size(72, 17);
		this.chkSndBugs.TabIndex = 94;
		this.chkSndBugs.Text = "Snd Bugs";
		this.chkSndBugs.UseVisualStyleBackColor = true;
		this.chkSndBugs.CheckedChanged += new System.EventHandler(chkSndBugs_CheckedChanged);
		this.chkStarry.AutoSize = true;
		this.chkStarry.Location = new System.Drawing.Point(683, 8);
		this.chkStarry.Name = "chkStarry";
		this.chkStarry.Size = new System.Drawing.Size(53, 17);
		this.chkStarry.TabIndex = 93;
		this.chkStarry.Text = "Starry";
		this.chkStarry.UseVisualStyleBackColor = true;
		this.chkStarry.CheckedChanged += new System.EventHandler(chkStarry_CheckedChanged);
		this.txtBBBG.Location = new System.Drawing.Point(168, 85);
		this.txtBBBG.Name = "txtBBBG";
		this.txtBBBG.Size = new System.Drawing.Size(35, 20);
		this.txtBBBG.TabIndex = 31;
		this.txtBBBG.TextChanged += new System.EventHandler(txtBBBG_TextChanged);
		this.txtBGBG.Location = new System.Drawing.Point(168, 60);
		this.txtBGBG.Name = "txtBGBG";
		this.txtBGBG.Size = new System.Drawing.Size(35, 20);
		this.txtBGBG.TabIndex = 30;
		this.txtBGBG.TextChanged += new System.EventHandler(txtBGBG_TextChanged);
		this.txtBRBG.Location = new System.Drawing.Point(168, 34);
		this.txtBRBG.Name = "txtBRBG";
		this.txtBRBG.Size = new System.Drawing.Size(35, 20);
		this.txtBRBG.TabIndex = 29;
		this.txtBRBG.TextChanged += new System.EventHandler(txtBRBG_TextChanged);
		this.txtBBOBack5.Location = new System.Drawing.Point(168, 85);
		this.txtBBOBack5.Name = "txtBBOBack5";
		this.txtBBOBack5.Size = new System.Drawing.Size(35, 20);
		this.txtBBOBack5.TabIndex = 34;
		this.txtBBOBack5.TextChanged += new System.EventHandler(txtBBOBack5_TextChanged);
		this.txtBGOBack5.Location = new System.Drawing.Point(168, 60);
		this.txtBGOBack5.Name = "txtBGOBack5";
		this.txtBGOBack5.Size = new System.Drawing.Size(35, 20);
		this.txtBGOBack5.TabIndex = 33;
		this.txtBGOBack5.TextChanged += new System.EventHandler(txtBGOBack5_TextChanged);
		this.txtBROBack5.Location = new System.Drawing.Point(168, 34);
		this.txtBROBack5.Name = "txtBROBack5";
		this.txtBROBack5.Size = new System.Drawing.Size(35, 20);
		this.txtBROBack5.TabIndex = 32;
		this.txtBROBack5.TextChanged += new System.EventHandler(txtBROBack5_TextChanged);
		this.txtBBOBack4.Location = new System.Drawing.Point(168, 85);
		this.txtBBOBack4.Name = "txtBBOBack4";
		this.txtBBOBack4.Size = new System.Drawing.Size(35, 20);
		this.txtBBOBack4.TabIndex = 37;
		this.txtBBOBack4.TextChanged += new System.EventHandler(txtBBOBack4_TextChanged);
		this.txtBGOBack4.Location = new System.Drawing.Point(168, 60);
		this.txtBGOBack4.Name = "txtBGOBack4";
		this.txtBGOBack4.Size = new System.Drawing.Size(35, 20);
		this.txtBGOBack4.TabIndex = 36;
		this.txtBGOBack4.TextChanged += new System.EventHandler(txtBGOBack4_TextChanged);
		this.txtBROBack4.Location = new System.Drawing.Point(168, 34);
		this.txtBROBack4.Name = "txtBROBack4";
		this.txtBROBack4.Size = new System.Drawing.Size(35, 20);
		this.txtBROBack4.TabIndex = 35;
		this.txtBROBack4.TextChanged += new System.EventHandler(txtBROBack4_TextChanged);
		this.txtBBOBack3.Location = new System.Drawing.Point(168, 85);
		this.txtBBOBack3.Name = "txtBBOBack3";
		this.txtBBOBack3.Size = new System.Drawing.Size(35, 20);
		this.txtBBOBack3.TabIndex = 37;
		this.txtBBOBack3.TextChanged += new System.EventHandler(txtBBOBack3_TextChanged);
		this.txtBGOBack3.Location = new System.Drawing.Point(168, 60);
		this.txtBGOBack3.Name = "txtBGOBack3";
		this.txtBGOBack3.Size = new System.Drawing.Size(35, 20);
		this.txtBGOBack3.TabIndex = 36;
		this.txtBGOBack3.TextChanged += new System.EventHandler(txtBGOBack3_TextChanged);
		this.txtBROBack3.Location = new System.Drawing.Point(168, 34);
		this.txtBROBack3.Name = "txtBROBack3";
		this.txtBROBack3.Size = new System.Drawing.Size(35, 20);
		this.txtBROBack3.TabIndex = 35;
		this.txtBROBack3.TextChanged += new System.EventHandler(txtBROBack3_TextChanged);
		this.txtBBOBack2.Location = new System.Drawing.Point(168, 85);
		this.txtBBOBack2.Name = "txtBBOBack2";
		this.txtBBOBack2.Size = new System.Drawing.Size(35, 20);
		this.txtBBOBack2.TabIndex = 37;
		this.txtBBOBack2.TextChanged += new System.EventHandler(txtBBOBack2_TextChanged);
		this.txtBGOBack2.Location = new System.Drawing.Point(168, 60);
		this.txtBGOBack2.Name = "txtBGOBack2";
		this.txtBGOBack2.Size = new System.Drawing.Size(35, 20);
		this.txtBGOBack2.TabIndex = 36;
		this.txtBGOBack2.TextChanged += new System.EventHandler(txtBGOBack2_TextChanged);
		this.txtBROBack2.Location = new System.Drawing.Point(168, 34);
		this.txtBROBack2.Name = "txtBROBack2";
		this.txtBROBack2.Size = new System.Drawing.Size(35, 20);
		this.txtBROBack2.TabIndex = 35;
		this.txtBROBack2.TextChanged += new System.EventHandler(txtBROBack2_TextChanged);
		this.txtBBOBack1.Location = new System.Drawing.Point(168, 85);
		this.txtBBOBack1.Name = "txtBBOBack1";
		this.txtBBOBack1.Size = new System.Drawing.Size(35, 20);
		this.txtBBOBack1.TabIndex = 37;
		this.txtBBOBack1.TextChanged += new System.EventHandler(txtBBOBack1_TextChanged);
		this.txtBGOBack1.Location = new System.Drawing.Point(168, 60);
		this.txtBGOBack1.Name = "txtBGOBack1";
		this.txtBGOBack1.Size = new System.Drawing.Size(35, 20);
		this.txtBGOBack1.TabIndex = 36;
		this.txtBGOBack1.TextChanged += new System.EventHandler(txtBGOBack1_TextChanged);
		this.txtBROBack1.Location = new System.Drawing.Point(168, 34);
		this.txtBROBack1.Name = "txtBROBack1";
		this.txtBROBack1.Size = new System.Drawing.Size(35, 20);
		this.txtBROBack1.TabIndex = 35;
		this.txtBROBack1.TextChanged += new System.EventHandler(txtBROBack1_TextChanged);
		this.txtBBOMid.Location = new System.Drawing.Point(168, 85);
		this.txtBBOMid.Name = "txtBBOMid";
		this.txtBBOMid.Size = new System.Drawing.Size(35, 20);
		this.txtBBOMid.TabIndex = 37;
		this.txtBBOMid.TextChanged += new System.EventHandler(txtBBOMid_TextChanged);
		this.txtBGOMid.Location = new System.Drawing.Point(168, 60);
		this.txtBGOMid.Name = "txtBGOMid";
		this.txtBGOMid.Size = new System.Drawing.Size(35, 20);
		this.txtBGOMid.TabIndex = 36;
		this.txtBGOMid.TextChanged += new System.EventHandler(txtBGOMid_TextChanged);
		this.txtBROMid.Location = new System.Drawing.Point(168, 34);
		this.txtBROMid.Name = "txtBROMid";
		this.txtBROMid.Size = new System.Drawing.Size(35, 20);
		this.txtBROMid.TabIndex = 35;
		this.txtBROMid.TextChanged += new System.EventHandler(txtBROMid_TextChanged);
		this.txtBBOFore1.Location = new System.Drawing.Point(168, 85);
		this.txtBBOFore1.Name = "txtBBOFore1";
		this.txtBBOFore1.Size = new System.Drawing.Size(35, 20);
		this.txtBBOFore1.TabIndex = 37;
		this.txtBBOFore1.TextChanged += new System.EventHandler(txtBBOFore1_TextChanged);
		this.txtBGOFore1.Location = new System.Drawing.Point(168, 60);
		this.txtBGOFore1.Name = "txtBGOFore1";
		this.txtBGOFore1.Size = new System.Drawing.Size(35, 20);
		this.txtBGOFore1.TabIndex = 36;
		this.txtBGOFore1.TextChanged += new System.EventHandler(txtBGOFore1_TextChanged);
		this.txtBROFore1.Location = new System.Drawing.Point(168, 34);
		this.txtBROFore1.Name = "txtBROFore1";
		this.txtBROFore1.Size = new System.Drawing.Size(35, 20);
		this.txtBROFore1.TabIndex = 35;
		this.txtBROFore1.TextChanged += new System.EventHandler(txtBROFore1_TextChanged);
		this.txtBBOFore2.Location = new System.Drawing.Point(168, 85);
		this.txtBBOFore2.Name = "txtBBOFore2";
		this.txtBBOFore2.Size = new System.Drawing.Size(35, 20);
		this.txtBBOFore2.TabIndex = 37;
		this.txtBBOFore2.TextChanged += new System.EventHandler(txtBBOFore2_TextChanged);
		this.txtBGOFore2.Location = new System.Drawing.Point(168, 60);
		this.txtBGOFore2.Name = "txtBGOFore2";
		this.txtBGOFore2.Size = new System.Drawing.Size(35, 20);
		this.txtBGOFore2.TabIndex = 36;
		this.txtBGOFore2.TextChanged += new System.EventHandler(txtBGOFore2_TextChanged);
		this.txtBROFore2.Location = new System.Drawing.Point(168, 34);
		this.txtBROFore2.Name = "txtBROFore2";
		this.txtBROFore2.Size = new System.Drawing.Size(35, 20);
		this.txtBROFore2.TabIndex = 35;
		this.txtBROFore2.TextChanged += new System.EventHandler(txtBROFore2_TextChanged);
		this.txtBBOFore3.Location = new System.Drawing.Point(168, 85);
		this.txtBBOFore3.Name = "txtBBOFore3";
		this.txtBBOFore3.Size = new System.Drawing.Size(35, 20);
		this.txtBBOFore3.TabIndex = 37;
		this.txtBBOFore3.TextChanged += new System.EventHandler(txtBBOFore3_TextChanged);
		this.txtBGOFore3.Location = new System.Drawing.Point(168, 60);
		this.txtBGOFore3.Name = "txtBGOFore3";
		this.txtBGOFore3.Size = new System.Drawing.Size(35, 20);
		this.txtBGOFore3.TabIndex = 36;
		this.txtBGOFore3.TextChanged += new System.EventHandler(txtBGOFore3_TextChanged);
		this.txtBROFore3.Location = new System.Drawing.Point(168, 34);
		this.txtBROFore3.Name = "txtBROFore3";
		this.txtBROFore3.Size = new System.Drawing.Size(35, 20);
		this.txtBROFore3.TabIndex = 35;
		this.txtBROFore3.TextChanged += new System.EventHandler(txtBROFore3_TextChanged);
		this.txtBBOFore4.Location = new System.Drawing.Point(168, 85);
		this.txtBBOFore4.Name = "txtBBOFore4";
		this.txtBBOFore4.Size = new System.Drawing.Size(35, 20);
		this.txtBBOFore4.TabIndex = 37;
		this.txtBBOFore4.TextChanged += new System.EventHandler(txtBBOFore4_TextChanged);
		this.txtBGOFore4.Location = new System.Drawing.Point(168, 60);
		this.txtBGOFore4.Name = "txtBGOFore4";
		this.txtBGOFore4.Size = new System.Drawing.Size(35, 20);
		this.txtBGOFore4.TabIndex = 36;
		this.txtBGOFore4.TextChanged += new System.EventHandler(txtBGOFore4_TextChanged);
		this.txtBROFore4.Location = new System.Drawing.Point(168, 34);
		this.txtBROFore4.Name = "txtBROFore4";
		this.txtBROFore4.Size = new System.Drawing.Size(35, 20);
		this.txtBROFore4.TabIndex = 35;
		this.txtBROFore4.TextChanged += new System.EventHandler(txtBROFore4_TextChanged);
		this.txtBBOFore5.Location = new System.Drawing.Point(168, 85);
		this.txtBBOFore5.Name = "txtBBOFore5";
		this.txtBBOFore5.Size = new System.Drawing.Size(35, 20);
		this.txtBBOFore5.TabIndex = 37;
		this.txtBBOFore5.TextChanged += new System.EventHandler(txtBBOFore5_TextChanged);
		this.txtBGOFore5.Location = new System.Drawing.Point(168, 60);
		this.txtBGOFore5.Name = "txtBGOFore5";
		this.txtBGOFore5.Size = new System.Drawing.Size(35, 20);
		this.txtBGOFore5.TabIndex = 36;
		this.txtBGOFore5.TextChanged += new System.EventHandler(txtBGOFore5_TextChanged);
		this.txtBROFore5.Location = new System.Drawing.Point(168, 34);
		this.txtBROFore5.Name = "txtBROFore5";
		this.txtBROFore5.Size = new System.Drawing.Size(35, 20);
		this.txtBROFore5.TabIndex = 35;
		this.txtBROFore5.TextChanged += new System.EventHandler(txtBROFore5_TextChanged);
		this.txtBBIBack4.Location = new System.Drawing.Point(168, 85);
		this.txtBBIBack4.Name = "txtBBIBack4";
		this.txtBBIBack4.Size = new System.Drawing.Size(35, 20);
		this.txtBBIBack4.TabIndex = 37;
		this.txtBBIBack4.TextChanged += new System.EventHandler(txtBBIBack4_TextChanged);
		this.txtBGIBack4.Location = new System.Drawing.Point(168, 60);
		this.txtBGIBack4.Name = "txtBGIBack4";
		this.txtBGIBack4.Size = new System.Drawing.Size(35, 20);
		this.txtBGIBack4.TabIndex = 36;
		this.txtBGIBack4.TextChanged += new System.EventHandler(txtBGIBack4_TextChanged);
		this.txtBRIBack4.Location = new System.Drawing.Point(168, 34);
		this.txtBRIBack4.Name = "txtBRIBack4";
		this.txtBRIBack4.Size = new System.Drawing.Size(35, 20);
		this.txtBRIBack4.TabIndex = 35;
		this.txtBRIBack4.TextChanged += new System.EventHandler(txtBRIBack4_TextChanged);
		this.txtBBIBack3.Location = new System.Drawing.Point(168, 85);
		this.txtBBIBack3.Name = "txtBBIBack3";
		this.txtBBIBack3.Size = new System.Drawing.Size(35, 20);
		this.txtBBIBack3.TabIndex = 37;
		this.txtBBIBack3.TextChanged += new System.EventHandler(txtBBIBack3_TextChanged);
		this.txtBGIBack3.Location = new System.Drawing.Point(168, 60);
		this.txtBGIBack3.Name = "txtBGIBack3";
		this.txtBGIBack3.Size = new System.Drawing.Size(35, 20);
		this.txtBGIBack3.TabIndex = 36;
		this.txtBGIBack3.TextChanged += new System.EventHandler(txtBGIBack3_TextChanged);
		this.txtBRIBack3.Location = new System.Drawing.Point(168, 34);
		this.txtBRIBack3.Name = "txtBRIBack3";
		this.txtBRIBack3.Size = new System.Drawing.Size(35, 20);
		this.txtBRIBack3.TabIndex = 35;
		this.txtBRIBack3.TextChanged += new System.EventHandler(txtBRIBack3_TextChanged);
		this.txtBBIBack2.Location = new System.Drawing.Point(168, 85);
		this.txtBBIBack2.Name = "txtBBIBack2";
		this.txtBBIBack2.Size = new System.Drawing.Size(35, 20);
		this.txtBBIBack2.TabIndex = 37;
		this.txtBBIBack2.TextChanged += new System.EventHandler(txtBBIBack2_TextChanged);
		this.txtBGIBack2.Location = new System.Drawing.Point(168, 60);
		this.txtBGIBack2.Name = "txtBGIBack2";
		this.txtBGIBack2.Size = new System.Drawing.Size(35, 20);
		this.txtBGIBack2.TabIndex = 36;
		this.txtBGIBack2.TextChanged += new System.EventHandler(txtBGIBack2_TextChanged);
		this.txtBRIBack2.Location = new System.Drawing.Point(168, 34);
		this.txtBRIBack2.Name = "txtBRIBack2";
		this.txtBRIBack2.Size = new System.Drawing.Size(35, 20);
		this.txtBRIBack2.TabIndex = 35;
		this.txtBRIBack2.TextChanged += new System.EventHandler(txtBRIBack2_TextChanged);
		this.txtBBIBack1.Location = new System.Drawing.Point(168, 85);
		this.txtBBIBack1.Name = "txtBBIBack1";
		this.txtBBIBack1.Size = new System.Drawing.Size(35, 20);
		this.txtBBIBack1.TabIndex = 37;
		this.txtBBIBack1.TextChanged += new System.EventHandler(txtBBIBack1_TextChanged);
		this.txtBGIBack1.Location = new System.Drawing.Point(168, 60);
		this.txtBGIBack1.Name = "txtBGIBack1";
		this.txtBGIBack1.Size = new System.Drawing.Size(35, 20);
		this.txtBGIBack1.TabIndex = 36;
		this.txtBGIBack1.TextChanged += new System.EventHandler(txtBGIBack1_TextChanged);
		this.txtBRIBack1.Location = new System.Drawing.Point(168, 34);
		this.txtBRIBack1.Name = "txtBRIBack1";
		this.txtBRIBack1.Size = new System.Drawing.Size(35, 20);
		this.txtBRIBack1.TabIndex = 35;
		this.txtBRIBack1.TextChanged += new System.EventHandler(txtBRIBack1_TextChanged);
		this.txtBBIMid.Location = new System.Drawing.Point(168, 85);
		this.txtBBIMid.Name = "txtBBIMid";
		this.txtBBIMid.Size = new System.Drawing.Size(35, 20);
		this.txtBBIMid.TabIndex = 37;
		this.txtBBIMid.TextChanged += new System.EventHandler(txtBBIMid_TextChanged);
		this.txtBGIMid.Location = new System.Drawing.Point(168, 60);
		this.txtBGIMid.Name = "txtBGIMid";
		this.txtBGIMid.Size = new System.Drawing.Size(35, 20);
		this.txtBGIMid.TabIndex = 36;
		this.txtBGIMid.TextChanged += new System.EventHandler(txtBGIMid_TextChanged);
		this.txtBRIMid.Location = new System.Drawing.Point(168, 34);
		this.txtBRIMid.Name = "txtBRIMid";
		this.txtBRIMid.Size = new System.Drawing.Size(35, 20);
		this.txtBRIMid.TabIndex = 35;
		this.txtBRIMid.TextChanged += new System.EventHandler(txtBRIMid_TextChanged);
		this.txtBBIFore1.Location = new System.Drawing.Point(168, 85);
		this.txtBBIFore1.Name = "txtBBIFore1";
		this.txtBBIFore1.Size = new System.Drawing.Size(35, 20);
		this.txtBBIFore1.TabIndex = 37;
		this.txtBBIFore1.TextChanged += new System.EventHandler(txtBBIFore1_TextChanged);
		this.txtBGIFore1.Location = new System.Drawing.Point(168, 60);
		this.txtBGIFore1.Name = "txtBGIFore1";
		this.txtBGIFore1.Size = new System.Drawing.Size(35, 20);
		this.txtBGIFore1.TabIndex = 36;
		this.txtBGIFore1.TextChanged += new System.EventHandler(txtBGIFore1_TextChanged);
		this.txtBRIFore1.Location = new System.Drawing.Point(168, 34);
		this.txtBRIFore1.Name = "txtBRIFore1";
		this.txtBRIFore1.Size = new System.Drawing.Size(35, 20);
		this.txtBRIFore1.TabIndex = 35;
		this.txtBRIFore1.TextChanged += new System.EventHandler(txtBRIFore1_TextChanged);
		this.txtBBIFore2.Location = new System.Drawing.Point(168, 85);
		this.txtBBIFore2.Name = "txtBBIFore2";
		this.txtBBIFore2.Size = new System.Drawing.Size(35, 20);
		this.txtBBIFore2.TabIndex = 37;
		this.txtBBIFore2.TextChanged += new System.EventHandler(txtBBIFore2_TextChanged);
		this.txtBGIFore2.Location = new System.Drawing.Point(168, 60);
		this.txtBGIFore2.Name = "txtBGIFore2";
		this.txtBGIFore2.Size = new System.Drawing.Size(35, 20);
		this.txtBGIFore2.TabIndex = 36;
		this.txtBGIFore2.TextChanged += new System.EventHandler(txtBGIFore2_TextChanged);
		this.txtBRIFore2.Location = new System.Drawing.Point(168, 34);
		this.txtBRIFore2.Name = "txtBRIFore2";
		this.txtBRIFore2.Size = new System.Drawing.Size(35, 20);
		this.txtBRIFore2.TabIndex = 35;
		this.txtBRIFore2.TextChanged += new System.EventHandler(txtBRIFore2_TextChanged);
		this.txtBBIFore3.Location = new System.Drawing.Point(167, 85);
		this.txtBBIFore3.Name = "txtBBIFore3";
		this.txtBBIFore3.Size = new System.Drawing.Size(35, 20);
		this.txtBBIFore3.TabIndex = 37;
		this.txtBBIFore3.TextChanged += new System.EventHandler(txtBBIFore3_TextChanged);
		this.txtBGIFore3.Location = new System.Drawing.Point(167, 60);
		this.txtBGIFore3.Name = "txtBGIFore3";
		this.txtBGIFore3.Size = new System.Drawing.Size(35, 20);
		this.txtBGIFore3.TabIndex = 36;
		this.txtBGIFore3.TextChanged += new System.EventHandler(txtBGIFore3_TextChanged);
		this.txtBRIFore3.Location = new System.Drawing.Point(167, 34);
		this.txtBRIFore3.Name = "txtBRIFore3";
		this.txtBRIFore3.Size = new System.Drawing.Size(35, 20);
		this.txtBRIFore3.TabIndex = 35;
		this.txtBRIFore3.TextChanged += new System.EventHandler(txtBRIFore3_TextChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1128, 742);
		base.Controls.Add(this.tbPanels);
		base.Controls.Add(this.lstLayers);
		base.Controls.Add(this.menuStrip1);
		base.MainMenuStrip = this.menuStrip1;
		base.Name = "LayerTintEdit";
		this.Text = "LayerTintEdit";
		base.Load += new System.EventHandler(LayerTintEdit_Load);
		this.trkROBack5.EndInit();
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.trkGammaOBack5.EndInit();
		this.trkBriteOBack5.EndInit();
		this.trkTintOBack5.EndInit();
		this.trkSatOBack5.EndInit();
		this.trkBOBack5.EndInit();
		this.trkGOBack5.EndInit();
		this.panel2.ResumeLayout(false);
		this.panel2.PerformLayout();
		this.trkGammaOBack4.EndInit();
		this.trkBriteOBack4.EndInit();
		this.trkTintOBack4.EndInit();
		this.trkSatOBack4.EndInit();
		this.trkBOBack4.EndInit();
		this.trkGOBack4.EndInit();
		this.trkROBack4.EndInit();
		this.panel3.ResumeLayout(false);
		this.panel3.PerformLayout();
		this.trkGammaOBack3.EndInit();
		this.trkBriteOBack3.EndInit();
		this.trkTintOBack3.EndInit();
		this.trkSatOBack3.EndInit();
		this.trkBOBack3.EndInit();
		this.trkGOBack3.EndInit();
		this.trkROBack3.EndInit();
		this.panel4.ResumeLayout(false);
		this.panel4.PerformLayout();
		this.trkGammaOBack2.EndInit();
		this.trkBriteOBack2.EndInit();
		this.trkTintOBack2.EndInit();
		this.trkSatOBack2.EndInit();
		this.trkBOBack2.EndInit();
		this.trkGOBack2.EndInit();
		this.trkROBack2.EndInit();
		this.panel5.ResumeLayout(false);
		this.panel5.PerformLayout();
		this.trkGammaOBack1.EndInit();
		this.trkBriteOBack1.EndInit();
		this.trkTintOBack1.EndInit();
		this.trkSatOBack1.EndInit();
		this.trkBOBack1.EndInit();
		this.trkGOBack1.EndInit();
		this.trkROBack1.EndInit();
		this.panel6.ResumeLayout(false);
		this.panel6.PerformLayout();
		this.trkGammaOMid.EndInit();
		this.trkBriteOMid.EndInit();
		this.trkTintOMid.EndInit();
		this.trkSatOMid.EndInit();
		this.trkBOMid.EndInit();
		this.trkGOMid.EndInit();
		this.trkROMid.EndInit();
		this.panel7.ResumeLayout(false);
		this.panel7.PerformLayout();
		this.trkGammaOFore1.EndInit();
		this.trkBriteOFore1.EndInit();
		this.trkTintOFore1.EndInit();
		this.trkSatOFore1.EndInit();
		this.trkBOFore1.EndInit();
		this.trkGOFore1.EndInit();
		this.trkROFore1.EndInit();
		this.panel8.ResumeLayout(false);
		this.panel8.PerformLayout();
		this.trkGammaOFore2.EndInit();
		this.trkBriteOFore2.EndInit();
		this.trkTintOFore2.EndInit();
		this.trkSatOFore2.EndInit();
		this.trkBOFore2.EndInit();
		this.trkGOFore2.EndInit();
		this.trkROFore2.EndInit();
		this.panel9.ResumeLayout(false);
		this.panel9.PerformLayout();
		this.trkGammaOFore3.EndInit();
		this.trkBriteOFore3.EndInit();
		this.trkTintOFore3.EndInit();
		this.trkSatOFore3.EndInit();
		this.trkBOFore3.EndInit();
		this.trkGOFore3.EndInit();
		this.trkROFore3.EndInit();
		this.panel10.ResumeLayout(false);
		this.panel10.PerformLayout();
		this.trkGammaOFore4.EndInit();
		this.trkBriteOFore4.EndInit();
		this.trkTintOFore4.EndInit();
		this.trkSatOFore4.EndInit();
		this.trkBOFore4.EndInit();
		this.trkGOFore4.EndInit();
		this.trkROFore4.EndInit();
		this.panel11.ResumeLayout(false);
		this.panel11.PerformLayout();
		this.trkGammaOFore5.EndInit();
		this.trkBriteOFore5.EndInit();
		this.trkTintOFore5.EndInit();
		this.trkSatOFore5.EndInit();
		this.trkBOFore5.EndInit();
		this.trkGOFore5.EndInit();
		this.trkROFore5.EndInit();
		this.panel12.ResumeLayout(false);
		this.panel12.PerformLayout();
		this.trkGammaIFore3.EndInit();
		this.trkBriteIFore3.EndInit();
		this.trkTintIFore3.EndInit();
		this.trkSatIFore3.EndInit();
		this.trkBIFore3.EndInit();
		this.trkGIFore3.EndInit();
		this.trkRIFore3.EndInit();
		this.panel13.ResumeLayout(false);
		this.panel13.PerformLayout();
		this.trkGammaIFore2.EndInit();
		this.trkBriteIFore2.EndInit();
		this.trkTintIFore2.EndInit();
		this.trkSatIFore2.EndInit();
		this.trkBIFore2.EndInit();
		this.trkGIFore2.EndInit();
		this.trkRIFore2.EndInit();
		this.panel14.ResumeLayout(false);
		this.panel14.PerformLayout();
		this.trkGammaIFore1.EndInit();
		this.trkBriteIFore1.EndInit();
		this.trkTintIFore1.EndInit();
		this.trkSatIFore1.EndInit();
		this.trkBIFore1.EndInit();
		this.trkGIFore1.EndInit();
		this.trkRIFore1.EndInit();
		this.panel15.ResumeLayout(false);
		this.panel15.PerformLayout();
		this.trkGammaIMid.EndInit();
		this.trkBriteIMid.EndInit();
		this.trkTintIMid.EndInit();
		this.trkSatIMid.EndInit();
		this.trkBIMid.EndInit();
		this.trkGIMid.EndInit();
		this.trkRIMid.EndInit();
		this.panel16.ResumeLayout(false);
		this.panel16.PerformLayout();
		this.trkGammaIBack1.EndInit();
		this.trkBriteIBack1.EndInit();
		this.trkTintIBack1.EndInit();
		this.trkSatIBack1.EndInit();
		this.trkBIBack1.EndInit();
		this.trkGIBack1.EndInit();
		this.trkRIBack1.EndInit();
		this.panel17.ResumeLayout(false);
		this.panel17.PerformLayout();
		this.trkGammaIBack2.EndInit();
		this.trkBriteIBack2.EndInit();
		this.trkTintIBack2.EndInit();
		this.trkSatIBack2.EndInit();
		this.trkBIBack2.EndInit();
		this.trkGIBack2.EndInit();
		this.trkRIBack2.EndInit();
		this.panel18.ResumeLayout(false);
		this.panel18.PerformLayout();
		this.trkGammaIBack3.EndInit();
		this.trkBriteIBack3.EndInit();
		this.trkTintIBack3.EndInit();
		this.trkSatIBack3.EndInit();
		this.trkBIBack3.EndInit();
		this.trkGIBack3.EndInit();
		this.trkRIBack3.EndInit();
		this.panel19.ResumeLayout(false);
		this.panel19.PerformLayout();
		this.trkGammaIBack4.EndInit();
		this.trkBriteIBack4.EndInit();
		this.trkTintIBack4.EndInit();
		this.trkSatIBack4.EndInit();
		this.trkBIBack4.EndInit();
		this.trkGIBack4.EndInit();
		this.trkRIBack4.EndInit();
		this.trktB.EndInit();
		this.trktG.EndInit();
		this.trktR.EndInit();
		this.trkbB.EndInit();
		this.trkbG.EndInit();
		this.trkbR.EndInit();
		this.trkbgB.EndInit();
		this.trkbgG.EndInit();
		this.trkbgR.EndInit();
		this.trkburnB.EndInit();
		this.trkburnG.EndInit();
		this.trkburnR.EndInit();
		this.trkBrite.EndInit();
		this.trkGamma.EndInit();
		this.trkBloomBase.EndInit();
		this.trkBloomThresh.EndInit();
		this.trkBloomSat.EndInit();
		this.trkBloomIntensity.EndInit();
		this.trkBloomFloor.EndInit();
		this.trkDarkBlur.EndInit();
		this.trkLightDesat.EndInit();
		this.trkLightRed.EndInit();
		this.trkLightBlue.EndInit();
		this.trkLightThresh.EndInit();
		this.panel20.ResumeLayout(false);
		this.panel20.PerformLayout();
		this.panel21.ResumeLayout(false);
		this.panel21.PerformLayout();
		this.panel22.ResumeLayout(false);
		this.panel22.PerformLayout();
		this.panel23.ResumeLayout(false);
		this.panel23.PerformLayout();
		this.trkBloomDesatBase.EndInit();
		this.panel24.ResumeLayout(false);
		this.panel24.PerformLayout();
		this.trkLightFac.EndInit();
		this.trkLightMap.EndInit();
		this.panel25.ResumeLayout(false);
		this.panel25.PerformLayout();
		this.trkBaseSat.EndInit();
		this.panel26.ResumeLayout(false);
		this.panel26.PerformLayout();
		this.trkLeavesAlpha.EndInit();
		this.trkRainAlpha.EndInit();
		this.trkSnowAlpha.EndInit();
		this.trkDotsAlpha.EndInit();
		this.panel27.ResumeLayout(false);
		this.panel27.PerformLayout();
		this.trkBloodSat.EndInit();
		this.trkBloodAlpha.EndInit();
		this.panel28.ResumeLayout(false);
		this.panel28.PerformLayout();
		this.trkpA.EndInit();
		this.trkpB.EndInit();
		this.trkpG.EndInit();
		this.trkpR.EndInit();
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		this.panel29.ResumeLayout(false);
		this.panel29.PerformLayout();
		this.trkRainSkewAdjust0.EndInit();
		this.trkRainSkewBase0.EndInit();
		this.trkRainAlpha0.EndInit();
		this.trkRainStretch0.EndInit();
		this.panel30.ResumeLayout(false);
		this.panel30.PerformLayout();
		this.trkRainSkewAdjust1.EndInit();
		this.trkRainSkewBase1.EndInit();
		this.trkRainAlpha1.EndInit();
		this.trkRainStretch1.EndInit();
		this.panel31.ResumeLayout(false);
		this.panel31.PerformLayout();
		this.trkRainB0.EndInit();
		this.trkRainG0.EndInit();
		this.trkRainR0.EndInit();
		this.tbPanels.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.tabPage2.ResumeLayout(false);
		this.panel39.ResumeLayout(false);
		this.panel39.PerformLayout();
		this.trkGammaBG.EndInit();
		this.trkBriteBG.EndInit();
		this.trkTintBG.EndInit();
		this.trkSatBG.EndInit();
		this.trkBBG.EndInit();
		this.trkGBG.EndInit();
		this.trkRBG.EndInit();
		this.tabPage3.ResumeLayout(false);
		this.panel38.ResumeLayout(false);
		this.panel38.PerformLayout();
		this.trkRainGamma3.EndInit();
		this.trkRainGamma2.EndInit();
		this.trkRainGamma1.EndInit();
		this.panel37.ResumeLayout(false);
		this.panel37.PerformLayout();
		this.trkRefractRainB.EndInit();
		this.trkRefractRainG.EndInit();
		this.trkRefractRainR.EndInit();
		this.trkRefractRainGlow.EndInit();
		this.trkRefractRainGlimmer.EndInit();
		this.trkRefractRainDark.EndInit();
		this.trkRefractRainBrite.EndInit();
		this.panel36.ResumeLayout(false);
		this.panel36.PerformLayout();
		this.trkRainSkewAdjust5.EndInit();
		this.trkRainSkewBase5.EndInit();
		this.trkRainAlpha5.EndInit();
		this.trkRainStretch5.EndInit();
		this.panel35.ResumeLayout(false);
		this.panel35.PerformLayout();
		this.trkRainSkewAdjust4.EndInit();
		this.trkRainSkewBase4.EndInit();
		this.trkRainAlpha4.EndInit();
		this.trkRainStretch4.EndInit();
		this.panel34.ResumeLayout(false);
		this.panel34.PerformLayout();
		this.trkRainB1.EndInit();
		this.trkRainG1.EndInit();
		this.trkRainR1.EndInit();
		this.panel33.ResumeLayout(false);
		this.panel33.PerformLayout();
		this.trkRainSkewAdjust3.EndInit();
		this.trkRainSkewBase3.EndInit();
		this.trkRainAlpha3.EndInit();
		this.trkRainStretch3.EndInit();
		this.panel32.ResumeLayout(false);
		this.panel32.PerformLayout();
		this.trkRainSkewAdjust2.EndInit();
		this.trkRainSkewBase2.EndInit();
		this.trkRainAlpha2.EndInit();
		this.trkRainStretch2.EndInit();
		this.tabPage4.ResumeLayout(false);
		this.tabPage4.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
