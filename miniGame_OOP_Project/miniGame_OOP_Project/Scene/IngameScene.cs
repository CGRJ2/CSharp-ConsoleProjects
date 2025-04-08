namespace miniGame_OOP_Project
{
    // 인게임 씬.
    // 맵 데이터 출력 (MapData에 저장되어 있는 맵타일, 포탈, 맵 안의 몬스터, npc 정보를  인스턴스로 불러와 출력)
    // 플레이어 이동 출력
    // 필드(포탈|NPC|몬스터|아이템) 상호작용 관리
    class IngameScene : Scene
    {
        public MapInstance nowMapInstance;

        public IngameScene()
        {
            // 기본 생성자
            nowMapInstance = new MapInstance("Village");
            GameManager.Instance.mapInstance = nowMapInstance;
        }

        // 다른 맵을 갈때.
        public void MoveToOtherMap(string mapName)
        {
            nowMapInstance = new MapInstance(mapName);
            GameManager.Instance.mapInstance = nowMapInstance;
        }


        // 인게임 기본 출력
        public override void Print()
        {
            nowMapInstance.nowMap.PrinfMap();
            GameManager.Instance.mapInstance = nowMapInstance;
        }
    }
}
