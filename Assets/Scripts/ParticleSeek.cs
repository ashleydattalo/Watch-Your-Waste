﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSeek : MonoBehaviour {
	public Transform target;
	public float force;

	ParticleSystem ps;

	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
		ps.GetParticles(particles);

		for (int i = 0; i < particles.Length; i++) {
			ParticleSystem.Particle p = particles[i];
			Vector3 dirToTarget = target.position - p.position.normalized;
			Vector3 seekForce = dirToTarget * force * Time.deltaTime;
			p.velocity += seekForce;
			particles[i] = p;
		}

		ps.SetParticles(particles, particles.Length);
	}
}
