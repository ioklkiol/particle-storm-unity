﻿using ParticleStorm.Core;
using ParticleStorm.Script;
using System;
using UnityEngine;

namespace ParticleStorm.Modules
{
	[Serializable]
	internal class ScriptModule : IParticleModule
	{
		public bool enabled;

		[Tooltip("Script method name for update.\nSee also: ParticleScript")]
		public string update;

		[Tooltip("Script method name for fixed update.\nSee also: ParticleScript")]
		public string fixedUpdate;

		[Tooltip("Script method name for late update.\nSee also: ParticleScript")]
		public string lateUpdate;

		[Tooltip("Parallel do script or not.\nIf enabled, it can improve time performence, " +
			"but will be not able to call UnityEngine functions in this script.")]
		public bool parallelUpdate;
		[Tooltip("Parallel do script or not.\nIf enabled, it can improve time performence, " +
			"but will be not able to call UnityEngine functions in this script.")]
		public bool parallelFixedUpdate;
		[Tooltip("Parallel do script or not.\nIf enabled, it can improve time performence, " +
			"but will be not able to call UnityEngine functions in this script.")]
		public bool parallelLateUpdate;

		internal ParticleScript.Script updateScript;
		internal ParticleScript.Script fixedUpdateScript;
		internal ParticleScript.Script lateUpdateScript;

		public void ApplicateOn(PSParticleSystem ps)
		{
			if (update != null && update != "")
				updateScript = ParticleScript.GetScript(update);
			else
				updateScript = null;

			if (fixedUpdate != null && fixedUpdate != "")
				fixedUpdateScript = ParticleScript.GetScript(fixedUpdate);
			else
				fixedUpdateScript = null;

			if (lateUpdate != null && lateUpdate != "")
				lateUpdateScript = ParticleScript.GetScript(lateUpdate);
			else
				lateUpdateScript = null;

			ps.scriptModule = this;
		}

		public void ApplicateOn(GOParticleSystem go)
		{
			throw new NotImplementedException();
		}
	}
}
