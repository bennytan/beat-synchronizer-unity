﻿using System.Collections;

namespace SynchronizerData {

	// BeatValue determines which beat to synchronize with, and is specified for each BeatCounter instance.
	// (A sequence of beat values are specified for PatternCounter instances).
	public enum BeatValue {
		None,
		SixteenthBeat,
		SixteenthDottedBeat,
		EighthBeat,
		EighthDottedBeat,
		QuarterBeat,
		QuarterDottedBeat,
		HalfBeat,
		HalfDottedBeat,
		WholeBeat,
		WhoteDottedBeat
	}

	// BeatType is used to specify whether the beat value is an off-beat, normal beat (i.e. occurs in time with the 
	// expected beats in the music, not syncopated), a down-beat, or a pattern beat (a beat that occurs in the pattern counter).
	// This value is sent along with the notify message of when a beat occurs so that different action
	// may be taken for the different beat types.
	// This information is stored in a beatMask field in each BeatObserver instance.
	public enum BeatType {
		None		= 0,
		OffBeat		= 1,
		NormalBeat	= 2,
		DownBeat	= 4,
		PatternBeat = 8
	};

	// The decimal values associated with each beat value are used in calculating the sample position in the audio
	// where the beat will occur. The values array acts as a LUT, with index positions corresponding to BeatValue.
	// These values are relative to quarter beats (which have a value of 1).
	public struct BeatDecimalValues {
		private static float dottedBeatModifier = 1.5f;
		public static float[] values = {
			0f,
			4f, 4f/dottedBeatModifier,			// sixteenth, dotted sixteenth
			2f, 2f/dottedBeatModifier,			// eighth, dotted eighth
			1f, 1f/dottedBeatModifier,			// quarter, dotted quarter
			0.5f, 0.5f/dottedBeatModifier,		// half, dotted half
			0.25f, 0.25f/dottedBeatModifier		// whole, dotted whole
		};
	}

}