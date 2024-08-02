





// The names of the blocks you want the script to monitor.
const string BLOCKS = @"
L1G 
R1G
";



List<IMyTerminalBlock> tbs = new List<IMyTerminalBlock>();

public Program() {
    Runtime.UpdateFrequency = UpdateFrequency.Update100;
    foreach( string s in BLOCKS.Split('\n') ){
        if( "" == s )  continue;
        IMyTerminalBlock tb = GridTerminalSystem.GetBlockWithName( s.Trim() );
        if( null != tb )  tbs.Add(tb); else Echo( "block \"" + s + "\" not found. skip" );
    }
    
}

public void Main(string argument, UpdateType updateSource) {
    string txt = "";
    
    
    IMyTextPanel lcd = (IMyTextPanel)GridTerminalSystem.GetBlockWithName("HUD LCD DISPLAY");
    if(lcd != null){
    lcd.WriteText("");
    }


    foreach( IMyTerminalBlock tb in tbs ){
        if( tb is IMyFunctionalBlock){
            IMyFunctionalBlock fb = tb as IMyFunctionalBlock;
            switch( fb.Enabled & fb.IsFunctional ){
                case true:  txt += ""; break;
                case false:  txt += ""; break;
            }
        } else {
            txt += "";
        }

        IMySlimBlock sb = tb.CubeGrid.GetCubeBlock(tb.Position);
        if( null != sb ){
            float pct = 100f * ( sb.BuildIntegrity - sb.CurrentDamage ) / sb.MaxIntegrity;
            txt += "  " + pct.ToString("0").PadLeft( 3, ' ' ) + "%";
        } else {
            txt += " ";
        }

        
    }  

  

            if(lcd != null){
            

            lcd.WriteText("\n  [L1]     [R1]\n" + txt);
           
            }
}           
    
    
    
    
    
    
    
    

    
    

