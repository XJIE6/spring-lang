﻿namespace Sample
{
using System;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.Text;
using JetBrains.Util;
using JetBrains.ReSharper.Plugins.Spring;


public  partial class SampleLexerGenerated : ILexer
{

  private TokenNodeType myCurrentTokenType = SpringTokenType.BAD_CHARACTER;

  public void Start()
  {
    Start(0, yy_buffer.Length, YYINITIAL);
  }

  public void Start(int startOffset, int endOffset, uint state)
  {
    yy_buffer_index = startOffset;
    yy_buffer_start = startOffset;
    yy_buffer_end = startOffset;
    yy_eof_pos = endOffset;
    yy_lexical_state = (int) state;
    myCurrentTokenType = null;
  }

  public void Advance()
  {
    myCurrentTokenType = null;
    LocateToken();
  }

  public struct TokenPosition
  {
    public TokenNodeType CurrentTokenType;
    public int YyBufferIndex;
    public int YyBufferStart;
    public int YyBufferEnd;
    public int YyLexicalState;
  }

  public object CurrentPosition
  {
    get
    {
      TokenPosition tokenPosition;
      tokenPosition.CurrentTokenType = myCurrentTokenType;
      tokenPosition.YyBufferIndex = yy_buffer_index;
      tokenPosition.YyBufferStart = yy_buffer_start;
      tokenPosition.YyBufferEnd = yy_buffer_end;
      tokenPosition.YyLexicalState = yy_lexical_state;
      return tokenPosition;
    }
    set
    {
      var tokenPosition = (TokenPosition) value;
      myCurrentTokenType = tokenPosition.CurrentTokenType;
      yy_buffer_index = tokenPosition.YyBufferIndex;
      yy_buffer_start = tokenPosition.YyBufferStart;
      yy_buffer_end = tokenPosition.YyBufferEnd;
      yy_lexical_state = tokenPosition.YyLexicalState;
    }
  }

  public TokenNodeType TokenType
  {
    get
    {
      LocateToken();
      return myCurrentTokenType;
    }
  }

  public int TokenStart
  {
    get
    {
      LocateToken();
      return yy_buffer_start;
    }
  }

  public int TokenEnd
  {
    get
    {
      LocateToken();
      return yy_buffer_end;
    }
  }

  public IBuffer Buffer
  {
    get
    {
      return yy_buffer;
    }
  }

  public uint LexerStateEx
  {
    get
    {
      return (uint) yy_lexical_state;
    }
  }

  public int LexemIndent { get { return 7; } }
  public int EOFPos { get { return yy_eof_pos; } }

  private void LocateToken()
  {
    if (myCurrentTokenType == null)
    {
      myCurrentTokenType = _locateToken();
    }
  }

  private TokenNodeType makeToken(TokenNodeType type)
  {
    return myCurrentTokenType = type;
  }

}

}
