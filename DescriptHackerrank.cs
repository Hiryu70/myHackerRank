using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

	/*
	 * Complete the 'decryptPassword' function below.
	 *
	 * The function is expected to return a STRING.
	 * The function accepts STRING s as parameter.
	 */
	 public static string SwapLetter(string s, int first, int second)
	 {
		 var firstLetter = s[first];
		 var seceondLetter = s[second];

		 s = ReplaceAt(s, first, seceondLetter);
		 s = ReplaceAt(s, second, firstLetter);
		 return s;
	 }

	 public static string ReplaceAt(string input, int index, char newChar)
	 {
		 char[] chars = input.ToCharArray();
		 chars[index] = newChar;
		 return new string(chars);
	 }

	 public static List<int> GetNumbersIndexes(string s)
	 {
		 var numbers = new List<int>();
		 for (int i = 0; i < s.Length; i++)
		 { 
			 bool isNumeric = int.TryParse(s[i].ToString(), out int n);
			 if (isNumeric)
			 {
				 numbers.Add(i);
			 }
		 }

		 return numbers;
	 }

	 public static string DecodeNumbers(string s)
	 {
		 var numbersIndexes = GetNumbersIndexes(s);
		 for (int index = 0; index < numbersIndexes.Count / 2; index++)
		 {
			 s = SwapLetter(s, numbersIndexes[index], numbersIndexes[numbersIndexes.Count - 1 - index]);
		 }

		 s = s.Substring(numbersIndexes.Count / 2);

		 return s;
	 }

	public static string DecodeAsterisks(string s)
	{
		var asterisks = GetCryptedAsterisks(s);
		asterisks.Reverse();

		foreach (var asterisk in asterisks)
		{
			s = UncriptAsterisk(s, asterisk);
		}

		return s;
	}

	public static string UncriptAsterisk(string s, int index)
	 {
		 var firstChar = s[index - 2];
		 var secondChar = s[index - 1];

		 s = ReplaceAt(s, index - 2, secondChar);
		 s = ReplaceAt(s, index - 1, firstChar);
		 s = s.Remove(index, 1);
		 return s;
	 }

	public static List<int> GetCryptedAsterisks(string s)
	{
		var asterisks = new List<int>();
		for (int i = 0; i < s.Length - 2; i++)
		{
			if (CriptedAsterisk(s.Substring(i, 3)))
			{
				asterisks.Add(i + 2);
			}
		}

		return asterisks;
	}

	public static bool CriptedAsterisk(string substring)
	{
		if (char.IsUpper(substring[0]) 
		    && char.IsLower(substring[1]) 
		    && substring[2] == '*')
		{
			return true;
		}

		return false;
	}

	public static string decryptPassword(string s)
	{
		s = DecodeNumbers(s);
		s = DecodeAsterisks(s);

		return s;
	}

}

class Solution
{
	public static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		//string s = Console.ReadLine();

		//string result = Result.decryptPassword(s);

		//textWriter.WriteLine(result);

		//textWriter.Flush();
		//textWriter.Close();


		string result = Result.decryptPassword("yFn*NDFv*cJw*utuEi*usFo*NrQt*KJe*Me*XNXIIeUw*nEq*tLc*Xn*rwBl*VKDZd*WOtnetMd*haoolwTm*cempHk*mukiWx*RCPd*MJg*Zz*kaSw*Vf*wLf*kYm*KCwAg*KgonGz*Iq*SGEHl*oDm*OkYo*LhxSb*Kq*Ac*xlvYe*zTp*GDZl*VOZh*Vw*teHg*jjlrsGr*yHl*nYr*KHUb*pAz*Bf*Hp*Wb*QfCf*Gx*PZd*PgzBd*MqAl*Xk*AibFl*Gc*Zs*LJYf*PXn*Tc*ZDi*CSf*VxSz*ckriUv*KQj*naXw*SJQiUi*MusYf*xQg*VocpukMg*RIs*HSpKk*EcptRz*ADGAClBt*zhVs*Jo*DEsCj*ypIz*SXGOXt*lZb*Rp*DJf*KEq*vPe*ACQs*UIXh*Im*rYv*lEz*LZt*RHtPs*Fq*PYGh*Ja*fjOw*XTg*HydoZs*kAo*Mo*CQJNj*pZq*LFEj*Fn*Dq*cRb*EAAdMa*FAWj*Fd*NKUATh*Wp*yczFo*iWk*DjeyuZg*RQwMj*Mo*RJqXg*YbuzIq*OxfmitxIk*qaEv*Qo*xLy*Dc*Hg*xbqwIe*YbpowIp*bmDa*Tk*BGFo*VZp*CGatFb*AAw*VwtAs*IHVt*eCg*TZd*Nq*Cs*VBDm*Oc*sUc*IWu*pEw*BWgBf*WlmxnWc*gYx*Hs*RrbYc*Aw*Yy*bgEi*BSOjFk*INHf*tZj*XekhSi*Rv*YopDd*Kq*LfkQa*Jd*JQMn*HPJh*ZNf*OJXy*Fu*FxWx*XErhwnhWj*Gp*Wt*lHn*IQtVy*UcrRn*Kk*oQm*kSy*BcEg*OjIp*Ar*GttbLr*IQz*EXBg*ODu*Qk*TxgeWn*NMnPz*Jo*QKBy*UQHceId*Wt*xQb*ItLx*HQxOs*tVg*rUv*QPf*BFXm*UVrQw*RRe*Po*Gz*Dp*WKTjHc*xHp*LESgMi*DZc*gsWl*TILj*LIRu*aNu*XsodOy*PGh*gnBs*EWKWn*Xv*qedoJa*WlAz*NPMp*RcQz*Yz*Pi*sjGi*LSXRFPZh*MpXg*Fz*Ad*Mu*OVydOl*ANq*YIHFnFq*Ev*fNt*Bi*WIOg*NHBn*HnWm*He*PsFb*Pb*PSb*rYu*OUh*VwctQu*KGFDe*Vh*HjcybvMr*FukFz*HiIh*SBe*neAj*Kd*LvWa*JVOPMz*Ip*LFPj*syndkchAp*wkxEn*IQUp*FYCt*ODoQk*gRh*UOPyytakhTe*TOMWMEePe*uSr*OvPm*Pv*Vl*LXw*hGn*Pi*RGWXOfgweisQz*MSc*Gw*If*oIm*Yu*uWy*ExCs*ppyUq*DJSwjCi*wlaBz*NxZe*dBz*Pg*Rj*JxkWu*kaedPj*BDtQz*ACFVOhLs*Ff*WxcCq*KDBc*Ln*QBe*ERLh*jPs*WkHk*FKg*SODo*ZKnZy*HRhNv*PXUu*WSYJw*gWx*FSs*Zx*QOw*Xb*OJNGBv*UWUGg*ZTx*BKWn*CAh*Zv*RTpBv*XXVQlIw*RTu*VIa*OcCl*vUh*UIStazhXr*WMg*WUUu*MnWe*TBVRsvmePo*ICv*DqhrfhqGt*Ta*Bh*WrUc*myJh*PRKl*jlgMy*VYrziWf*MEZl*ntBp*EKi*Js*EHMyDn*VKCQxgTv*Vi*JBIdUq*CDTtbNt*HNMp*Oe*GNzznpIi*Hr*EEOhxZy*cUl*gDz*cRx*ZKs*TLdYl*Ql*pOq*TAcvjlQq*sPb*mSv*FIZPOLAPw*tgcghiSx*Kd*uAg*NMc*qzviAa*Cu*eznWy*KFEvVo*NPuhfDw*Ts*RgpcKp*pqFr*CjuOs*MVJcTj*byUg*Dy*AQrKb*Hc*WmynauNx*jrZl*zOa*MeRe*JXs*Wi*QHKEYYJz*kkxKz*MWFHKVt*Zp*HUWHzCu*DPKd*TYBEd*INVWw*BMHq*ZHj*Vb*TAVn*QZFe*LIGEmBg*QSv*ERZXs*Mc*PSgmKp*OFm*cqOs*ljOr*KKPPgmAk*SbkOm*RZx*rMg*OjTa*yRj*yjMn*Rs*Wi*ojJa*Ur*Rn*Lc*RQWi*EHd*AMaMl*St*iKn*PUOKg*kRe*JAEh*PPQf*ZexumZt*YdCl*nJb*pKl*Th*oeWb*EKjLk*KIirtXq*Ku*qqOm*UEu*YOXFz*BBPeZt*Ir*mgbDy*UGj*CONk*HMupGk*Er*RnxjaiQd*CTl*VIMx*xEf*EUFrdRd*FEPy*FKmxGv*NHrxbfziIs*CGoRr*yhdqSy*XRw*cHt*Av*EIKCYOXPHm*kgnyHd*XNLk*aXd*WIBPCHn*OPt*JXl*ZKBEu*qjVy*Oa*BtUe*Mv*EEqPq*mVj*xTm*EVp*qXi*Rm*Lb*Jl*MGwxSz*Cu*Dn*Oz*HRNv*EFptPn*rDl*GSVKm*SCi*YFJHr*GnHc*Dm*EBz*zugbWz*LJAx*ZOv*GYWFjrGr*Xp*Xt*fEy*RNt*Ga*HwOh*vOa*HVx*biPp*As*JyXd*ETDm*XsRe*iapKz*BvTr*LPq*TiAh*iYv*TWucptUd*yvQi*cDw*vdMb*LSRuDz*mDs*zDs*SYp*BWiJm*Gx*ADn*sJh*GIm*ZGg*pZp*IMl*smqXh*LeqwtjfupixNr*Fk*eVj*Jy*kSd*Bd*lFc*BIYXy*KZUv*QPBoIo*DCSMd*YiPf*ZqBj*LFiwNr*ZkPc*Uu*Ae*JLRr*We*Pq*GFNEipiZw*HbbdaXj*FxZm*Jo*Fo*TDhNs*VBo*ifEv*FtIq*Ln*oCo*REZDSgPz*SKQPg*IVZQSUWu*JYhgYw*Nj*Zn*LVt*VYJz*Nn*SFHtuCb*Hm*Ug*aLb*Dv*Xg*Cp*TQd*GXWBXLt*xPi*bskdQw*mgEf*Ga*YlPb*Gv*Wq*Ei*UKg*DYZm*lBy*yjzjxsQa*FwGk*RCo*JKipEo*Wj*Jy*IRj*WRFtfxPu*QlLa*Re*YOJi*jOa*JLHEv*IYFTBWYIx*GEy*SPc*AFTl*mUa*Ph*Au*mMn*INf*HfnbcMx*KRYyRd*Wq*VPZbvbAa*Ma*Gt*Yd*YIBPp*Ok*Hb*ZEMGRo*aurYq*Fl*jTe*eKg*uDf*Vu*ETv*oRp*NYEb*mZc*KPr*oOh*NTXp*shfCp*Ek*yQf*Hm*Lh*Cc*IOZNuOt*DfMr*qLf*fzvOp*Xn*Fq*Xi*Rm*Gk*Sb*YmPm*Be*Rg*CdxcIu*FyZi*VRZi*Ab*Gr*Hh*WaAu*Yf*HYr*fuYq*UUZq*ujWm*SOn*Dj*MWOGIn*QPi*NXi*mkdIx*JIBQGzKh*CASkcslunVu*Li*EONh*UkqttNw*TEc*gSf*gPf*Mi*DwQu*Cy*ccsqqkfupdGo*GMf*BUf*Dh*uAq*NQMf*hfcyblIa*NJhKg*WlIk*Hm*hVk*cNu*YPsBl*Aa*XSh*ZNALXXc*Dc*qQx*Uh*Zr*IMwOm*IKODu*Jg*Cg*Ow*VOc*VATb*csZn*Kf*JkPv*VNdDl*QYGp*Nh*MNCEXl*Xh*Wn*pOl*mGz*LgdbLm*YYdHb*bMi*cewsJz*FGHFo*Uy*Wd*rxLd*ZYBd*LCx*Hg*XVgsZv*PIq*JEfhGz*CVh*Jz*fBm*QoUw*OkHk*eXm*Nd*JbQh*uflWj*GQdGt*ugOy*gaBx*OpCo*bIk*Wn*Gx*Vr*PUPc*EBEn*ABmbppmnNx*sRg*Co*Hv*DKBHSJc*CyHi*SNXa*bnnUn*AHy*Ca*Mr*PIaaYp*Ck*lvJk*XvhHq*PzHg*HgjfZm*wKo*NammFp*OqFf*DRqaDv*VEq*YVgMy*JNABdnEr*FHNKYx*Es*Lo*IVWb*njalbFm*YbhAp*DSVs*Kg*GBAEp*QCZLBb*NKFxgUg*wZr*bLj*EXw*DDEUhIn*LXFoWf*mQm*Wo*lSz*VDz*CCZZxIp*MHs*PvoyeNb*Ws*eowgrXg*Qv*nccUd*GmdMk*BBQj*EwYq*KQHMQLo*TeaRo*mnwvDw*LPzWs*oVc*Ao*GwBu*XbYi*KPIHDcpLh*RZLFo*CKYm*Tg*fZw*hshRs*Gx*aUq*Dg*oYg*tCf*xRq*Mm*FAbFp*EWSIa*HLcoSk*oOw*FdzKt*Hf*KJOAJQYTZm*ooorOp*WJOUf*AGEa*CwkbGu*To*LEWHl*MPo*Nw*cOj*LMCv*wVu*irUr*Oq*uvjMj*jIq*Up*kFu*ZnrAo*gcLh*CujTz*Xx*uIo*DAbuMw*srLo*Ou*DSYMOfJk*OYk*Pe*UIe*WdxNt*IVu*TYsHb*eboDm*NABv*MLGVqjkjqRl*XoSn*sXy*KUGYTi*JAm*AYy*xtZq*Mp*Rx*DTCVGp*mMy*VaDb*hezjZo*yVo*iJs*Cj*Ro*sGv*Xt*eFn*Ed*EAXJMJCCw*Fl*BfsMw*JqcWm*Ka*KMSELHJy*DMYOSc*UCQw*FTWJr*EHy*KWFNTe*Ns*qySt*YjCt*LAJq*BNDqappFl*PqBt*Mh*TWLFIg*ktEs*jxQq*WKf*GBIs*abcqIq*YNBBrUw*AWJNVPmcSr*Ht*yLi*Zi*Xx*QKFBa*tCy*Yi*pLf*DNSGq*XEmBz*Xz*Bb*OTbMi*AbxibYz*vpQz*DZcCx*cOp*Xj*izBr*WXidLy*Uz*Tb*ASMJNQCvmAc*Jf*RLKVa*Hd*QXGd*Sk*xPy*blYc*qMk*nfMi*Dz*RwadnplDe*Si*KUWi*owVh*Lv*CRrFa*NvwbbclIl*nBo*VOh*SXv*WpMh*DJl*XqVf*cwctupfNn*FmJv*Nd*zzBu*VRp*Lq*cahkNz*iQv*miIf*Uz*RAymsdAr*Lq*DJJr*tiUy*XJu*XcVh*gddxzXe*PULXzJz*zllIv*UeGv*BQKRVUkktqwNb*GRTAx*YOz*Jv*ujTc*AlWo*Ij*GYEg*ISKr*IIqbGb*Gd*xNa*SzkpDt*EOk*SkUs*tBq*pEg*DDw*Qw*eEr*WFCRa*MEDixYd*XtiYh*gJy*uQk*Jx*jpDf*KIl*HBh*XYnBm*JSl*SYu*HkLk*HQGy*gkzOc*NptxYw*qbbdQn*BHNRZPbCv*TKLVJhmEa*nNf*laMg*hvviWq*Oe*kQp*mHj*ZhbLw*Vj*jyiZa*RVGBLs*Ap*qTf*vUi*WXTtWh*Nu*tunQk*yYs*uZv*MdDt*unBv*yCy*Xq*TJp*Be*UFggeEp*Sg*Jf*YRZCSxqehhAq*Xf*Fe*aadBf*jVl*SVNg*Ga*XRh*Hq*ltFc*HofskwNr*bCl*TBYcfqJm*Fk*QDx*sNs*drRn*Pv*TYSciNg*YRKt*omBz*Hq*Aw*Df*VUhRh*eNa*nYc*GQr*Hr*ENXcXv*Ta*BIqcmQg*NADFbCx*EWf*DHDm*VGFp*HNclIu*wLh*qLr*ViTx*iCv*SxTk*PNz*WARr*tlPc*Kd*VAKg*fbGn*BCCAOAk*Mp*DMQINd*Kp*FPLyHb*mzOi*VKHBSTf*gvhWf*Rt*BAMh*LJn*XmpzzMw*DFkFt*hKp*QOTFYDOQKxoxqLa*tucxnCy*Mn*ecngsWl*SRu*BnOh*Kh*DHCnHn*EESTl*pGp*ECFq*UICQp*mOh*gRu*mgLz*TKJCq*Bq*AZh*BJhJk*qSi*OKTe*IZVVqsAn*Al*XPJTMRyYj*Cf*TarAp*JVh*EuazqoLv*HIc*KNXXs*Em*Yk*nTh*iGt*Se*IJVf*Ei*DIq*Od*NXk*MrxqeMh*LguRw*OJl*UtmmmejgQl*ADMx*CAKYQKRhmMk*bbuvMb*wbHq*ahjpVb*hCh*XUt*UjpIj*ijVm*Sb*Py*rqdoMi*FeaqLw*xWi*RDRHe*zHy*Rb*VKKPDiLk*sczFn*mWt*gwUa*PEwQr*SscGs*XOMz*JrsIl*OuhsyEq*GGVOmQi*sPb*YtIl*jolkigJd*uZg*OVi*zIy*HCy*RWaKw*Xj*MFZUi*BNs*UKrKb*IUGkIp*IGj*HUx*AYKPBm*KHr*UtQz*UVvMs*Bn*Yl*AHQl*UtqVx*CsbtKl*tYm*Ts*Fl*ogDx*NJm*UJc*FNrJv*YNl*Fr*Mf*Cn*rOk*ekHy*Gw*Qo*PsqizxmngLs*HGbarWy*avRt*Rk*SNCp*MNWTc*wBn*DscNv*DTOlSj*QBIw*zDb*KqFp*LneRg*ZFCWkbvTc*Nh*uepEl*Gv*PORb*eauVi*GEGRo*xTa*Ya*zUk*Pq*EvxciJd*QBc*ACQq*AEFFr*vSm*KSz*XAxpodxzBh*AGr*SWo*Zk*IXPQi*NcQk*CSSTlGq*wvoEj*TirAp*OiIr*QrMr*Ps*Fw*Oc*apyRs*ZRq*IZh*JNr*TGb*IRcSz*XSg*LkOa*ROgLa*xlCp*yoDg*MFDXt*Mi*FXIUq*Jr*dLu*dKt*LzKz*Yk*Na*CFx*bPs*Bu*RWc*BUNCw*TRBkAi*NkPj*HHHu*TEz*lxbzmFx*SZPHTNk*Bs*Dr*jkJi*JCilhMd*olgmrRp*IQn*jpVr*kMv*EWEc*YRFg*JEv*BLh*MCiVe*pJt*NENq*BCoOe*TVUb*Vb*YHz*MJCLPnvXw*SPo*Nk*SViMw*Ud*kwqsbLa*DVz*SRm*AdwVw*LPLv*MTwyvgscIt*kIt*wBu*Vw*YAa*OHb*ouCk*YFaSl*sXa*NTVd*DEKUTd*lNm*bCm*eFp*gKl*NuPt*Il*ptMj*IRKMGdWo*OWw*becpoUj*RXUoNp*LIm*Am*Jp*GBh*ohWe*Ur*fmzyTm*pbDm*XjzJy*UhiiYh*RUMBz*qsxjhwWm*QTKl*FPrtJz*GQe*Lf*rdKb*DjYo*Tn*gafWa*HPMOx*XAIg*WjhwcPm*Pd*AKSk*VfUm*DXAlljLq*HKonLy*kkSa*kKt*Ro*Wf*qXb*NSKu*QZb*lDd*dQs*xBf*OXnHb*XmyzqHa*JcnfDx*mtxRs*vKg*VSMOp*ZcHt*tHz*Fz*GDu*Tr*Fl*hmfTh*dDn*Lz*Cq*oQx*Ix*Pl*MHYZj*muFa*rGu*cWb*FFISCAQAEWQPb*Ce*Py*fUo*tYl*Zm*STIk*DptwcTz*aAp*zYa*zGo*DNAj*Me*Nf*RLHKr*gGt*CPZOKQd*XuzfxixUt*Mw*Qj*WOYg*BUlkrAe*FSl*jAu*ANx*FBw*ZELFs*rSz*VMk*DgEn*oTi*rDa*Wr*rWa*YGBo*Tj*Uf*Xx*Ra*JXtqSu*Rc*awRd*PxTh*KHHx*wDm*Aw*EMcoPn*nuanUj*OwSd*lngKz*Ua*Ik*SFm*Nk*qzMp*iglVb*EDikLc*EUc*VGt*MESBi*yzwEt*Vo*HlSt*SZCk*WWZgWe*MQcGb*vXw*bRs*Nb*Ia*Oe*KjGd*DYz*Uq*EOu*Fc*KqkGt*oJx*Hp*TWOPl*Sn*lTs*SJHTVGJi*Ho*QTr*Ro*FAfLa*Px*WJt*TJu*YBf*uWx*VMQJuiDr*Di*TOZx*CmtrmNq*Kq*VJz*KTh*OUlokVw*Dk*ZnuVs*JhZs*KzRs*fyKt*ZGKbknwhivXx*HQTEb*uKe*URwfFd*CSj*Xa*fejKc*DGBf*kbcbohmhRt*Em*YAt*xQw*Pi*Jz*EIQLZm*Tz*StmMw*kWt*BtgkBg*ZmCu*ftyJq*mNx*Tw*cUm*TzmXl*NUd*AXe*UMTe*GZIc*YnCx*YTWPRpqDc*OQj*OGWBRWk*vjKa*BNIQy*FVYhPp*Rw*Mr*Ua*kjEc*QYv*QzHm*Wh*JCh*Yk*PEcUt*GPJOv*eXp*YAjEd*QsEr*ZnQw*oCz*hIb*xwcFx*WlJj*uHw*Mv*vBa*xiSd*UmEj*jVj*ODi*tWv*IhrUx*Dj*NoGj*EHOm*Fx*Yh*uVl*Ig*shDx*VPi*OZDXd*Td*KeRi*Ts*MPVp*EWYKBugqFb*AEXqWz*uiQc*BolUs*QjnUo*uNo*WnmWv*ZnbvBc*LADGHspNm*GDEBicHt*VGYDQg*CoqAr*GVr*KOATZMz*XfmtJj*egmRe*QGcNk*qpQe*DFGXRh*Gh*RKPOBEdWg*YHlwNt*Eg*EmGk*kcypAb*Ft*ULYJt*XdGu*IJt*SUz*TJj*Ni*Zp*gCf*EGc*aSk*EGEw*OxcTr*ABQXWp*RSAYQjrEh*Gi*WlwOb*Sk*LZULGs*TYj*ZlNr*qeFj*Bw*Wo*YNCJQPs*JSGsTm*Km*XAh*KARDp*CGx*GVk*QSkwagRw*lFh*oIf*AWXBy*pMv*Kr*Ro*Es*yJt*WMu*BNs*nUe*Yz*CboUh*mWi*GPFKu*Jv*IGu*LNt*YIEaYr*DEj*mimqSy*JibYy*RIn*ygCk*lZj*jYd*zkTq*PBZNLMq*UKt*TGe*Gc*eYj*gthahfGl*Oo*WJGq*WWcRl*tkhyUu*Bb*tnIy*Os*Bz*OamIi*UCl*dKg*Rv*DVk*XBWBr*XGGo*Qm*zcQg*YVXEIa*MYj*YLlvAc*QYXYEGRshkjYt*Ph*QjzFq*ZKABDOrSh*aJg*BaQq*Pz*Ty*UYe*Vq*iLk*JxeWx*GFSn*XJLg*OybBg*Eh*UOOBMFx*XUJb*zDl*bYu*RLh*Th*KDQSl*zzJt*YLMkUm*Hc*IPi*Wz*EttbllpnSr*PTx*Zn*ogbcozPk*Xd*Gg*IAs*SErTj*OWl*xevvSy*SDsjEa*CHrOf*pqktyGq*WEa*aVe*shlxOz*FHFFs*Uq*yvomEn*NJc*HBb*WEJIg*BLc*Lo*CXeYj*MCz*Hr*knpXw*Jb*ikbWo*NMCEDo*YARv*GhnCs*LPGBCz*MDUAZQu*qnFc*NfgrpsgyhmoNp*Wp*VBUMd*ZMpqhgId*Io*UOh*ENXg*ACWJvWl*Bu*pwRg*YeupXo*WWXr*RtGl*rcDt*Iq*FYOVi*Bm*MMVLAZeTa*BIqpzjGz*cWf*Jc*NTzJn*EykDw*AUARqrZh*Dy*VQw*Jv*KuifaLp*Rs*ifXc*Np*FZBWz*YJqXj*zJx*sHl*LABx*gKh*AfyqarzOr*VXv*XBqOb*Vz*Rl*rId*VQNtJc*My*QIjKt*UfvGa*CMWAGXy*OGo*EZruBw*AcJi*Xa*oCx*DzGd*jFh*Gh*As*WWo*SPGy*EnwxBl*INy*Ut*ZCBVRsxlvpxSh*oNs*DMSOo*MYASYy*Ut*SKk*He*UTZl*Vt*PRbvezuCk*Hr*Jz*PGgMj*Zi*Pz*Mc*MNCENfHi*Ws*MoOd*Ku*QOs*TBRn*Ie*QLnSk*Bc*oqOy*BIPSh*gwDy*nKd*Pi*LKy*hHv*JgclFd*Iu*QNFqfcFi*vqzigGz*mgtkevzZq*wUd*LZAlAb*hNl*ZcuBk*DbtdlmHa*NKv*Ep*GeMp*Tu*yMi*Hd*kkIf*MVr*Jz*TTg*AkcrfcCm*JpBn*AcKo*XazPt*usHr*ZDw*MgjKi*gOe*RKt*Df*TEa*RNsId*NNMi*PBoGv*ETc*UePt*YJrBc*WFAb*HDcNo*TBkVg*Pp*Ur*BSy*Fz*HsmDw*RSBORzqTk*eJs*MvPy*RJb*SIu*uCe*ivLi*kGs*QJe*plQw*BBfoIp*evsHx*TMPl*oMh*BrqYa*eJj*tNq*mtsOm*RepHe*bNw*Og*Ay*dWs*CFKWf*Xg*Wn*vWh*Eg*Xr*FWc*rjvfwYw*bcjSz*Xa*LZc*TpjIg*Gd*eoloIn*DAhmYn*RlnXc*It*GSXs*Id*drmQb*We*LOk*Jp*KGBxOi*QWt*pplqRw*aJj*FQh*SInZa*qgKm*Xn*Hn*oHm*AAVwDa*Ea*Zw*Md*Fz*dTq*brzcwQn*aquDd*VSojtAp*Ql*Rr*Gc*FDOWc*YAv*Sx*ZNo*Kj*OnCp*MRDd*Yg*HZs*ACUCILo*LOPQa*Tv*XCy*qQm*FEg*OYOzGn*TGa*QZFo*LOQeSs*Sh*FuHg*xMg*WKHGbJf*Rk*Uz*kaoYu*Jf*fNp*fgymEf*fVw*ZQTstXy*usnPn*HjMb*Xu*Yd*izDd*UITc*PTo*By*CRe*OdCq*SurGp*SFJSu*uGg*CSy*gJi*QWo*Ci*QRONc*GsjjdTl*Gi*LAKr*iyEz*QEjEf*PXWuKd*Oz*TsUi*Wu*vGw*IXtFh*nRf*jTo*Cg*WKEUVf*pgXz*gPm*ZCKTh*NRVlZp*UFPo*oEz*HUDuLo*VMDtAj*Oj*EPh*TRIAUSXSYWd*XHs*Fq*kzboCu*BUh*PQVDWu*Ma*Sb*dIg*KUx*Wa*BIETEFheQe*Kr*NLGn*WIGx*JBj*Hb*qcZx*XPh*pYq*IXj*Vs*Mr*Kc*asIc*UmGb*BdYy*BNUISj*FyJl*Zt");
		Console.WriteLine(result);
		Console.ReadKey();
	}
}
