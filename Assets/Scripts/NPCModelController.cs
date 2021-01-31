using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCModelController : MonoBehaviour
{
	public Transform ModelAnchor;

	[Header("Prefab references")]
	public GoblinModelController GoblinModel;
	public OgreModelController OgreModel;
	public SkeletonModelController SkeletonModel;
	public GameObject ElementalModel;
	public GameObject SlimeModel;

	public bool TrySetModelFromName(NPCName npc)
	{
		bool loadedModel = true;
		switch(npc)
		{
			//Skeleton Models
			case NPCName.LadySerene:
				var ladySerene = Instantiate<SkeletonModelController>(SkeletonModel, ModelAnchor);
				ladySerene.ShowBow();
			break;
			case NPCName.SkeleTheMuscular:
				var skele = Instantiate<SkeletonModelController>(SkeletonModel, ModelAnchor);
				skele.HideAllAccessories();
			break;
			case NPCName.Anixaton:
				var anix = Instantiate<SkeletonModelController>(SkeletonModel, ModelAnchor);
				anix.ShowNecktie();
			break;
			case NPCName.Blook:
				var blook = Instantiate<SkeletonModelController>(SkeletonModel, ModelAnchor);
				blook.ShowMoustache();
			break;

			//Goblin Models
			case NPCName.Hornblin:
				var hornblin = Instantiate<GoblinModelController>(GoblinModel, ModelAnchor);
				hornblin.ShowHornblin();
			break;
			case NPCName.Gulum:
				var gulum = Instantiate<GoblinModelController>(GoblinModel, ModelAnchor);
				gulum.ShowGulum();
			break;

			//Ogre Models
			case NPCName.Molar:
				var molar = Instantiate<OgreModelController>(OgreModel, ModelAnchor);
				molar.ShowMolar();
			break;
			case NPCName.MrDoobig:
				var mrDoobig = Instantiate<OgreModelController>(OgreModel, ModelAnchor);
				mrDoobig.ShowMrDoobig();
			break;

			//Other Models
			case NPCName.Elemental:
				Instantiate(ElementalModel, ModelAnchor);
			break;
			case NPCName.Slime:
				Instantiate(SlimeModel, ModelAnchor);
			break;

			default:
				loadedModel = false;
				Debug.LogError("[NPCModelController] - Missing model for " + npc.ToString());
			break;
		}

		return loadedModel;
	}
}
