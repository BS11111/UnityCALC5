using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;


public class calculator : MonoBehaviour
{
    #region Fields
    public TextMeshProUGUI InputText;
    private double _result;
    private double _input;
    private double _input2;
    private double _input3;
    private double _input4;
    private double _input5;
    private double b;


    private string _operation;
    private string _currentInput;
    private bool _equalIsPressed;
    #endregion Fields

    #region Methods
    public void ClickNumber(int val)
    {
        Debug.Log($" check val: {val}");
        if (!string.IsNullOrEmpty(_currentInput))
        {
            if (_currentInput.Length < 10)
            {
                _currentInput += val;
            }
        }
        else
        {
            _currentInput = val.ToString();
        }
        InputText.text = $"{_currentInput}";
    }

    public void ClickOperation(string val)
    {
        Debug.Log($" ClickOperation val: {val}");
        if (_input == 0)
        {
            SetCurrentInput();
            _operation = val;
        }
        else
        {
            if (_equalIsPressed)
            {
                _equalIsPressed = false;
                _operation = val;
                _input2 = 0;
            }
            else
            {
                if (_operation.Equals(val, StringComparison.OrdinalIgnoreCase))
                {
                    Calculate();
                }
                else
                {
                    _operation = val;
                    _input2 = 0;
                }
            }
        }
    }

    public void ClickEqual(string val)
    {
        Debug.Log($" ClickEqual val: {val}");
        Calculate();
        _equalIsPressed = true;
    }

    private void Calculate()
    {
        if (_input != 0 && !string.IsNullOrEmpty(_operation))
        {
            SetCurrentInput();
            switch (_operation)
            {
                case "+":
                    _result = _input + _input2 + _input3 + _input4;
                    break;
                case "-":
                    _result = _input - _input2 - _input3 - _input4;
                    break;
                case "*":
                    _result = _input * _input2;
                    break;
                case "/":
                    _result = _input / _input2;
                    break;
                case "√":
                    _result = Math.Sqrt(_input); 
                    break;
                case ".":
                    _result = _input + (0.1 * _input2) ;
                    break;
                case "²":
                    _result = Math.Pow(_input, 2);
                    break;
                case "ctg":
                    _result = 1.0 / Math.Tan(_input);
                    break;
                    case "tg":
                    _result = Math.Tan(_input);
                    break;
                case "cos":
                    _result = Math.Cos(_input);
                    break;
                case "sin":
                    _result = Math.Sin(_input);
                    break;
            }
            
            if(_input != 0)
            {
             InputText.SetText(_result.ToString() + "         Recent          " + _input + _operation + _input2);
            }
            else
            {
                if(_input2 == 0)
                {
                    InputText.SetText(_result.ToString() + "         Recent          " + _input2 + _operation + _input);
                }                                          
            }
            _input = _result;
        }
    }

    private void SetCurrentInput()
    {
        if (!string.IsNullOrEmpty(_currentInput))
        {
            if (_input == 0)
            {
                _input = int.Parse(_currentInput);
            }
            else
            {
                _input2 = int.Parse(_currentInput);
            }
            _currentInput = "";
        }
    }
    public void ClearInput()
    {
        _currentInput = "";
        _input = 0;
        _input2 = 0;
        _result = 0;
        InputText.SetText("");
    }
    #endregion Methods
}
