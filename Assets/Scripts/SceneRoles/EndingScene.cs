using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndingScene : MonoBehaviour {


	public Transform TextTransform;
	public CanvasGroup fade;
	public Image endingImage;
	public Sprite[] endingImages = new Sprite[9];
	string[] endingText = {
		"You Died",
		"You Died",
		"육체가 한계에 다다른 탓인지 조금 정신줄을 놓은 채로 잠이 들어 버렸었다.\n눈을 떠 보니  내 여자친구는 나와 제법 떨어진 거리에서 쓰러져 거칠게 숨을 몰아쉬고 있었다.\n\"왜그래? 어디 많이 아파?\"\n나를 바라보는 그녀의 동공이 심하게 흔들리며 간신히 입을 떼었다.\n\"아니…자기야 나 숨쉬기가 너무 힘들어…\"\n사람을 보면 사족을 못쓰는 좀비의 본성을 억누르는 것도 이제 한계에 다다른 것 처럼 보였다.\n그래…이대로 사랑하는 이를 따라 같이 하는 것도 나쁘지 않겠지...\n나는 그녀에게 다가가 손을 꼭 잡았다.\n\"이제 날 마음대로 해도 괜찮아...\"\n모든 것을 내려놓고 각오를 다졌단 내게 그녀는 말했다.\n\n\"나랑 약속 하나 해줘...남은 내 몫까지 살아주겠다고...\"\n\n\n-ENDING No.1-\n이젠 안녕...",
		"여느 날처럼 익숙하게 느껴졌던 그녀의 인기척이 오늘은 느껴지질 않는다.\n왠지 모를 불길한 예감은 기우이길 바랬지만, 텅 빈 잠자리와 책상 모퉁이 위에 올려진 편지 한장은 그런 내 기대를 무참히 무너뜨렸다.\n\n\"그동안 고맙고 또 행복했어. 너와 함께 한 시간들 모두 소중하게 간직할 거야.\n언제가 될 진 모르겠지만, 네 기억이 남아있는 동안은 널 계속 생각할게.\n혹시나 기억을 잃어버린 날 다시 만나게 된다면…주저하지 말고 날 없애줘...\n그리고 꼭 살아남아줘…인간으로 살지 못했던 남은 내 몫의 시간까지...\"\n\n\n-ENDING No.2-\n마지막 편지",
		"무언가 부시럭거리는 소리에 놀라 퍼뜩 잠에서 깨어났다.\n무슨 수상한 기척이였나 싶었지만, 그 정체는 내 가방을 뒤져 붕대를 꺼내 손발을 동동 감고 있던 내 여자친구였다. \n\n\"이렇게 하면 좀 더 안전할거야. 나 때문에 너까지 이렇게 되는 건 싫으니까...\"\n\n어디서 구했는지는 모르겠지만 마스크까지 쓰고 있었다. 쩔쩔매며 손에 감던 붕대를 적당히 마무리 지은 다음, 살포시 그녀의 손을 잡았다. 두툼한 붕대의 촉감이지만, 미미하게 느껴지는 온기를 느끼기엔 부족함이 없었다.\n\n이렇게라면...어떻게든 살아지겠지?\n\n\n-ENDING No.3-\n그래도 행복하니까...",
		"육체가 한계에 다다른 탓인지 생각보다 깊게 잠이 들었지만, 맹수의 그르릉거리는 소리 비슷한 것에 퍼뜩 눈이 떠졌다.\n그녀는 방 한 구석에서 흐리멍텅한 눈동자로 안광을 뿜고 있었고, 잠결에 들었던 짐승 소리를 우렁차게 내며 무시무시한 속도로 내게 달려들었다.\n전 여자친구였던 생물체의 습격을 가까스로 피한 뒤 어떻게 달렸는지 기억나지 않을 정도로 도망을 쳤고, 대로변에 버려진 차를 발견해 올라탈 수 있었다.\n정말 운이 좋다고 할 만한 건 차를 발견했던 것 보다, 한 뼘 차이로 목숨을 건질 수 있었던 내 처지였다. 좋든 싫든, 이젠 그녀와 이별을 해야 했다.\n걸어잠근 문을 쉴 새 없이 두드려대는 그녀를 뒤로한 채 악셀을 밟았다.\n내 흔적을 바쁘게 쫓아 달려오는 옛 그녀의 모습에선 이제 내가 사랑했던 이의 모습은 흔적조차 남지 않게 되어 버렸다.\n그래도 살아야지. 살아 내야지...\n\n\n-ENDING No.4-\nThe Beast",
		"이젠 한계다. 남은 내 인생을 이렇게 보낼 자신이 없다.\n다소 비인간적인 방법이지만, 지금으로서는 이 것이 최선일 것이다.\n이젠 떠돌아 다니는 것도, 예전처럼 살갑게 대화하는 것도 불가능하다.\n그래도 가능성을 놓고 싶진 않다.\n이렇게라도 살아남는다면….어떻게든...\n\n\n-ENDING No.5-\n사육",
		"아무래도…오늘이 인간으로서의 마지막 하루가 될 것….같다….\n잡아먹히….진….않았........지........만.........\n\n\n나…퀄럭…여치ㄴㅣ…..나…..묽….\n그래섥……...좀…..비…\n크뤄ㅜ허ㅓㅎ걱\n행….볽……..\n크ㅜ어러허헉..커…..\n큭…크뤅…쿼쿼ㅜ워루넝ㄹ걱겋….쿼퀔ㄱ….\n카카ㅏㅋ캌ㅋ쿠쿽…..으르르르르흐훵ㄱ…..쿽…그걱걱ㄱㄱ걱….\n라를ㅇ르커아가으어르러우어옹….크아어고긍아ㅇ으우거커라럴….\n크어라허ㅓ거으렇….크아억….카ㅡㄴ어러헉…….크크커…크어으엉…\n크커럭….컥헣걱….\n\n\n\n컥...\n♡\n\n\n-ENDING No.6-\n좀비엔딩",
		"어제 밤만 해도, 지금처럼 오늘의 일들을 정리하는 일은 없을 거라 생각했다.\n하지만 죽고자 한다면 산다 했었던가. 생존자 수색작전에 투입된 군인들에게 발견된 우리는 무사히 구조될 수 있었다.\n물론 좀비가 된 내 여자친구는 제법 까다로운 조사를 받았지만, 상당히 좀비화가 진행되었음에도 불구하고 이성을 유지한 특이한 사례가 되었고, 좀 더 심도있는 연구가 진행되고 치료가 된 후, 그녀의 혈청을 이용한 좀비 백신 개발에 성공할 수 있었다.\n\n다시 인간으로 돌아온 그녀가, 내게 말했다.\n\n\"사랑해. 포기하지 않아 줘서 고마워.\"\n\n-ENDING No.7-\nReset"
	};

	// Use this for initialization
	void Start () {
		int temp = PlayerPrefs.GetInt ("ending",0);
		endingImage.sprite = endingImages [temp];
		TextTransform.GetComponent<Text> ().text = endingText [temp];
		StartCoroutine ("scrolling");

	}


	IEnumerator scrolling()
	{
		
		while (TextTransform.position.y < 4) 
		{

			fade.alpha -= Time.deltaTime;
			TextTransform.Translate (0, Time.deltaTime, 0);
			if (Input.GetMouseButton (0))
				Time.timeScale = 3;
			else
				Time.timeScale = 1;

			yield return null;
		}

		while (fade.alpha < 1) 
		{
			fade.alpha += Time.deltaTime;
			if (Input.GetMouseButton (0))
				Time.timeScale = 4;
			else
				Time.timeScale = 1;
			yield return null;
		}
		Time.timeScale = 1;
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("ReloadScene");

	}







}
