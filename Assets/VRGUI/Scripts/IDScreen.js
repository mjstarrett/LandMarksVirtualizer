
static var stringToEdit:String = "";
static var stringToEdit2:String = "";
static var stringToEdit3:String = "";

function OnGUI(){
    
    GUILayout.BeginArea(Rect(250,100,800,300));
    GUILayout.BeginVertical();
    GUILayout.Button("Enter Participant ID",GUILayout.Width(800));
    GUILayout.BeginHorizontal();
        stringToEdit=GUILayout.TextField(stringToEdit,25);
    GUILayout.EndVertical();
    GUILayout.EndHorizontal();
    GUILayout.EndArea();

    GUILayout.BeginArea(Rect(250,200,800,300));
    GUILayout.BeginVertical();
    GUILayout.Button("Enter User",GUILayout.Width(800));
    GUILayout.BeginHorizontal();
        stringToEdit2=GUILayout.TextField(stringToEdit2,25);
    GUILayout.EndVertical();
    GUILayout.EndHorizontal();
    GUILayout.EndArea();

    GUILayout.BeginArea(Rect(250,300,800,300));
    GUILayout.BeginVertical();
    GUILayout.Button("Enter Directory",GUILayout.Width(800));
    GUILayout.BeginHorizontal();
        stringToEdit3=GUILayout.TextField(stringToEdit3,25);
    GUILayout.EndVertical();
    GUILayout.EndHorizontal();
    GUILayout.EndArea();

if(GUILayout.Button("Next")){
    Application.LoadLevel("StartScreen");
}

}
