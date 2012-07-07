﻿using System.ComponentModel;
using DataErrorInfo;

[InjectValidationAttribute]
public class PersonWithImplementation : INotifyPropertyChanged, IDataErrorInfo
{
    IDataErrorInfo validationTemplate;
    public PersonWithImplementation()
    {
        validationTemplate = (IDataErrorInfo) new ValidationTemplate(this);
    }

    public string this[string columnName]
    {
        get { return validationTemplate[columnName]; }
    }

    public string Error
    {
        get { return validationTemplate.Error; }
    }

    string givenNames;

    public string GivenNames
    {
        get { return givenNames; }
        set
        {
            if (value != givenNames)
            {
                givenNames = value;
                OnPropertyChanged("GivenNames");
            }
        }
    }

    string familyName;

    public string FamilyName
    {
        get { return familyName; }
        set
        {
            if (value != familyName)
            {
                familyName = value;
                OnPropertyChanged("FamilyName");
            }
        }
    }

    public virtual void OnPropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}