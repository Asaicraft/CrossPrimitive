using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPrimitives;

public static class Colors
{
    internal static readonly Dictionary<string, Color> NamedColors = new Dictionary<string, Color>
    {
        { "ALICEBLUE", AliceBlue },
        { "ANTIQUEWHITE", AntiqueWhite },
        { "AQUA", Aqua },
        { "AQUAMARINE", Aquamarine },
        { "AZURE", Azure },
        { "BEIGE", Beige },
        { "BISQUE", Bisque },
        { "BLACK", Black },
        { "BLANCHEDALMOND", BlanchedAlmond },
        { "BLUE", Blue },
        { "BLUEVIOLET", BlueViolet },
        { "BROWN", Brown },
        { "BURLYWOOD", Burlywood },
        { "CADETBLUE", CadetBlue },
        { "CHARTREUSE", Chartreuse },
        { "CHOCOLATE", Chocolate },
        { "CORAL", Coral },
        { "CORNFLOWERBLUE", CornflowerBlue },
        { "CORNSILK", Cornsilk },
        { "CRIMSON", Crimson },
        { "CYAN", Cyan },
        { "DARKBLUE", DarkBlue },
        { "DARKCYAN", DarkCyan },
        { "DARKGOLDENROD", DarkGoldenrod },
        { "DARKGRAY", DarkGray },
        { "DARKGREEN", DarkGreen },
        { "DARKKHAKI", DarkKhaki },
        { "DARKMAGENTA", DarkMagenta },
        { "DARKOLIVEGREEN", DarkOliveGreen },
        { "DARKORANGE", DarkOrange },
        { "DARKORCHID", DarkOrchid },
        { "DARKRED", DarkRed },
        { "DARKSALMON", DarkSalmon },
        { "DARKSEAGREEN", DarkSeaGreen },
        { "DARKSLATEBLUE", DarkSlateBlue },
        { "DARKSLATEGRAY", DarkSlateGray },
        { "DARKTURQUOISE", DarkTurquoise },
        { "DARKVIOLET", DarkViolet },
        { "DEEPPINK", DeepPink },
        { "DEEPSKYBLUE", DeepSkyBlue },
        { "DIMGRAY", DimGray },
        { "DODGERBLUE", DodgerBlue },
        { "FIREBRICK", Firebrick },
        { "FLORALWHITE", FloralWhite },
        { "FORESTGREEN", ForestGreen },
        { "FUCHSIA", Fuchsia },
        { "GAINSBORO", Gainsboro },
        { "GHOSTWHITE", GhostWhite },
        { "GOLD", Gold },
        { "GOLDENROD", Goldenrod },
        { "GRAY", Gray },
        { "GREEN", Green },
        { "GREENYELLOW", GreenYellow },
        { "HONEYDEW", Honeydew },
        { "HOTPINK", HotPink },
        { "INDIANRED", IndianRed },
        { "INDIGO", Indigo },
        { "IVORY", Ivory },
        { "KHAKI", Khaki },
        { "LAVENDER", Lavender },
        { "LAVENDERBLUSH", LavenderBlush },
        { "LAWNGREEN", LawnGreen },
        { "LEMONCHIFFON", LemonChiffon },
        { "LIGHTBLUE", LightBlue },
        { "LIGHTCORAL", LightCoral },
        { "LIGHTCYAN", LightCyan },
        { "LIGHTGOLDENROD", LightGoldenrod },
        { "LIGHTGRAY", LightGray },
        { "LIGHTGREEN", LightGreen },
        { "LIGHTPINK", LightPink },
        { "LIGHTSALMON", LightSalmon },
        { "LIGHTSEAGREEN", LightSeaGreen },
        { "LIGHTSKYBLUE", LightSkyBlue },
        { "LIGHTSLATEGRAY", LightSlateGray },
        { "LIGHTSTEELBLUE", LightSteelBlue },
        { "LIGHTYELLOW", LightYellow },
        { "LIME", Lime },
        { "LIMEGREEN", LimeGreen },
        { "LINEN", Linen },
        { "MAGENTA", Magenta },
        { "MAROON", Maroon },
        { "MEDIUMAQUAMARINE", MediumAquamarine },
        { "MEDIUMBLUE", MediumBlue },
        { "MEDIUMORCHID", MediumOrchid },
        { "MEDIUMPURPLE", MediumPurple },
        { "MEDIUMSEAGREEN", MediumSeaGreen },
        { "MEDIUMSLATEBLUE", MediumSlateBlue },
        { "MEDIUMSPRINGGREEN", MediumSpringGreen },
        { "MEDIUMTURQUOISE", MediumTurquoise },
        { "MEDIUMVIOLETRED", MediumVioletRed },
        { "MIDNIGHTBLUE", MidnightBlue },
        { "MINTCREAM", MintCream },
        { "MISTYROSE", MistyRose },
        { "MOCCASIN", Moccasin },
        { "NAVAJOWHITE", NavajoWhite },
        { "NAVYBLUE", NavyBlue },
        { "OLDLACE", OldLace },
        { "OLIVE", Olive },
        { "OLIVEDRAB", OliveDrab },
        { "ORANGE", Orange },
        { "ORANGERED", OrangeRed },
        { "ORCHID", Orchid },
        { "PALEGOLDENROD", PaleGoldenrod },
        { "PALEGREEN", PaleGreen },
        { "PALETURQUOISE", PaleTurquoise },
        { "PALEVIOLETRED", PaleVioletRed },
        { "PAPAYAWHIP", PapayaWhip },
        { "PEACHPUFF", PeachPuff },
        { "PERU", Peru },
        { "PINK", Pink },
        { "PLUM", Plum },
        { "POWDERBLUE", PowderBlue },
        { "PURPLE", Purple },
        { "REBECCAPURPLE", RebeccaPurple },
        { "RED", Red },
        { "ROSYBROWN", RosyBrown },
        { "ROYALBLUE", RoyalBlue },
        { "SADDLEBROWN", SaddleBrown },
        { "SALMON", Salmon },
        { "SANDYBROWN", SandyBrown },
        { "SEAGREEN", SeaGreen },
        { "SEASHELL", Seashell },
        { "SIENNA", Sienna },
        { "SILVER", Silver },
        { "SKYBLUE", SkyBlue },
        { "SLATEBLUE", SlateBlue },
        { "SLATEGRAY", SlateGray },
        { "SNOW", Snow },
        { "SPRINGGREEN", SpringGreen },
        { "STEELBLUE", SteelBlue },
        { "TAN", Tan },
        { "TEAL", Teal },
        { "THISTLE", Thistle },
        { "TOMATO", Tomato },
        { "TRANSPARENT", Transparent },
        { "TURQUOISE", Turquoise },
        { "VIOLET", Violet },
        { "WEBGRAY", WebGray },
        { "WEBGREEN", WebGreen },
        { "WEBMAROON", WebMaroon },
        { "WEBPURPLE", WebPurple },
        { "WHEAT", Wheat },
        { "WHITE", White },
        { "WHITESMOKE", WhiteSmoke },
        { "YELLOW", Yellow },
        { "YELLOWGREEN", YellowGreen }
    };

    public static Color AliceBlue => new(4042850303u);

    public static Color AntiqueWhite => new(4209760255u);

    public static Color Aqua => new(16777215u);

    public static Color Aquamarine => new(2147472639u);

    public static Color Azure => new(4043309055u);

    public static Color Beige => new(4126530815u);

    public static Color Bisque => new(4293182719u);

    public static Color Black => new(255u);

    public static Color BlanchedAlmond => new(4293643775u);

    public static Color Blue => new(65535u);

    public static Color BlueViolet => new(2318131967u);

    public static Color Brown => new(2771004159u);

    public static Color Burlywood => new(3736635391u);

    public static Color CadetBlue => new(1604231423u);

    public static Color Chartreuse => new(2147418367u);

    public static Color Chocolate => new(3530104575u);

    public static Color Coral => new(4286533887u);

    public static Color CornflowerBlue => new(1687547391u);

    public static Color Cornsilk => new(4294499583u);

    public static Color Crimson => new(3692313855u);

    public static Color Cyan => new(16777215u);

    public static Color DarkBlue => new(35839u);

    public static Color DarkCyan => new(9145343u);

    public static Color DarkGoldenrod => new(3095792639u);

    public static Color DarkGray => new(2846468607u);

    public static Color DarkGreen => new(6553855u);

    public static Color DarkKhaki => new(3182914559u);

    public static Color DarkMagenta => new(2332068863u);

    public static Color DarkOliveGreen => new(1433087999u);

    public static Color DarkOrange => new(4287365375u);

    public static Color DarkOrchid => new(2570243327u);

    public static Color DarkRed => new(2332033279u);

    public static Color DarkSalmon => new(3918953215u);

    public static Color DarkSeaGreen => new(2411499519u);

    public static Color DarkSlateBlue => new(1211993087u);

    public static Color DarkSlateGray => new(793726975u);

    public static Color DarkTurquoise => new(13554175u);

    public static Color DarkViolet => new(2483082239u);

    public static Color DeepPink => new(4279538687u);

    public static Color DeepSkyBlue => new(12582911u);

    public static Color DimGray => new(1768516095u);

    public static Color DodgerBlue => new(512819199u);

    public static Color Firebrick => new(2988581631u);

    public static Color FloralWhite => new(4294635775u);

    public static Color ForestGreen => new(579543807u);

    public static Color Fuchsia => new(4278255615u);

    public static Color Gainsboro => new(3705462015u);

    public static Color GhostWhite => new(4177068031u);

    public static Color Gold => new(4292280575u);

    public static Color Goldenrod => new(3668254975u);

    public static Color Gray => new(3200171775u);

    public static Color Green => new(16711935u);

    public static Color GreenYellow => new(2919182335u);

    public static Color Honeydew => new(4043305215u);

    public static Color HotPink => new(4285117695u);

    public static Color IndianRed => new(3445382399u);

    public static Color Indigo => new(1258324735u);

    public static Color Ivory => new(4294963455u);

    public static Color Khaki => new(4041641215u);

    public static Color Lavender => new(3873897215u);

    public static Color LavenderBlush => new(4293981695u);

    public static Color LawnGreen => new(2096890111u);

    public static Color LemonChiffon => new(4294626815u);

    public static Color LightBlue => new(2916673279u);

    public static Color LightCoral => new(4034953471u);

    public static Color LightCyan => new(3774873599u);

    public static Color LightGoldenrod => new(4210742015u);

    public static Color LightGray => new(3553874943u);

    public static Color LightGreen => new(2431553791u);

    public static Color LightPink => new(4290167295u);

    public static Color LightSalmon => new(4288707327u);

    public static Color LightSeaGreen => new(548580095u);

    public static Color LightSkyBlue => new(2278488831u);

    public static Color LightSlateGray => new(2005441023u);

    public static Color LightSteelBlue => new(2965692159u);

    public static Color LightYellow => new(4294959359u);

    public static Color Lime => new(16711935u);

    public static Color LimeGreen => new(852308735u);

    public static Color Linen => new(4210091775u);

    public static Color Magenta => new(4278255615u);

    public static Color Maroon => new(2955960575u);

    public static Color MediumAquamarine => new(1724754687u);

    public static Color MediumBlue => new(52735u);

    public static Color MediumOrchid => new(3126187007u);

    public static Color MediumPurple => new(2473647103u);

    public static Color MediumSeaGreen => new(1018393087u);

    public static Color MediumSlateBlue => new(2070474495u);

    public static Color MediumSpringGreen => new(16423679u);

    public static Color MediumTurquoise => new(1221709055u);

    public static Color MediumVioletRed => new(3340076543u);

    public static Color MidnightBlue => new(421097727u);

    public static Color MintCream => new(4127193855u);

    public static Color MistyRose => new(4293190143u);

    public static Color Moccasin => new(4293178879u);

    public static Color NavajoWhite => new(4292783615u);

    public static Color NavyBlue => new(33023u);

    public static Color OldLace => new(4260751103u);

    public static Color Olive => new(2155872511u);

    public static Color OliveDrab => new(1804477439u);

    public static Color Orange => new(4289003775u);

    public static Color OrangeRed => new(4282712319u);

    public static Color Orchid => new(3664828159u);

    public static Color PaleGoldenrod => new(4008225535u);

    public static Color PaleGreen => new(2566625535u);

    public static Color PaleTurquoise => new(2951671551u);

    public static Color PaleVioletRed => new(3681588223u);

    public static Color PapayaWhip => new(4293907967u);

    public static Color PeachPuff => new(4292524543u);

    public static Color Peru => new(3448061951u);

    public static Color Pink => new(4290825215u);

    public static Color Plum => new(3718307327u);

    public static Color PowderBlue => new(2967529215u);

    public static Color Purple => new(2686513407u);

    public static Color RebeccaPurple => new(1714657791u);

    public static Color Red => new(4278190335u);

    public static Color RosyBrown => new(3163525119u);

    public static Color RoyalBlue => new(1097458175u);

    public static Color SaddleBrown => new(2336560127u);

    public static Color Salmon => new(4202722047u);

    public static Color SandyBrown => new(4104413439u);

    public static Color SeaGreen => new(780883967u);

    public static Color Seashell => new(4294307583u);

    public static Color Sienna => new(2689740287u);

    public static Color Silver => new(3233857791u);

    public static Color SkyBlue => new(2278484991u);

    public static Color SlateBlue => new(1784335871u);

    public static Color SlateGray => new(1887473919u);

    public static Color Snow => new(4294638335u);

    public static Color SpringGreen => new(16744447u);

    public static Color SteelBlue => new(1182971135u);

    public static Color Tan => new(3535047935u);

    public static Color Teal => new(8421631u);

    public static Color Thistle => new(3636451583u);

    public static Color Tomato => new(4284696575u);

    public static Color Transparent => new(4294967040u);

    public static Color Turquoise => new(1088475391u);

    public static Color Violet => new(4001558271u);

    public static Color WebGray => new(2155905279u);

    public static Color WebGreen => new(8388863u);

    public static Color WebMaroon => new(2147483903u);

    public static Color WebPurple => new(2147516671u);

    public static Color Wheat => new(4125012991u);

    public static Color White => new(uint.MaxValue);

    public static Color WhiteSmoke => new(4126537215u);

    public static Color Yellow => new(4294902015u);

    public static Color YellowGreen => new(2597139199u);
}