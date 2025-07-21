#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;



/// <summary>
/// フォルダ一括作成ツール
/// </summary>
public class FolderCreator : EditorWindow
{
	private string baseFolder = "Assets";
	private List<string> foldersToCreate = new List<string> { "Scripts", "Scenes", "Prefabs" };
	private string folderListText = "";
	private Vector2 scroll;

	[MenuItem("Tools/フォルダ一括作成")]
	public static void ShowWindow()
	{
		GetWindow<FolderCreator>("フォルダ一括作成");
	}

	private void OnGUI()
	{

		// 作成先ルートパスの入力フィールド
		EditorGUILayout.LabelField("作成先ルートパス", EditorStyles.boldLabel);
		baseFolder = EditorGUILayout.TextField("ルート", baseFolder);


		// フォルダ名の入力フィールド
		EditorGUILayout.Space();
		EditorGUILayout.LabelField(new GUIContent("作成するフォルダ一覧（個別編集）", "このリストに入力したフォルダ名を一括で作成します"), EditorStyles.boldLabel);

		scroll = EditorGUILayout.BeginScrollView(scroll, GUILayout.Height(150));
		for (int i = 0; i < foldersToCreate.Count; i++)
		{
			EditorGUILayout.BeginHorizontal();
			foldersToCreate[i] = EditorGUILayout.TextField(foldersToCreate[i]);
			if (GUILayout.Button("−", GUILayout.Width(25)))	// 削除ボタン
			{
				foldersToCreate.RemoveAt(i);
				i--;
			}
			EditorGUILayout.EndHorizontal();
		}
		EditorGUILayout.EndScrollView();


		// フォルダ追加ボタン
		if (GUILayout.Button(new GUIContent("＋ フォルダを追加", "新しい空のフォルダ名をリストに追加します")))	// 追加ボタン
		{
			foldersToCreate.Add("");
		}



		// コピー＆ペースト用のボタンとテキストエリア
		EditorGUILayout.Space(15);
		EditorGUILayout.LabelField(new GUIContent("コピー＆ペースト用リスト編集", "改行区切りでフォルダ名を指定できます"), EditorStyles.boldLabel);

		EditorGUILayout.BeginHorizontal();	// ボタンを横並びに配置

		if (GUILayout.Button(new GUIContent("↓ リストをテキストに変換", "現在のフォルダリストを下のテキストエリアに出力します")))	// リストからテキストに変換ボタン
		{
			GUI.FocusControl(null);		// フォーカスを外す
			folderListText = string.Join("\n", foldersToCreate);
		}

		if (GUILayout.Button(new GUIContent("↑ テキストをリストに反映", "テキストエリアの内容を上のフォルダリストに変換します")))	// テキストからリストに変換ボタン
		{
			GUI.FocusControl(null);		// フォーカスを外す
			string[] lines = folderListText.Split('\n');
			foldersToCreate = new List<string>();
			foreach (var line in lines)
			{
				string trimmed = line.Trim();
				if (!string.IsNullOrEmpty(trimmed))
					foldersToCreate.Add(trimmed);
			}
		}

		EditorGUILayout.EndHorizontal();

		folderListText = EditorGUILayout.TextArea(folderListText, GUILayout.Height(100));	// テキストエリア



		EditorGUILayout.Space();

		if (GUILayout.Button("▶ フォルダを作成"))
		{
			CreateFolders();
		}
	}

	private void CreateFolders()
	{
		foreach (string folder in foldersToCreate)
		{
			if (string.IsNullOrWhiteSpace(folder)) continue;

			string path = Path.Combine(baseFolder, folder);
			if (!AssetDatabase.IsValidFolder(path))
			{
				Directory.CreateDirectory(path);
				Debug.Log($"Created: {path}");
			}
			else
			{
				Debug.Log($"Already exists: {path}");
			}
		}

		AssetDatabase.Refresh();
	}
}

#endif