using System;
using System.Data;

namespace TurboRater
{
  /// <summary>
  /// If a property has this attribute then it means that this property 
  /// will be stored in a database under the table for its class 
  /// (see ClassStorageAttribute), under the database field with the same 
  /// name as the property, and with a database data type of DBDataType.
  /// </summary>
  [AttributeUsage(AttributeTargets.Property)]
  public sealed class PropertyStorageAttribute : Attribute
  {
    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="dbDataType">The type of data that this property will be 
    /// in the database. Float, Int, VarChar, etc.</param>
    public PropertyStorageAttribute(SqlDbType dbDataType)
    {
      this.m_dbDataType = dbDataType;
    }

    /// <summary>
    /// The type of data that this property will be in the database. 
    /// Float, Int, VarChar, etc.
    /// </summary>
    public SqlDbType DBDataType
    {
      get { return m_dbDataType; }
    }

    /// <summary>
    /// Is this property a saveable property? True (the default) if you
    /// want this property to get stored in the DB, otherwise false.
    /// </summary>
    public bool IsSaveable
    {
      get { return m_saveable; }
      set { m_saveable = value; }
    }
    /// <summary>
    /// Is this property an encrypted property?  True (Default is False) 
    /// if you want this property to be encrypted when saved to the database
    /// otherwise False.
    /// </summary>
    public bool IsEncrypted
    {
      get { return m_encrypted; }
      set { m_encrypted = value; }
    }

    /// <summary>
    /// Can this property be loaded from the DB? True (the default) if
    /// you want this property to get loaded from the DB, otherwise false.
    /// </summary>
    public bool IsLoadable
    {
      get { return m_loadable; }
      set { m_loadable = value; }
    }

    /// <summary>
    /// Is this property the database table key field? Default false, 
    /// set this to true for primary key fields in your tables.
    /// </summary>
    public bool IsKeyField
    {
      get { return m_isKeyField; }
      set { m_isKeyField = value; }
    }

    /// <summary>
    /// The size of the field. Applicable to VarChar or other DB data types
    /// that can have variable sizes.
    /// </summary>
    public int Size
    {
      get { return m_size; }
      set { m_size = value; }
    }

    /// <summary>
    /// Should this field allow nulls in the database? Defaults to true.
    /// </summary>
    public bool AllowNulls
    {
      get { return m_allowNulls; }
      set { m_allowNulls = value; }
    }

    /// <summary>
    /// The default value for this field in the database. Note that this
    /// will not backfill existing data, it only has an effect on new records.
    /// </summary>
    public Object DefaultValue
    {
      get { return m_defaultValue; }
      set { m_defaultValue = value; }
    }

    /// <summary>
    /// Is this property an ArrayList property? Default false, set this
    /// to true if the property you need to store is descended from an
    /// ArrayList.
    /// </summary>
    public bool IsArrayList
    {
      get { return m_isArrayList; }
      set { m_isArrayList = value; }
    }

    /// <summary>
    /// If the property you wish to store is of type ArrayList, this
    /// attribute tells the storage mechanism what data types will
    /// be in the list. For example, a list of drivers is an ArrayList,
    /// while the individual driver elements are of type AUDriver.
    /// </summary>
    public Type ListItemType
    {
      get { return m_listItemType; }
      set { m_listItemType = value; }
    }

    /// <summary>
    /// If the property being stored is a foreign key into another class/table,
    /// this tells the storage mechanism what data type the foreign key class is.
    /// </summary>
    public Type ForeignKeyClassType
    {
      get { return m_foreignKeyClassType; }
      set { m_foreignKeyClassType = value; }
    }

    /// <summary>
    /// If the property being stored is an enumerated type, this attribute
    /// tells the storage mechanism what enumerated type is being stored.
    /// </summary>
    public Type EnumerationType
    {
      get { return m_enumerationType; }
      set { m_enumerationType = value; }
    }

    /// <summary>
    /// Use this in conjunction with the EnumerationType property and the EnumerationValues
    /// property. This is the class type that is the holder for the constant array
    /// represented by EnumerationValues. Example:
    /// If the values array is ITC.Insurance.AU.AUConstants.LienHolderTypeChars, then this
    /// property would be typeof(AUConstants) and the EnumerationValues property would be
    /// "LienHolderTypeChars"
    /// </summary>
    public Type EnumerationConstHolderType
    {
      get { return m_enumerationConstHolderType; }
      set { m_enumerationConstHolderType = value; }
    }

    /// <summary>
    /// If you want to use an array of values for your enumerated type,
    /// set this property value to the fully qualified name of the 
    /// array of strings. Note that the array must be both public and
    /// static in order for the storage to work properly, and you must
    /// also set the EnumerationConstHolderType attribute too.
    /// </summary>
    public string EnumerationValues
    {
      get { return m_enumerationValues; }
      set { m_enumerationValues = value; }
    }

    /// <summary>
    /// If you want to override the name of the table where a property gets stored,
    /// use this attribute. Note that this is only valid for properties that are
    /// objects or lists; this has no effect on a property that's just a basic data
    /// type such as an int, string, enum, etc.
    /// </summary>
    public string OverrideTableName
    {
      get { return m_overrideTableName; }
      set { m_overrideTableName = value; }
    }

    /// <summary>
    /// If you set this value, then during saving/loading this property will be hidden
    /// from storage if the property was declared in the type specified here.
    /// </summary>
    public Type HideFromStorageType
    {
      get { return m_hideFromStorageType; }
      set { m_hideFromStorageType = value; }
    }

    private SqlDbType m_dbDataType;
    private bool m_saveable = true;
    private bool m_encrypted;
    private bool m_loadable = true;
    private bool m_isKeyField;
    private int m_size = ITCConstants.InvalidNum;
    private bool m_allowNulls = true;
    private Object m_defaultValue;
    private bool m_isArrayList;
    private Type m_listItemType;
    private Type m_foreignKeyClassType;
    private Type m_enumerationType;
    private string m_enumerationValues = "";
    private Type m_enumerationConstHolderType;
    private string m_overrideTableName = "";
    private Type m_hideFromStorageType;
  }

}
