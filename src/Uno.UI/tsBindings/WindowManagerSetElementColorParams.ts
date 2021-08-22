/* TSBindingsGenerator Generated code -- this code is regenerated on each build */
class WindowManagerSetElementColorParams
{
	/* Pack=4 */
	public HtmlId : string;
	public Color : number;
	public static unmarshal(pData:number) : WindowManagerSetElementColorParams
	{
		const ret = new WindowManagerSetElementColorParams();
		
		{
			const ptr = Module.getValue(pData + 0, "*");
			if(ptr !== 0)
			{
				ret.HtmlId = String(Module.UTF8ToString(ptr));
			}
			else
			
			{
				ret.HtmlId = null;
			}
		}
		
		{
			ret.Color = Module.HEAPU32[(pData + 4) >> 2];
		}
		return ret;
	}
}
