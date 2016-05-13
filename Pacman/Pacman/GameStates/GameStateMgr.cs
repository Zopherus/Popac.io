using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Popac.Core;
using Microsoft.Xna.Framework;

namespace Popac.GameStates
{
	class GameStateMgr : Manager
	{
		private GameState _curState = null;
		private GameState _lastState = null;

		public GameStateMgr(GameState startingState)
		{
			_curState = startingState;
		}

		public void ChangeGameState(GameState changeState)
		{
			_lastState = _curState;
			_curState = changeState;
		}

		public void RevertGameState()
		{
			_curState = _lastState;
			_lastState = null;
		}

		public void Update(GameTime gameTime)
		{
			if (_curState != null)
				_curState.Update(gameTime);
		}
	}
}
