import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.ButtonGroup;
import javax.swing.JButton;
import javax.swing.JTextField;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.awt.event.ActionEvent;
import javax.swing.JRadioButton;
import javax.swing.JScrollPane;

import java.awt.Font;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import java.awt.Color;
import javax.swing.JTextArea;

class SuperMarket{
	private String departmentName;
	private String productName;
	private String producingCountry;
	private float retailPrice;
	private String supplier;
	public SuperMarket (String dN, String pN, String pC, float rP, String splr) {
		departmentName = dN;
		productName = pN;
		producingCountry = pC;
		retailPrice = rP;
		supplier = splr;
	}
	
	public String getdN()
	{
		return departmentName;
	}
	public String getpN()
	{
		return productName;
	}
	public String getpC()
	{
		return producingCountry;
	}
	public float getrP()
	{
		return retailPrice;
	}
	public String getsplr()
	{
		return supplier;
	}
}

class Toys extends SuperMarket{	
	private String ageGroup;
	private String Type;
	public Toys(String dN, String pN, String pC, float rP, String splr, String aG, String type) {
		super (dN, pN, pC, rP, splr);
		ageGroup = aG;
		Type = type;		
	}
	
	public String getAG()
	{
		return ageGroup;		
	}
	public String getType()
	{
		return Type;		
	}
}

class Fruit extends SuperMarket{	
	private int storageTime;
	private byte storageTemper;
	public Fruit(String dN, String pN, String pC, float rP, String splr, int sT, byte sTempr) {
		super(dN, pN, pC, rP, splr);
		storageTime = sT;
		storageTemper = sTempr;
	}
	
	public int getsT()
	{
		return storageTime;		
	}
	public byte getsTempr()
	{
		return storageTemper;		
	}
}

class GabaritniiTovar extends SuperMarket{
	private float height;
	private float width;
	private float lnght;
	public GabaritniiTovar (String dN, String pN, String pC, float rP, String splr, float h, float w, float l) {
		super(dN, pN, pC, rP, splr);
		height = h;
		width = w;
		lnght = l;
	}
	
	public float getHeight()
	{
		return height;		
	}
	public float getWidth()
	{
		return width;		
	}
	public float getLnght()
	{
		return lnght;		
	}
}


class Conteiner {

	public JFrame frame;

	private ArrayList<SuperMarket> list = new ArrayList<SuperMarket>();
	private int i = 0;
	/*
	public void addT(Toys to) {
		list.add(to);
		JOptionPane.showMessageDialog(frame,"Çàïèñü äîáàâëåíà!","Óâåäîìëåíèå",JOptionPane.INFORMATION_MESSAGE); 
	}
	public void addF(Fruit fr) {
		list.add(fr);
		JOptionPane.showMessageDialog(frame,"Çàïèñü äîáàâëåíà!","Óâåäîìëåíèå",JOptionPane.INFORMATION_MESSAGE); 
	}
	public void addGT(GabaritniiTovar gt) {
		list.add(gt);
		JOptionPane.showMessageDialog(frame,"Çàïèñü äîáàâëåíà!","Óâåäîìëåíèå",JOptionPane.INFORMATION_MESSAGE); 
	}
		*/
	public void addObj(SuperMarket sm) {
		list.add(sm);
	}
	public String show() {
		String str1 = "";
		for (i=0; i< list.size(); i++)		
		{
			String s = list.get(i).getdN();
			int j = i+1;
			switch(s) {
				case "Игрушки":
					Toys T = (Toys)list.get(i);					
					str1 = str1 + j + ")\nНазвание отдела: " + T.getdN() + "\nНазвние продукта: " + T.getpN() +
							 "\nСтрана-производитель: " + T.getpC() + "\nРозничная цена: " + T.getrP() + " р"
							 + "\nПоставщик: " +T. getsplr() + "\nВозраст: " + T.getAG() + "\nТип: " + T.getType() + "\n";					
					break;
					
				case "Фрукты":
					Fruit F = (Fruit)list.get(i);
					str1 = str1 + j + ")\nНазвание отдела: " + F.getdN() + "\nНазвние продукта: " + F.getpN() +
							 "\nСтрана-производитель: " + F.getpC() + "\nРозничная цена: " + F.getrP() + " р"
							 + "\nПоставщик: " +F.getsplr() + "\nВремя хранения: " + F.getsT() + " дней" + "\nТемпература хранения: " + F.getsTempr() + "\n";
					break;
				case "Габаритные товары":
					GabaritniiTovar GT = (GabaritniiTovar)list.get(i);
					str1 = str1 +j + ")\nНазвание отдела: " + GT.getdN() + "\nНазвние продукта: " + GT.getpN() +
							 "\nСтрана-производитель: " + GT.getpC() + "\nРозничная цена: " + GT.getrP() + " р"
							 + "\nПоставщик: " + GT.getsplr() + "\nВысота: " + GT.getHeight()+ " м" + "\nШирина: " + GT.getWidth() + " м"
							 + "\nДлина: " + GT.getLnght()+ " м\n";
					break;
				default: System.out.println("Error");
			}	 		
		}
		return str1;
	}
}


public class MyProject {
	public JTextArea textArea;
	public byte i = 0;
	private JFrame frame;	
	private JTextField tF1;
	private JTextField tF2;
	private JTextField tF3;
	private JTextField tF4;
	private JTextField tF5;
	private JTextField tF6;
	private JTextField tF7;
	private JTextField tF8;
	public Conteiner C = new Conteiner();
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					MyProject window = new MyProject();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public MyProject() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.getContentPane().setBackground(Color.WHITE);
		frame.setBounds(100, 100, 546, 442);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);
		
		JLabel Label_6 = new JLabel("\u0412\u043E\u0437\u0440\u0430\u0441\u0442\u043D\u0430\u044F \u0433\u0440\u0443\u043F\u043F\u0430");
		Label_6.setFont(new Font("Tahoma", Font.PLAIN, 12));
		Label_6.setBounds(295, 95, 109, 16);
		frame.getContentPane().add(Label_6);
		
		JLabel Label_7 = new JLabel("\u0422\u0438\u043F");
		Label_7.setFont(new Font("Tahoma", Font.PLAIN, 12));
		Label_7.setBounds(378, 124, 26, 16);
		frame.getContentPane().add(Label_7);
		
		JLabel Label_8 = new JLabel("\u0414\u043B\u0438\u043D\u0430");
		Label_8.setFont(new Font("Tahoma", Font.PLAIN, 12));
		Label_8.setBounds(365, 156, 45, 13);
		frame.getContentPane().add(Label_8);
		Label_8.setText("");
		
		
		//RADIO BTNS//////////////////////////////////
		JRadioButton rbTOYS = new JRadioButton("\u0418\u0433\u0440\u0443\u0448\u043A\u0438");
		rbTOYS.setBackground(Color.WHITE);
		rbTOYS.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				i = 1;
				tF1.setText("Игрушки");
				tF2.setEditable(true);
				tF3.setEditable(true);
				tF4.setEditable(true);
				tF5.setEditable(true);
				tF6.setEditable(true);
				tF7.setEditable(true);				
				Label_6.setBounds(295, 95, 109, 16);
				Label_6.setText("Возрастная группа");
				Label_7.setBounds(378, 124, 26, 16);
				Label_7.setText("Тип");
				Label_8.setText("");
				tF8.setVisible(false);	
			}
		});
		rbTOYS.setFont(new Font("Tahoma", Font.PLAIN, 12));
		rbTOYS.setBounds(21, 37, 103, 21);
		frame.getContentPane().add(rbTOYS);
		JRadioButton rbFRUIT = new JRadioButton("\u0424\u0440\u0443\u043A\u0442\u044B");
		rbFRUIT.setBackground(Color.WHITE);
		rbFRUIT.addActionListener(new ActionListener() {			
			public void actionPerformed(ActionEvent e) {
				i = 2;
				tF1.setText("Фрукты");
				tF2.setEditable(true);
				tF3.setEditable(true);
				tF4.setEditable(true);
				tF5.setEditable(true);
				tF6.setEditable(true);
				tF7.setEditable(true);
				Label_6.setBounds(283, 95, 123, 16);
				Label_6.setText("Max время хранения");
				Label_7.setBounds(268, 124, 136, 16);
				Label_7.setText("Температура хранения");
				Label_8.setText("");
				tF8.setVisible(false);
			}
		});
		rbFRUIT.setFont(new Font("Tahoma", Font.PLAIN, 12));
		rbFRUIT.setBounds(214, 37, 67, 21);
		frame.getContentPane().add(rbFRUIT);
		
		JRadioButton rbGABTOV = new JRadioButton("\u0413\u0430\u0431\u0430\u0440\u0438\u0442\u043D\u044B\u0435 \u0442\u043E\u0432\u0430\u0440\u044B");
		rbGABTOV.setBackground(Color.WHITE);
		rbGABTOV.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				i = 3;
				tF1.setText("Габаритные товары");
				tF2.setEditable(true);
				tF3.setEditable(true);
				tF4.setEditable(true);
				tF5.setEditable(true);
				tF6.setEditable(true);
				tF7.setEditable(true);
				tF8.setEditable(true);
				Label_6.setBounds(364, 95, 40, 16);
				Label_6.setText("Высота");
				Label_7.setBounds(359, 124, 45, 16);
				Label_7.setText("Ширина");
				Label_8.setText("Длина");
				tF8.setVisible(true);
			}
		});
		rbGABTOV.setFont(new Font("Tahoma", Font.PLAIN, 12));
		rbGABTOV.setBounds(369, 37, 143, 21);
		frame.getContentPane().add(rbGABTOV);
		
		ButtonGroup MyGroup = new ButtonGroup();
		MyGroup.add(rbTOYS);
		MyGroup.add(rbFRUIT);
		MyGroup.add(rbGABTOV);
			
		
		///////////////////////////////////////////////
		JLabel Label_11 = new JLabel("\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0442\u043E\u0432\u0430\u0440 \u0434\u043B\u044F \u0434\u043E\u0431\u0430\u0432\u043B\u0435\u043D\u0438\u044F");
		Label_11.setBackground(Color.WHITE);
		Label_11.setFont(new Font("Tahoma", Font.BOLD, 14));
		Label_11.setBounds(137, 10, 270, 21);
		frame.getContentPane().add(Label_11);
		
		JLabel Label_22 = new JLabel("\u0417\u0430\u043F\u043E\u043B\u043D\u0438\u0442\u0435 \u043F\u043E\u043B\u044F");
		Label_22.setFont(new Font("Tahoma", Font.BOLD, 13));
		Label_22.setBounds(31, 64, 200, 21);
		frame.getContentPane().add(Label_22);
		
		tF1 = new JTextField();
		tF1.setEditable(false);
		tF1.setBounds(148, 95, 115, 20);
		frame.getContentPane().add(tF1);
		tF1.setColumns(10);
		
		tF2 = new JTextField();
		tF2.setEditable(false);
		tF2.setBounds(157, 124, 96, 20);
		frame.getContentPane().add(tF2);
		tF2.setColumns(10);
		
		tF3 = new JTextField();
		tF3.setEditable(false);
		tF3.setBounds(157, 153, 96, 20);
		frame.getContentPane().add(tF3);
		tF3.setColumns(10);
		
		tF4 = new JTextField();
		tF4.setEditable(false);
		tF4.setBounds(157, 182, 96, 20);
		frame.getContentPane().add(tF4);
		tF4.setColumns(10);
		
		tF5 = new JTextField();
		tF5.setEditable(false);
		tF5.setBounds(157, 211, 96, 20);
		frame.getContentPane().add(tF5);
		tF5.setColumns(10);
		
		tF6 = new JTextField();
		tF6.setEditable(false);
		tF6.setBounds(416, 95, 96, 20);
		frame.getContentPane().add(tF6);
		tF6.setColumns(10);
		
		tF7 = new JTextField();
		tF7.setEditable(false);
		tF7.setBounds(416, 124, 96, 20);
		frame.getContentPane().add(tF7);
		tF7.setColumns(10);
		
		tF8 = new JTextField();
		tF8.setEditable(false);
		tF8.setBounds(416, 153, 96, 20);
		frame.getContentPane().add(tF8);
		tF8.setColumns(10);
		tF8.setVisible(false);
		
		JLabel Label_1 = new JLabel("\u041D\u0430\u0437\u0432\u0430\u043D\u0438\u0435 \u043E\u0442\u0434\u0435\u043B\u0430");
		Label_1.setFont(new Font("Tahoma", Font.PLAIN, 12));
		Label_1.setBounds(41, 95, 103, 13);
		frame.getContentPane().add(Label_1);
		
		JLabel Label_2 = new JLabel("\u041D\u0430\u0437\u0432\u0430\u043D\u0438\u0435 \u0442\u043E\u0432\u0430\u0440\u0430");
		Label_2.setFont(new Font("Tahoma", Font.PLAIN, 12));
		Label_2.setBounds(43, 124, 103, 16);
		frame.getContentPane().add(Label_2);
		
		JLabel Label_3 = new JLabel("\u0421\u0442\u0440\u0430\u043D\u0430-\u043F\u0440\u043E\u0438\u0437\u0432\u043E\u0434\u0438\u0442\u0435\u043B\u044C");
		Label_3.setFont(new Font("Tahoma", Font.PLAIN, 12));
		Label_3.setBounds(10, 156, 136, 13);
		frame.getContentPane().add(Label_3);
		
		JLabel Label_4 = new JLabel("\u0420\u043E\u0437\u043D\u0438\u0447\u043D\u0430\u044F \u0446\u0435\u043D\u0430");
		Label_4.setFont(new Font("Tahoma", Font.PLAIN, 12));
		Label_4.setBounds(45, 182, 96, 16);
		frame.getContentPane().add(Label_4);
		
		JLabel Label_5 = new JLabel("\u041F\u043E\u0441\u0442\u0430\u0432\u0449\u0438\u043A");
		Label_5.setFont(new Font("Tahoma", Font.PLAIN, 12));
		Label_5.setBounds(73, 213, 67, 13);
		frame.getContentPane().add(Label_5);
		
		JButton btnADD = new JButton("\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C");
		btnADD.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
					switch (i) {
						case 1:							
							String nD = tF1.getText();
							String nameP = tF2.getText();	
							String cP = tF3.getText();
							String sal_str = tF4.getText();	float sal = Float.parseFloat(sal_str);
							String sp = tF5.getText();
							String ag = tF6.getText();
							String ty = tF7.getText();
							Toys MyT = new Toys (nD, nameP, cP, sal,sp, ag, ty);
							C.addObj(MyT);
							break;
						case 2:
							String nDF = tF1.getText();
							String namePF = tF2.getText();
							String cPF = tF3.getText();
							String str_salF = tF4.getText(); float salF = Float.parseFloat(str_salF);
							String spF = tF5.getText();
							String str_st = tF6.getText(); int st = Integer.parseInt(str_st);
							String str_tempr = tF7.getText(); byte tempr = Byte.parseByte(str_tempr);
							Fruit MyF = new Fruit (nDF, namePF, cPF, salF,spF, st, tempr);
							C.addObj(MyF);
							break;
						case 3:
							String nDGT = tF1.getText();
							String namePGT = tF2.getText();
							String cPGT = tF3.getText();
							String str_salGT = tF4.getText(); float salGT = Float.parseFloat(str_salGT);
							String spGT = tF5.getText();
							String str_h = tF6.getText(); float h = Float.parseFloat(str_h);
							String str_w = tF7.getText(); float w = Float.parseFloat(str_w);
							String str_l = tF8.getText(); float l = Float.parseFloat(str_l);
							GabaritniiTovar MyGT = new GabaritniiTovar (nDGT, namePGT, cPGT, salGT,spGT, h, w, l);
							C.addObj(MyGT);
							break;
						default: JOptionPane.showMessageDialog(frame,"Ошибка!","Уведомление",JOptionPane.ERROR_MESSAGE);
					}					
			}
		});
		btnADD.setFont(new Font("Tahoma", Font.PLAIN, 12));
		btnADD.setBounds(55, 250, 90, 21);
		frame.getContentPane().add(btnADD);
		
		JButton btnCLEAR = new JButton("\u041E\u0447\u0438\u0441\u0442\u0438\u0442\u044C");
		btnCLEAR.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				tF2.setText("");
				tF3.setText("");
				tF4.setText("");
				tF5.setText("");
				tF6.setText("");
				tF7.setText("");
				tF8.setText("");
			}
		});
		btnCLEAR.setFont(new Font("Tahoma", Font.PLAIN, 12));
		btnCLEAR.setBounds(157, 251, 90, 21);
		frame.getContentPane().add(btnCLEAR);
		
		JButton btnEXIT = new JButton("\u0412\u044B\u0445\u043E\u0434");
		btnEXIT.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				System.exit(0);
			}
		});
		btnEXIT.setFont(new Font("Tahoma", Font.PLAIN, 12));
		btnEXIT.setBounds(108, 281, 85, 21);
		frame.getContentPane().add(btnEXIT);
		
		JButton btnSHOW = new JButton("\u041F\u043E\u0441\u043C\u043E\u0442\u0440\u0435\u0442\u044C \u0441\u043F\u0438\u0441\u043E\u043A");
		btnSHOW.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				String res = C.show();
				textArea.setText(res);
			}
		});
		btnSHOW.setFont(new Font("Tahoma", Font.PLAIN, 12));
		btnSHOW.setBounds(333, 179, 148, 30);
		frame.getContentPane().add(btnSHOW);
		
		textArea = new JTextArea();
		textArea.setEditable(false);
		textArea.setBackground(Color.LIGHT_GRAY);
		textArea.setBounds(295, 214, 217, 183);
		frame.getContentPane().add(textArea);
		JScrollPane scrollPane = new JScrollPane(textArea, JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED, JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
		scrollPane.setBounds(295, 211, 217, 183);
		frame.getContentPane().add(scrollPane);
	}
}
