﻿#nullable enable

using Windows.Globalization;

namespace Uno.Globalization.NumberFormatting;

internal class CurrencyData
{
	public int DefaultFractionDigits { get; set; }
	public string CurrencyCode { get; set; } = "";
	public string Symbol { get; set; } = "";
	public bool IsSymbolAfterNumber { get; set; }
	public bool AlwaysUseCurrencyCode { get; set; }

	#region Initialize
	public static readonly CurrencyData Empty = new CurrencyData();

	private static readonly CurrencyData _hnlCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.HNLCurrencyIdentifier, Symbol = "L.", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _aedCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.AEDCurrencyIdentifier, Symbol = "د.إ.‏", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _afnCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.AFNCurrencyIdentifier, Symbol = "؋", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _allCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.ALLCurrencyIdentifier, Symbol = "Lek", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _amdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.AMDCurrencyIdentifier, Symbol = "֏", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _angCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.ANGCurrencyIdentifier, Symbol = "NAƒ", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _aoaCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.AOACurrencyIdentifier, Symbol = "Kz", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _arsCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.ARSCurrencyIdentifier, Symbol = "ARS", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _audCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.AUDCurrencyIdentifier, Symbol = "AUD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _awgCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.AWGCurrencyIdentifier, Symbol = "ƒ", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _aznCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.AZNCurrencyIdentifier, Symbol = "₼", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _bamCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BAMCurrencyIdentifier, Symbol = "KM", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _bbdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BBDCurrencyIdentifier, Symbol = "BBD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _bdtCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BDTCurrencyIdentifier, Symbol = "৳", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _bgnCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BGNCurrencyIdentifier, Symbol = "лв.", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _bhdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BHDCurrencyIdentifier, Symbol = "د.ب.‏", DefaultFractionDigits = 3, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _bifCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BIFCurrencyIdentifier, Symbol = "FBu", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _bmdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BMDCurrencyIdentifier, Symbol = "BMD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _bndCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BNDCurrencyIdentifier, Symbol = "BND", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _bobCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BOBCurrencyIdentifier, Symbol = "Bs.", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _brlCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BRLCurrencyIdentifier, Symbol = "R$", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _bsdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BSDCurrencyIdentifier, Symbol = "BSD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _btnCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BTNCurrencyIdentifier, Symbol = "Nu.", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _bwpCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BWPCurrencyIdentifier, Symbol = "P", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _byrCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BYRCurrencyIdentifier, Symbol = "Br", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _bzdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BZDCurrencyIdentifier, Symbol = "BZ$", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _cadCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.CADCurrencyIdentifier, Symbol = "CAD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _cdfCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.CDFCurrencyIdentifier, Symbol = "FC", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _chfCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.CHFCurrencyIdentifier, Symbol = "CHF", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _clpCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.CLPCurrencyIdentifier, Symbol = "CLP", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _cnyCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.CNYCurrencyIdentifier, Symbol = "¥", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _copCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.COPCurrencyIdentifier, Symbol = "COP", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _crcCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.CRCCurrencyIdentifier, Symbol = "₡", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _cupCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.CUPCurrencyIdentifier, Symbol = "CUP", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _cveCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.CVECurrencyIdentifier, Symbol = "CVE", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _czkCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.CZKCurrencyIdentifier, Symbol = "Kč", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _djfCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.DJFCurrencyIdentifier, Symbol = "Fdj", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _dkkCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.DKKCurrencyIdentifier, Symbol = "kr.", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _dopCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.DOPCurrencyIdentifier, Symbol = "RD$", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _dzdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.DZDCurrencyIdentifier, Symbol = "DA", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _egpCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.EGPCurrencyIdentifier, Symbol = "ج.م.‏", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _ernCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.ERNCurrencyIdentifier, Symbol = "Nfk", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _etbCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.ETBCurrencyIdentifier, Symbol = "Br", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _eurCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.EURCurrencyIdentifier, Symbol = "€", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _fjdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.FJDCurrencyIdentifier, Symbol = "FJD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _fkpCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.FKPCurrencyIdentifier, Symbol = "£", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _gbpCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.GBPCurrencyIdentifier, Symbol = "£", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _gelCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.GELCurrencyIdentifier, Symbol = "₾", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _ghsCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.GHSCurrencyIdentifier, Symbol = "GH₵", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _gipCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.GIPCurrencyIdentifier, Symbol = "£", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _gmdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.GMDCurrencyIdentifier, Symbol = "D", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _gnfCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.GNFCurrencyIdentifier, Symbol = "FG", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _gtqCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.GTQCurrencyIdentifier, Symbol = "Q", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _gydCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.GYDCurrencyIdentifier, Symbol = "GYD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _hkdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.HKDCurrencyIdentifier, Symbol = "HKD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _ronCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.RONCurrencyIdentifier, Symbol = "lei", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _hrkCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.HRKCurrencyIdentifier, Symbol = "kn", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _htgCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.HTGCurrencyIdentifier, Symbol = "G", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _hufCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.HUFCurrencyIdentifier, Symbol = "Ft", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _idrCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.IDRCurrencyIdentifier, Symbol = "Rp", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _ilsCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.ILSCurrencyIdentifier, Symbol = "₪", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _inrCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.INRCurrencyIdentifier, Symbol = "₹", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _iqdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.IQDCurrencyIdentifier, Symbol = "د.ع.‏", DefaultFractionDigits = 3, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _irrCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.IRRCurrencyIdentifier, Symbol = "ريال", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _iskCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.ISKCurrencyIdentifier, Symbol = "kr.", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _jmdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.JMDCurrencyIdentifier, Symbol = "J$", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _jodCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.JODCurrencyIdentifier, Symbol = "د.ا.‏", DefaultFractionDigits = 3, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _jpyCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.JPYCurrencyIdentifier, Symbol = "¥", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _kesCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.KESCurrencyIdentifier, Symbol = "KSh", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _kgsCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.KGSCurrencyIdentifier, Symbol = "сом", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _khrCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.KHRCurrencyIdentifier, Symbol = "៛", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _kmfCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.KMFCurrencyIdentifier, Symbol = "CF", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _kpwCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.KPWCurrencyIdentifier, Symbol = "₩", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _krwCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.KRWCurrencyIdentifier, Symbol = "₩", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _kwdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.KWDCurrencyIdentifier, Symbol = "د.ك.‏", DefaultFractionDigits = 3, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _kydCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.KYDCurrencyIdentifier, Symbol = "KYD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _kztCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.KZTCurrencyIdentifier, Symbol = "₸", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _lakCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.LAKCurrencyIdentifier, Symbol = "₭", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _lbpCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.LBPCurrencyIdentifier, Symbol = "ل.ل.‏", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _lkrCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.LKRCurrencyIdentifier, Symbol = "Rs", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _lrdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.LRDCurrencyIdentifier, Symbol = "LRD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _lslCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.LSLCurrencyIdentifier, Symbol = "L", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _ltlCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.LTLCurrencyIdentifier, Symbol = "Lt", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _lvlCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.LVLCurrencyIdentifier, Symbol = "Ls", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _lydCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.LYDCurrencyIdentifier, Symbol = "د.ل.‏", DefaultFractionDigits = 3, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _madCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MADCurrencyIdentifier, Symbol = "DH", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _mdlCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MDLCurrencyIdentifier, Symbol = "L", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _mgaCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MGACurrencyIdentifier, Symbol = "Ar", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _mkdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MKDCurrencyIdentifier, Symbol = "ден.", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _mmkCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MMKCurrencyIdentifier, Symbol = "K", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _mntCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MNTCurrencyIdentifier, Symbol = "₮", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _mopCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MOPCurrencyIdentifier, Symbol = "MOP$", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _mroCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MROCurrencyIdentifier, Symbol = "UM", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _murCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MURCurrencyIdentifier, Symbol = "₨", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _mvrCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MVRCurrencyIdentifier, Symbol = "ރ.", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _mwkCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MWKCurrencyIdentifier, Symbol = "MK", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _mxnCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MXNCurrencyIdentifier, Symbol = "MXN", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _myrCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MYRCurrencyIdentifier, Symbol = "RM", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _mznCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MZNCurrencyIdentifier, Symbol = "MT", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _nadCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.NADCurrencyIdentifier, Symbol = "NAD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _ngnCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.NGNCurrencyIdentifier, Symbol = "₦", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _nioCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.NIOCurrencyIdentifier, Symbol = "C$", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _nokCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.NOKCurrencyIdentifier, Symbol = "kr", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _nprCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.NPRCurrencyIdentifier, Symbol = "रु", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _nzdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.NZDCurrencyIdentifier, Symbol = "NZD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _omrCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.OMRCurrencyIdentifier, Symbol = "ر.ع.‏", DefaultFractionDigits = 3, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _pabCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.PABCurrencyIdentifier, Symbol = "B/.", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _penCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.PENCurrencyIdentifier, Symbol = "S/", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _pgkCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.PGKCurrencyIdentifier, Symbol = "K", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _phpCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.PHPCurrencyIdentifier, Symbol = "₱", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _pkrCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.PKRCurrencyIdentifier, Symbol = "Rs", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _plnCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.PLNCurrencyIdentifier, Symbol = "zł", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _pygCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.PYGCurrencyIdentifier, Symbol = "₲", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _qarCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.QARCurrencyIdentifier, Symbol = "ر.ق.‏", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _rsdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.RSDCurrencyIdentifier, Symbol = "din.", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _rubCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.RUBCurrencyIdentifier, Symbol = "₽", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _rwfCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.RWFCurrencyIdentifier, Symbol = "RF", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _sarCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.SARCurrencyIdentifier, Symbol = "ر.س.‏", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _sbdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.SBDCurrencyIdentifier, Symbol = "SBD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _scrCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.SCRCurrencyIdentifier, Symbol = "SR", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _sdgCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.SDGCurrencyIdentifier, Symbol = "£", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _sekCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.SEKCurrencyIdentifier, Symbol = "kr", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _sgdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.SGDCurrencyIdentifier, Symbol = "SGD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _shpCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.SHPCurrencyIdentifier, Symbol = "£", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _sllCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.SLLCurrencyIdentifier, Symbol = "Le", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _sosCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.SOSCurrencyIdentifier, Symbol = "S", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _srdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.SRDCurrencyIdentifier, Symbol = "SRD", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _stdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.STDCurrencyIdentifier, Symbol = "Db", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _sypCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.SYPCurrencyIdentifier, Symbol = "ل.س.‏", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _szlCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.SZLCurrencyIdentifier, Symbol = "L", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _thbCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.THBCurrencyIdentifier, Symbol = "฿", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _tjsCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.TJSCurrencyIdentifier, Symbol = "смн", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _tmtCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.TMTCurrencyIdentifier, Symbol = "m.", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _tndCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.TNDCurrencyIdentifier, Symbol = "د.ت.‏", DefaultFractionDigits = 3, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _topCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.TOPCurrencyIdentifier, Symbol = "T$", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _tryCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.TRYCurrencyIdentifier, Symbol = "₺", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _ttdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.TTDCurrencyIdentifier, Symbol = "TT$", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _twdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.TWDCurrencyIdentifier, Symbol = "NT$", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _tzsCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.TZSCurrencyIdentifier, Symbol = "TSh", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _uahCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.UAHCurrencyIdentifier, Symbol = "₴", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _ugxCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.UGXCurrencyIdentifier, Symbol = "USh", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _usdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.USDCurrencyIdentifier, Symbol = "$", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _uyuCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.UYUCurrencyIdentifier, Symbol = "$U", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _uzsCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.UZSCurrencyIdentifier, Symbol = "so'm", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _vefCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.VEFCurrencyIdentifier, Symbol = "Bs.F.", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _vndCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.VNDCurrencyIdentifier, Symbol = "₫", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _vuvCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.VUVCurrencyIdentifier, Symbol = "VT", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _wstCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.WSTCurrencyIdentifier, Symbol = "WST", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = true };
	private static readonly CurrencyData _xafCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.XAFCurrencyIdentifier, Symbol = "FCFA", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _xcdCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.XCDCurrencyIdentifier, Symbol = "EC$", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _xofCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.XOFCurrencyIdentifier, Symbol = "CFA", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _xpfCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.XPFCurrencyIdentifier, Symbol = "F", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _xxxCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.XXXCurrencyIdentifier, Symbol = "", DefaultFractionDigits = 0, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _yerCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.YERCurrencyIdentifier, Symbol = "ر.ي.‏", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _zarCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.ZARCurrencyIdentifier, Symbol = "R", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _zmwCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.ZMWCurrencyIdentifier, Symbol = "K", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _zwlCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.ZWLCurrencyIdentifier, Symbol = "Z$", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _bynCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.BYNCurrencyIdentifier, Symbol = "Br", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _sspCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.SSPCurrencyIdentifier, Symbol = "£", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _stnCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.STNCurrencyIdentifier, Symbol = "Db", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _vesCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.VESCurrencyIdentifier, Symbol = "Bs.S", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };
	private static readonly CurrencyData _mruCurrencyData = new CurrencyData { CurrencyCode = CurrencyIdentifiers.MRUCurrencyIdentifier, Symbol = "UM", DefaultFractionDigits = 2, AlwaysUseCurrencyCode = false };

	#endregion

	public static CurrencyData GetCurrencyData(string currencyCode)
	{
		return currencyCode switch
		{
			CurrencyIdentifiers.HNLCurrencyIdentifier => _hnlCurrencyData,
			CurrencyIdentifiers.AEDCurrencyIdentifier => _aedCurrencyData,
			CurrencyIdentifiers.AFNCurrencyIdentifier => _afnCurrencyData,
			CurrencyIdentifiers.ALLCurrencyIdentifier => _allCurrencyData,
			CurrencyIdentifiers.AMDCurrencyIdentifier => _amdCurrencyData,
			CurrencyIdentifiers.ANGCurrencyIdentifier => _angCurrencyData,
			CurrencyIdentifiers.AOACurrencyIdentifier => _aoaCurrencyData,
			CurrencyIdentifiers.ARSCurrencyIdentifier => _arsCurrencyData,
			CurrencyIdentifiers.AUDCurrencyIdentifier => _audCurrencyData,
			CurrencyIdentifiers.AWGCurrencyIdentifier => _awgCurrencyData,
			CurrencyIdentifiers.AZNCurrencyIdentifier => _aznCurrencyData,
			CurrencyIdentifiers.BAMCurrencyIdentifier => _bamCurrencyData,
			CurrencyIdentifiers.BBDCurrencyIdentifier => _bbdCurrencyData,
			CurrencyIdentifiers.BDTCurrencyIdentifier => _bdtCurrencyData,
			CurrencyIdentifiers.BGNCurrencyIdentifier => _bgnCurrencyData,
			CurrencyIdentifiers.BHDCurrencyIdentifier => _bhdCurrencyData,
			CurrencyIdentifiers.BIFCurrencyIdentifier => _bifCurrencyData,
			CurrencyIdentifiers.BMDCurrencyIdentifier => _bmdCurrencyData,
			CurrencyIdentifiers.BNDCurrencyIdentifier => _bndCurrencyData,
			CurrencyIdentifiers.BOBCurrencyIdentifier => _bobCurrencyData,
			CurrencyIdentifiers.BRLCurrencyIdentifier => _brlCurrencyData,
			CurrencyIdentifiers.BSDCurrencyIdentifier => _bsdCurrencyData,
			CurrencyIdentifiers.BTNCurrencyIdentifier => _btnCurrencyData,
			CurrencyIdentifiers.BWPCurrencyIdentifier => _bwpCurrencyData,
			CurrencyIdentifiers.BYRCurrencyIdentifier => _byrCurrencyData,
			CurrencyIdentifiers.BZDCurrencyIdentifier => _bzdCurrencyData,
			CurrencyIdentifiers.CADCurrencyIdentifier => _cadCurrencyData,
			CurrencyIdentifiers.CDFCurrencyIdentifier => _cdfCurrencyData,
			CurrencyIdentifiers.CHFCurrencyIdentifier => _chfCurrencyData,
			CurrencyIdentifiers.CLPCurrencyIdentifier => _clpCurrencyData,
			CurrencyIdentifiers.CNYCurrencyIdentifier => _cnyCurrencyData,
			CurrencyIdentifiers.COPCurrencyIdentifier => _copCurrencyData,
			CurrencyIdentifiers.CRCCurrencyIdentifier => _crcCurrencyData,
			CurrencyIdentifiers.CUPCurrencyIdentifier => _cupCurrencyData,
			CurrencyIdentifiers.CVECurrencyIdentifier => _cveCurrencyData,
			CurrencyIdentifiers.CZKCurrencyIdentifier => _czkCurrencyData,
			CurrencyIdentifiers.DJFCurrencyIdentifier => _djfCurrencyData,
			CurrencyIdentifiers.DKKCurrencyIdentifier => _dkkCurrencyData,
			CurrencyIdentifiers.DOPCurrencyIdentifier => _dopCurrencyData,
			CurrencyIdentifiers.DZDCurrencyIdentifier => _dzdCurrencyData,
			CurrencyIdentifiers.EGPCurrencyIdentifier => _egpCurrencyData,
			CurrencyIdentifiers.ERNCurrencyIdentifier => _ernCurrencyData,
			CurrencyIdentifiers.ETBCurrencyIdentifier => _etbCurrencyData,
			CurrencyIdentifiers.EURCurrencyIdentifier => _eurCurrencyData,
			CurrencyIdentifiers.FJDCurrencyIdentifier => _fjdCurrencyData,
			CurrencyIdentifiers.FKPCurrencyIdentifier => _fkpCurrencyData,
			CurrencyIdentifiers.GBPCurrencyIdentifier => _gbpCurrencyData,
			CurrencyIdentifiers.GELCurrencyIdentifier => _gelCurrencyData,
			CurrencyIdentifiers.GHSCurrencyIdentifier => _ghsCurrencyData,
			CurrencyIdentifiers.GIPCurrencyIdentifier => _gipCurrencyData,
			CurrencyIdentifiers.GMDCurrencyIdentifier => _gmdCurrencyData,
			CurrencyIdentifiers.GNFCurrencyIdentifier => _gnfCurrencyData,
			CurrencyIdentifiers.GTQCurrencyIdentifier => _gtqCurrencyData,
			CurrencyIdentifiers.GYDCurrencyIdentifier => _gydCurrencyData,
			CurrencyIdentifiers.HKDCurrencyIdentifier => _hkdCurrencyData,
			CurrencyIdentifiers.RONCurrencyIdentifier => _ronCurrencyData,
			CurrencyIdentifiers.HRKCurrencyIdentifier => _hrkCurrencyData,
			CurrencyIdentifiers.HTGCurrencyIdentifier => _htgCurrencyData,
			CurrencyIdentifiers.HUFCurrencyIdentifier => _hufCurrencyData,
			CurrencyIdentifiers.IDRCurrencyIdentifier => _idrCurrencyData,
			CurrencyIdentifiers.ILSCurrencyIdentifier => _ilsCurrencyData,
			CurrencyIdentifiers.INRCurrencyIdentifier => _inrCurrencyData,
			CurrencyIdentifiers.IQDCurrencyIdentifier => _iqdCurrencyData,
			CurrencyIdentifiers.IRRCurrencyIdentifier => _irrCurrencyData,
			CurrencyIdentifiers.ISKCurrencyIdentifier => _iskCurrencyData,
			CurrencyIdentifiers.JMDCurrencyIdentifier => _jmdCurrencyData,
			CurrencyIdentifiers.JODCurrencyIdentifier => _jodCurrencyData,
			CurrencyIdentifiers.JPYCurrencyIdentifier => _jpyCurrencyData,
			CurrencyIdentifiers.KESCurrencyIdentifier => _kesCurrencyData,
			CurrencyIdentifiers.KGSCurrencyIdentifier => _kgsCurrencyData,
			CurrencyIdentifiers.KHRCurrencyIdentifier => _khrCurrencyData,
			CurrencyIdentifiers.KMFCurrencyIdentifier => _kmfCurrencyData,
			CurrencyIdentifiers.KPWCurrencyIdentifier => _kpwCurrencyData,
			CurrencyIdentifiers.KRWCurrencyIdentifier => _krwCurrencyData,
			CurrencyIdentifiers.KWDCurrencyIdentifier => _kwdCurrencyData,
			CurrencyIdentifiers.KYDCurrencyIdentifier => _kydCurrencyData,
			CurrencyIdentifiers.KZTCurrencyIdentifier => _kztCurrencyData,
			CurrencyIdentifiers.LAKCurrencyIdentifier => _lakCurrencyData,
			CurrencyIdentifiers.LBPCurrencyIdentifier => _lbpCurrencyData,
			CurrencyIdentifiers.LKRCurrencyIdentifier => _lkrCurrencyData,
			CurrencyIdentifiers.LRDCurrencyIdentifier => _lrdCurrencyData,
			CurrencyIdentifiers.LSLCurrencyIdentifier => _lslCurrencyData,
			CurrencyIdentifiers.LTLCurrencyIdentifier => _ltlCurrencyData,
			CurrencyIdentifiers.LVLCurrencyIdentifier => _lvlCurrencyData,
			CurrencyIdentifiers.LYDCurrencyIdentifier => _lydCurrencyData,
			CurrencyIdentifiers.MADCurrencyIdentifier => _madCurrencyData,
			CurrencyIdentifiers.MDLCurrencyIdentifier => _mdlCurrencyData,
			CurrencyIdentifiers.MGACurrencyIdentifier => _mgaCurrencyData,
			CurrencyIdentifiers.MKDCurrencyIdentifier => _mkdCurrencyData,
			CurrencyIdentifiers.MMKCurrencyIdentifier => _mmkCurrencyData,
			CurrencyIdentifiers.MNTCurrencyIdentifier => _mntCurrencyData,
			CurrencyIdentifiers.MOPCurrencyIdentifier => _mopCurrencyData,
			CurrencyIdentifiers.MROCurrencyIdentifier => _mroCurrencyData,
			CurrencyIdentifiers.MURCurrencyIdentifier => _murCurrencyData,
			CurrencyIdentifiers.MVRCurrencyIdentifier => _mvrCurrencyData,
			CurrencyIdentifiers.MWKCurrencyIdentifier => _mwkCurrencyData,
			CurrencyIdentifiers.MXNCurrencyIdentifier => _mxnCurrencyData,
			CurrencyIdentifiers.MYRCurrencyIdentifier => _myrCurrencyData,
			CurrencyIdentifiers.MZNCurrencyIdentifier => _mznCurrencyData,
			CurrencyIdentifiers.NADCurrencyIdentifier => _nadCurrencyData,
			CurrencyIdentifiers.NGNCurrencyIdentifier => _ngnCurrencyData,
			CurrencyIdentifiers.NIOCurrencyIdentifier => _nioCurrencyData,
			CurrencyIdentifiers.NOKCurrencyIdentifier => _nokCurrencyData,
			CurrencyIdentifiers.NPRCurrencyIdentifier => _nprCurrencyData,
			CurrencyIdentifiers.NZDCurrencyIdentifier => _nzdCurrencyData,
			CurrencyIdentifiers.OMRCurrencyIdentifier => _omrCurrencyData,
			CurrencyIdentifiers.PABCurrencyIdentifier => _pabCurrencyData,
			CurrencyIdentifiers.PENCurrencyIdentifier => _penCurrencyData,
			CurrencyIdentifiers.PGKCurrencyIdentifier => _pgkCurrencyData,
			CurrencyIdentifiers.PHPCurrencyIdentifier => _phpCurrencyData,
			CurrencyIdentifiers.PKRCurrencyIdentifier => _pkrCurrencyData,
			CurrencyIdentifiers.PLNCurrencyIdentifier => _plnCurrencyData,
			CurrencyIdentifiers.PYGCurrencyIdentifier => _pygCurrencyData,
			CurrencyIdentifiers.QARCurrencyIdentifier => _qarCurrencyData,
			CurrencyIdentifiers.RSDCurrencyIdentifier => _rsdCurrencyData,
			CurrencyIdentifiers.RUBCurrencyIdentifier => _rubCurrencyData,
			CurrencyIdentifiers.RWFCurrencyIdentifier => _rwfCurrencyData,
			CurrencyIdentifiers.SARCurrencyIdentifier => _sarCurrencyData,
			CurrencyIdentifiers.SBDCurrencyIdentifier => _sbdCurrencyData,
			CurrencyIdentifiers.SCRCurrencyIdentifier => _scrCurrencyData,
			CurrencyIdentifiers.SDGCurrencyIdentifier => _sdgCurrencyData,
			CurrencyIdentifiers.SEKCurrencyIdentifier => _sekCurrencyData,
			CurrencyIdentifiers.SGDCurrencyIdentifier => _sgdCurrencyData,
			CurrencyIdentifiers.SHPCurrencyIdentifier => _shpCurrencyData,
			CurrencyIdentifiers.SLLCurrencyIdentifier => _sllCurrencyData,
			CurrencyIdentifiers.SOSCurrencyIdentifier => _sosCurrencyData,
			CurrencyIdentifiers.SRDCurrencyIdentifier => _srdCurrencyData,
			CurrencyIdentifiers.STDCurrencyIdentifier => _stdCurrencyData,
			CurrencyIdentifiers.SYPCurrencyIdentifier => _sypCurrencyData,
			CurrencyIdentifiers.SZLCurrencyIdentifier => _szlCurrencyData,
			CurrencyIdentifiers.THBCurrencyIdentifier => _thbCurrencyData,
			CurrencyIdentifiers.TJSCurrencyIdentifier => _tjsCurrencyData,
			CurrencyIdentifiers.TMTCurrencyIdentifier => _tmtCurrencyData,
			CurrencyIdentifiers.TNDCurrencyIdentifier => _tndCurrencyData,
			CurrencyIdentifiers.TOPCurrencyIdentifier => _topCurrencyData,
			CurrencyIdentifiers.TRYCurrencyIdentifier => _tryCurrencyData,
			CurrencyIdentifiers.TTDCurrencyIdentifier => _ttdCurrencyData,
			CurrencyIdentifiers.TWDCurrencyIdentifier => _twdCurrencyData,
			CurrencyIdentifiers.TZSCurrencyIdentifier => _tzsCurrencyData,
			CurrencyIdentifiers.UAHCurrencyIdentifier => _uahCurrencyData,
			CurrencyIdentifiers.UGXCurrencyIdentifier => _ugxCurrencyData,
			CurrencyIdentifiers.USDCurrencyIdentifier => _usdCurrencyData,
			CurrencyIdentifiers.UYUCurrencyIdentifier => _uyuCurrencyData,
			CurrencyIdentifiers.UZSCurrencyIdentifier => _uzsCurrencyData,
			CurrencyIdentifiers.VEFCurrencyIdentifier => _vefCurrencyData,
			CurrencyIdentifiers.VNDCurrencyIdentifier => _vndCurrencyData,
			CurrencyIdentifiers.VUVCurrencyIdentifier => _vuvCurrencyData,
			CurrencyIdentifiers.WSTCurrencyIdentifier => _wstCurrencyData,
			CurrencyIdentifiers.XAFCurrencyIdentifier => _xafCurrencyData,
			CurrencyIdentifiers.XCDCurrencyIdentifier => _xcdCurrencyData,
			CurrencyIdentifiers.XOFCurrencyIdentifier => _xofCurrencyData,
			CurrencyIdentifiers.XPFCurrencyIdentifier => _xpfCurrencyData,
			CurrencyIdentifiers.XXXCurrencyIdentifier => _xxxCurrencyData,
			CurrencyIdentifiers.YERCurrencyIdentifier => _yerCurrencyData,
			CurrencyIdentifiers.ZARCurrencyIdentifier => _zarCurrencyData,
			CurrencyIdentifiers.ZMWCurrencyIdentifier => _zmwCurrencyData,
			CurrencyIdentifiers.ZWLCurrencyIdentifier => _zwlCurrencyData,
			CurrencyIdentifiers.BYNCurrencyIdentifier => _bynCurrencyData,
			CurrencyIdentifiers.SSPCurrencyIdentifier => _sspCurrencyData,
			CurrencyIdentifiers.STNCurrencyIdentifier => _stnCurrencyData,
			CurrencyIdentifiers.VESCurrencyIdentifier => _vesCurrencyData,
			CurrencyIdentifiers.MRUCurrencyIdentifier => _mruCurrencyData,
			_ => Empty,
		};
	}
}
