﻿# フォルダ一括作成ツール

## 概要
このツールは、Unityプロジェクト内に複数のフォルダを一括で作成するためのエディタ拡張です。  
プロジェクト初期構成を整えるのに最適です。

![Image](https://github-production-user-asset-6210df.s3.amazonaws.com/124390814/468936249-928000f3-b865-468a-a751-226b7c118cac.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAVCODYLSA53PQK4ZA%2F20250722%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20250722T031810Z&X-Amz-Expires=300&X-Amz-Signature=d97a91f5eca386d40809556788a927fdaced5038803e49176c9b9040b0332e96&X-Amz-SignedHeaders=host)

## 起動方法
Unityエディタ上部メニューから  
`Tools > フォルダ一括作成`

## 使い方手順

### 1. 作成先ルートの設定
- デフォルトは `Assets` です。

### 2. フォルダリストの作成方法（2通り）

#### 個別編集モード
- 各行に1つずつフォルダ名を入力
- 「＋ フォルダを追加」で行を追加
- 「−」ボタンで削除可能
- ネスト（例: `Scripts/Manager`）にも対応

#### コピー＆ペースト編集モード
- テキストエリアに改行区切りでフォルダ名を一括入力
- ボタン説明:
  - ⬆ テキストをリストに反映：上のリストに反映
  - ⬇ リストをテキストに変換：下のエリアに出力（コピー可能）

### 3. 一括作成
- 「▶ フォルダを作成」ボタンを押すと、入力されたフォルダ構成に基づいてプロジェクト内にフォルダが作成されます。
